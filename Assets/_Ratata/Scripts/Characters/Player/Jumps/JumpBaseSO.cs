using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class JumpBaseSO : ScriptableObject
{
    [HideInInspector]
    public MovementStats movementStats;
    protected Action<EClip> _playSoundAction;
    public virtual void Init(Action<EClip> soundAction, MovementStats newMovementStats)
    {
        _playSoundAction = soundAction;
        movementStats = newMovementStats;
    }

    public virtual void Deactivate() 
    {
        _playSoundAction = null;
        movementStats = null;
    }

    public virtual float CalculateVerticalVelocity(float currentSpeed)
    {
        float finalGravityForce = movementStats.GravityForce;
        if (currentSpeed < 0.0f)
        {
            finalGravityForce = movementStats.GravityForce * movementStats.FallGravitymultiplier;
        }
        if (movementStats.isJumpButtonPressed && Mathf.Abs(currentSpeed) < movementStats.MaxAppexPoint)
        {
            finalGravityForce = movementStats.GravityForce * movementStats.MaxAppexSpeed;
        }
        if (currentSpeed < -movementStats.MaxFallVelocity)
        {
            return -movementStats.MaxFallVelocity;
        }

        return currentSpeed + finalGravityForce * Time.deltaTime;
    }
    public virtual float CheckJump(float currentSpeed)
    {
        if (movementStats.DistanceToGround() < 0.001f && movementStats.isJumpButtonPressed && (movementStats.lastTimeJumpPressed + movementStats.JumpInputBuffer) > Time.time)
        {
            _playSoundAction?.Invoke(EClip.Jump);
            return movementStats.JumpForce;
        }

        return currentSpeed;
    }

    public virtual float JumpAction(float currentSpeed) {
        movementStats.isJumpButtonPressed = true;
        movementStats.lastTimeJumpPressed = Time.time;
        return currentSpeed;
    }
    public virtual float OnJumpReleased(float currentSpeed)
    {
        movementStats.isJumpButtonPressed = false;
        if (currentSpeed > 0.0f)
        {
            return currentSpeed / movementStats.JumpReleasedSpeedLose;
        }
        return currentSpeed;
    }
}