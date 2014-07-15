namespace GameFifteenProject.Contracts.Engine
{
    public interface IRandomNumberGenerator
    {
        int Next();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}