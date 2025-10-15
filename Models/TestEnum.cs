using Ardalis.SmartEnum;

namespace ComplexTypeBug.Models;

public class TestEnum : SmartEnum<TestEnum>
{
    private TestEnum(string name, int value) : base(name, value)
    {
    }

    public static readonly TestEnum Value = new TestEnum("test", 1);
}