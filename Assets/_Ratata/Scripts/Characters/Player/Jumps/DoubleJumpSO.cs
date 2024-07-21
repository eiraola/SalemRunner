using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpDouble", menuName = "ScriptableObjects/Mechanics/DoubleJump", order = 1)]
public class DoubleJumpSO : JumpBasicSO
{
    [SerializeField] int numJumps = 1;
    private int currentAvailableJumps = 0;
    public override float JumpAction(float currentSpeed)
    {
        if (!movementStats.isJumpButtonPressed && currentAvailableJumps > 0 && movementStats.DistanceToGround() > 0.01f)
        {
            movementStats.isJumpButtonPressed = true;
            movementStats.lastTimeJumpPressed = Time.time;
            currentAvailableJumps--;

            _playSoundAction?.Invoke(EClip.Jump);
            return movementStats.JumpForce;
        }
        if (movementStats.DistanceToGround() < 0.01f) 
        { 
            currentAvailableJumps = numJumps;
        }
        return base.JumpAction(currentSpeed);
    }
}
