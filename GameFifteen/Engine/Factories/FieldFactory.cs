﻿namespace GameFifteen.Engine.Factories
{
    using GameFifteen.Contracts;
    using GameFifteen.GameObjects;
    using System;
    using System.Linq;

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

        public IFieldMatrix GetField(int size)
        {
            switch (size)
            {
                case 4:
                    return new FieldMatrix(4, 4);
                default:
                    return new FieldMatrix(4, 4);
            }
        }
    }
}