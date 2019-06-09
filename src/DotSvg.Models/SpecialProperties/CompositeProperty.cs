namespace DotSvg.Models.SpecialProperties
{
    public struct CompositeProperty<T1, T2> : ICompositeProperty 
        where T1 : struct 
        where T2 : struct
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
}
