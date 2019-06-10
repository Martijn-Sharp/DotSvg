namespace DotSvg.Models.SpecialProperties
{
    public struct CompositeProperty<T1, T2> : ICompositeProperty
    {
        public CompositeProperty(T1 t1)
        {
            Value = t1;
        }

        public CompositeProperty(T2 t2)
        {
            Value = t2;
        }

        public object Value { get; }

        public static implicit operator CompositeProperty<T1, T2>(T1 t1) => new CompositeProperty<T1, T2>(t1);

        public static implicit operator CompositeProperty<T1, T2>(T2 t2) => new CompositeProperty<T1, T2>(t2);
    }

    public struct CompositeProperty<T1, T2, T3> : ICompositeProperty
    {
        public CompositeProperty(T1 t1)
        {
            Value = t1;
        }

        public CompositeProperty(T2 t2)
        {
            Value = t2;
        }

        public CompositeProperty(T3 t3)
        {
            Value = t3;
        }

        public object Value { get; }

        public static implicit operator CompositeProperty<T1, T2, T3>(T1 t1) => new CompositeProperty<T1, T2, T3>(t1);

        public static implicit operator CompositeProperty<T1, T2, T3>(T2 t2) => new CompositeProperty<T1, T2, T3>(t2);

        public static implicit operator CompositeProperty<T1, T2, T3>(T3 t3) => new CompositeProperty<T1, T2, T3>(t3);
    }
}
