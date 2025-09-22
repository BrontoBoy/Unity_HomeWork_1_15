using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRun()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, true);
    }

    public void StopRun()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, false);
    }
    
    public void PlayJump()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Jump);
    }
}
