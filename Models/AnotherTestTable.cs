namespace ComplexTypeBug.Models;

public class AnotherTestTable
{
    public Guid Id { get; set; }

    public TestComplexObject ComplexProperty { get; set; } = null!;
}