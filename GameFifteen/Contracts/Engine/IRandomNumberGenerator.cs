namespace GameFifteenProject.Contracts.Engine
{
    public interface IRandomNumberGenerator
    {
        int Next(int minValue, int maxValue);
    }
}