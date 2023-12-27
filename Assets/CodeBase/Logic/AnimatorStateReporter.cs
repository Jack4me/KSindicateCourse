using CodeBase.Logic;
using UnityEngine;

namespace Logic
{
  public class AnimatorStateReporter : StateMachineBehaviour
  {
    private IAnimationStateReader _stateReader;

    public override void OnStateEnter(Animator Animator, AnimatorStateInfo StateInfo, int LayerIndex)
    {
      base.OnStateEnter(Animator, StateInfo, LayerIndex);
      FindReader(Animator);
     
      _stateReader.EnteredState(StateInfo.shortNameHash);
    }

    public override void OnStateExit(Animator Animator, AnimatorStateInfo StateInfo, int LayerIndex)
    {
      base.OnStateExit(Animator, StateInfo, LayerIndex);
      FindReader(Animator);
     
      _stateReader.ExitedState(StateInfo.shortNameHash);
    }

    private void FindReader(Animator Animator)
    {
      if (_stateReader != null)
        return;

      _stateReader = Animator.gameObject.GetComponent<IAnimationStateReader>();
    }
  }
}