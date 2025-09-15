using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation(bool isRunning)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, isRunning);
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Jump);
    }
}
