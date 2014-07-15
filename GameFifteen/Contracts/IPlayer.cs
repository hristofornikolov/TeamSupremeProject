namespace GameFifteenProject.Contracts
{
    using System;

    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="Player"/> class instance
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the moves of the <see cref="Player"/> class instance
        /// </summary>
        int Moves { get; set; }
    }
}