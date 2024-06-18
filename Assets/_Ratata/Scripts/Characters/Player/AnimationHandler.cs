using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void SetIsGrounded(bool isGrounded)
    {
        _animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetIsDead(bool isDead)
    {
        _animator.SetBool("IsDead", isDead);
    }
}
