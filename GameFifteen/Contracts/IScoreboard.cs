namespace GameFifteen.Contracts
{
    using System.Collections.Generic;

    public interface IScoreboard
    {
        /// <summary>
        /// Adds a player to the list of players to be displayed on the scoreboard
        /// </summary>
        /// <param name="player"></param>
        void AddPlayer(IPlayer player);

        /// <summary>
        /// Gets the list of players to be displayed on the scoreboard
        /// </summary>
        IList<IPlayer> Players { get; }
    }
}