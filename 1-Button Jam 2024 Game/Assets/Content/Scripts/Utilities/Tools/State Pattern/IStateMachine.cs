public interface IStateMachine
{
    public abstract void InitState(in IState initialState);
    public abstract void TransitionTo(in IState nextState);
    public abstract void OnDestroy();
}