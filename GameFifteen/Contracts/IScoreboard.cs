namespace GameFifteenProject.Contracts
{
    using System.Collections.Generic;

    using GameFifteenProject.GameObjects;

    public interface IScoreboard
    {
        void AddPlayer(Player player);

        IList<Player> Players { get; }
    }
}
