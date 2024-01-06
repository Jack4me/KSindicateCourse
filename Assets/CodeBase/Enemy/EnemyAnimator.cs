using System;
using Logic;
using UnityEngine;

namespace Enemy {
  public class EnemyAnimator : MonoBehaviour, IAnimationStateReader
  {
    private static readonly int _attack = Animator.StringToHash("Attack_1");
    private static readonly int _speed = Animator.StringToHash("Speed");
    private static readonly int _isMoving = Animator.StringToHash("IsMoving");
    private static readonly int _hit = Animator.StringToHash("Hit");
    private static readonly int _die = Animator.StringToHash("Die");

    private readonly int _idleStateHash = Animator.StringToHash("idle");
    private readonly int _attackStateHash = Animator.StringToHash("attack01");
    private readonly int _walkingStateHash = Animator.StringToHash("Move");
    private readonly int _deathStateHash = Animator.StringToHash("die");

    private Animator _animator;

    public event Action<AnimatorState> StateEntered;
    public event Action<AnimatorState> StateExited;

    public AnimatorState State { get; private set; }

    private void Awake() => 
      _animator = GetComponent<Animator>();

    public void PlayHit() => _animator.SetTrigger(_hit);
    public void PlayDeath() => _animator.SetTrigger(_die);

    public void Move(float Speed)
    {
      _animator.SetBool(_isMoving, true);
      _animator.SetFloat(_speed, Speed);
    }

    public void StopMoving() => _animator.SetBool(_isMoving, false);

    public void PlayAttack() => _animator.SetTrigger(_attack);

    public void EnteredState(int StateHash)
    {
      State = StateFor(StateHash);
      StateEntered?.Invoke(State);
    }
    
    public void ExitedState(int StateHash) => 
      StateExited?.Invoke(StateFor(StateHash));

    private AnimatorState StateFor(int stateHash)
    {
      AnimatorState state;
      if (stateHash == _idleStateHash)
        state = AnimatorState.Idle;
      else if (stateHash == _attackStateHash)
        state = AnimatorState.Attack;
      else if (stateHash == _walkingStateHash)
        state = AnimatorState.Walking;
      else if (stateHash == _deathStateHash)
        state = AnimatorState.Died;
      else
        state = AnimatorState.Unknown;
      
      return state;
    }
  }
}

