namespace ComplexTypeBug.Models;

public class TestTable
{
    public DateTime Date { get; set; }

    public string Key { get; set; } = null!;

    public TestComplexObject ComplexObject { get; set; } = null!;
}