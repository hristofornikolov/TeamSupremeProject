namespace GameFifteen.Contracts
{
    using System.Collections.Generic;

    public interface IScoreboard
    {
        void AddPlayer(IPlayer player);

        IList<IPlayer> Players { get; }
    }
}