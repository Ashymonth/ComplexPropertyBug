namespace ComplexTypeBug.Models;

public class TableWithSmartEnum
{
    public int Id { get; set; }

    public TestEnum Enum { get; set; } = null!;
    
}