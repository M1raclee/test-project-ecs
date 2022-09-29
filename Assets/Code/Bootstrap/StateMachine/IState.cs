namespace Code.Bootstrap.StateMachine
{
    public interface IState
    {
        void Enter();
    }

    public interface IExitableState : IState
    {
        void Exit();
    }
}