namespace GameFifteenProject.Engine
{

    public static class GameFifteenConstants
    {
        public const string AskNameMessage = "Please enter your name for the scoreboard: ";
        public const string AskNumberMessage = "Enter a number to move: ";
        public const string InvalidCommandMessage = "Invalid move or command.";
        public const string WinMessage = "Well done! You won the game in {0} moves.";

        // 1, 1 is for testing
        public const int FieldMinimumShuffles = 2;
        public const int FieldMaximumShuffles = 2; 
        public const int FieldInitialRows = 4;
        public const int FieldInitialColumns = 4;

        public const int ScoreboardTopPlayersCount = 5;

        public const string PlayerUnknownName = "Unknown";
    }
}
