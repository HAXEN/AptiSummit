using System.Collections.Generic;

namespace AptiSummit.Api
{
    public class FakeValues
    {
        private static FakeValues _instance;
        private readonly List<Value> _values = new List<Value>();

        private FakeValues()
        {
            for (int i = 1; i < 234; i++)
            {
                _values.Add(new Value()
                {
                    Id = i,
                    Name = $"Item {i}",
                });
            }
        }

        public IEnumerable<Value> Values => _values;
        public static FakeValues Instance => (_instance = _instance ?? new FakeValues());
    }

    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
