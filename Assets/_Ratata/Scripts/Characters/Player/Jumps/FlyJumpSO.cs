using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyJump", menuName = "ScriptableObjects/Mechanics/FlyJump", order = 1)]
public class FlyJumpSO : JumpBaseSO
{
    [SerializeField] private float FlySpeed = 1f;
    private bool isFlying = false;
    private bool stoppedFlying = false;

    public override float CalculateVerticalVelocity(float currentSpeed)
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
        if (isFlying)
        {
            finalGravityForce = movementStats.GravityForce/FlySpeed;
        }
        if (currentSpeed < -movementStats.MaxFallVelocity)
        {
            return -movementStats.MaxFallVelocity;
        }

        return currentSpeed + finalGravityForce * Time.deltaTime;
    }

    public override float JumpAction(float currentSpeed)
    {

        currentSpeed = base.JumpAction(currentSpeed);

        if (!stoppedFlying && movementStats.DistanceToGround() > 0.02f)
        {
            isFlying = true;
            currentSpeed = 0.0f;
        }

        if (movementStats.DistanceToGround() < 0.01f)
        {
            isFlying = false;
            stoppedFlying = false;
        }
        return currentSpeed;
    }

    public override float OnJumpReleased(float currentSpeed)
    {
        currentSpeed = base.OnJumpReleased(currentSpeed);
        if (isFlying)
        {
            isFlying = false;
            stoppedFlying = true;
        }
        return currentSpeed;
    }
}
