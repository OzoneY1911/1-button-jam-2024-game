public interface IState
{
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();
}
