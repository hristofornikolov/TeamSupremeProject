namespace GameFifteen.Common.Engine.Factories
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts;

    public sealed class FieldFactory
    {
        private static FieldFactory instance; 

        private FieldFactory()
        {
        }

        public static FieldFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FieldFactory();
                }

                return instance;
            }
        }

        public IMatrixField GetField(int size)
        {
            switch (size)
            {
                case 4:
                    return new MatrixField(4, 4);
                case 5:
                    return new MatrixField(5, 5);
                case 6:
                    return new MatrixField(6, 6);
                default:
                    return new MatrixField(4, 4);
            }
        }
    }
}