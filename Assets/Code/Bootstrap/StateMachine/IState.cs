namespace Code.Bootstrap.StateMachine
{
    public interface IState { }

    public interface IEnterableState : IState
    {
        void Enter();
    }

    public interface IPayloadState<in TPayload> : IState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState : IState
    {
        void Exit();
    }

    public interface IUpdatableState : IState
    {
        void Update();
    }
}