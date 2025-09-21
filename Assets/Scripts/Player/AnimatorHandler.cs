using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActivateRunAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, true);
    }

    public void DeactivateRunAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, false);
    }
    
    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Jump);
    }
}
