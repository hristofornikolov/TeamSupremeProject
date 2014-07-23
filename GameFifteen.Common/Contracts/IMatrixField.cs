namespace GameFifteen.Common.Contracts
{
    using System.Collections.Generic;

    public interface IMatrixField : IEnumerable<int>
    {
        int Rows { get; }

        int Columns { get; }

        int Length { get; }

        int this[int index] { get; set; }

        int this[int row, int col] { get; set; }
    }
}