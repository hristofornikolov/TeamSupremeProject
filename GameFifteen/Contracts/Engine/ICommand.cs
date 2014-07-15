namespace GameFifteen.Contracts.Engine
{
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of a command
        /// </summary>
        string Name { get; }
    }
}