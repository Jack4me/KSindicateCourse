using System;
using CodeBase.Logic;
using UnityEngine;

namespace Hero
{
  public class HeroAnimator : MonoBehaviour, IAnimationStateReader
  {
    private static readonly int _moveHash = Animator.StringToHash("Walking");
    private static readonly int _attackHash = Animator.StringToHash("AttackNormal");
    private static readonly int _hitHash = Animator.StringToHash("Hit");
    private static readonly int _dieHash = Animator.StringToHash("Die");

    private readonly int _idleStateHash = Animator.StringToHash("Idle");
    private readonly int _idleStateFullHash = Animator.StringToHash("Base Layer.Idle");
    private readonly int _attackStateHash = Animator.StringToHash("Attack Normal");
    private readonly int _walkingStateHash = Animator.StringToHash("Run");
    private readonly int _deathStateHash = Animator.StringToHash("Die");
    
    public event Action<AnimatorState> StateEntered;
    public event Action<AnimatorState> StateExited;
   
    public AnimatorState State { get; private set; }
    
    public Animator animator;
    public CharacterController characterController;

    private void Update()
    {
      animator.SetFloat(_moveHash, characterController.velocity.magnitude, 0.05f, Time.deltaTime);
    }

    public bool IsAttacking => State == AnimatorState.Attack;
    

    public void PlayHit() => animator.SetTrigger(_hitHash);
    
    public void PlayAttack() => animator.SetTrigger(_attackHash);

    public void PlayDeath() =>  animator.SetTrigger(_dieHash);

    public void ResetToIdle() => animator.Play(_idleStateHash, -1);
    
    public void EnteredState(int StateHash)
    {
      State = StateFor(StateHash);
      StateEntered?.Invoke(State);
    }

    public void ExitedState(int StateHash) =>
      StateExited?.Invoke(StateFor(StateHash));
    
    private AnimatorState StateFor(int StateHash)
    {
      AnimatorState state;
      if (StateHash == _idleStateHash)
        state = AnimatorState.Idle;
      else if (StateHash == _attackStateHash)
        state = AnimatorState.Attack;
      else if (StateHash == _walkingStateHash)
        state = AnimatorState.Walking;
      else if (StateHash == _deathStateHash)
        state = AnimatorState.Died;
      else
        state = AnimatorState.Unknown;
      
      return state;
    }
  }
}