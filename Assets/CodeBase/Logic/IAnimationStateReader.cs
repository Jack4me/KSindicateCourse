namespace Logic
{
  public interface IAnimationStateReader
  {
    void EnteredState(int StateHash);
    void ExitedState(int StateHash);
    AnimatorState State { get; }
  }
}