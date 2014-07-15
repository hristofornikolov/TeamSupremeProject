namespace GameFifteenProject.Engine
{
    using System;

    internal static class GameFifteenConstants
    {
        internal const string StartScreenMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially.";
        internal const string CmdsDescriptionMessage = "You can use the following commands:";
        internal const string RestartCmdDescriptionMessage = "'restart' -> to start a new game.";
        internal const string TopCmdDescriptionMessage = "'top' -> to view the scoreboard.";
        internal const string ExitCmdDescriptionMessage = "'exit' -> to quit the game.";
        internal const string AskNameMessage = "Please enter your name for the scoreboard: ";
        internal const string AskNumberMessage = "Enter a number to move: ";
        internal const string InvalidCommandMessage = "Invalid move or command.";
        internal const string WinMessage = "Well done! You won the game in {0} moves.";

        // 2, 2 is for testing purposes only
        internal const int FieldMinimumShuffles = 2;
        internal const int FieldMaximumShuffles = 2; 
        internal const int FieldInitialRows = 4;
        internal const int FieldInitialColumns = 4;

        internal const string ScoreboardTitle = "Scoreboard:";
        internal const string ScoreboardView = "{0}. {1} --> {2} moves";
        internal const int ScoreboardTopPlayersCount = 5;

        internal const string PlayerUnknownName = "Unknown";
    }
}