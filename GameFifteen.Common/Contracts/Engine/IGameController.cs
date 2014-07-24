namespace GameFifteen.Common.Contracts.Engine
{
    public interface IGameController
    {
        void Start();

        string ExecuteCommand(string input);
    }
}
