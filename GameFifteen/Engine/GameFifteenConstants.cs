namespace GameFifteenProject.Engine
{
    using System;

    public static class GameFifteenConstants
    {
        public const string StartScreenMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially.";
        public const string CmdsDescriptionMessage = "You can use the following commands:";
        public const string RestartCmdDescriptionMessage = "'restart' -> to start a new game.";
        public const string TopCmdDescriptionMessage = "'top' -> to view the scoreboard.";
        public const string ExitCmdDescriptionMessage = "'exit' -> to quit the game.";
        public const string AskNameMessage = "Please enter your name for the scoreboard: ";
        public const string AskNumberMessage = "Enter a number to move: ";
        public const string InvalidCommandMessage = "Invalid move or command.";
        public const string WinMessage = "Well done! You won the game in {0} moves.";

        // 2, 2 is for testing
        public const int FieldMinimumShuffles = 2;
        public const int FieldMaximumShuffles = 2; 
        public const int FieldInitialRows = 4;
        public const int FieldInitialColumns = 4;

        public const string ScoreboardTitle = "Scoreboard:";
        public const string ScoreboardView = "{0}. {1} --> {2} moves";
        public const int ScoreboardTopPlayersCount = 5;

        public const string PlayerUnknownName = "Unknown";
    }
}