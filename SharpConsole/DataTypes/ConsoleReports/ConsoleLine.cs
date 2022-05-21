using SharpConsole.Interfaces;

namespace SharpConsole.DataTypes.ConsoleReports;

public  class ConsoleLine : IConsoleReport 
{
    public  ConsoleColor ForegroundColor { get; private set; }
    
    public  ConsoleColor BackgroundColor { get; private set; }
    
    public string Line { get; set; }
    public  ConsoleLine(string line , string name , ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        Line = line ?? throw new NullReferenceException(nameof(line));
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
        Name = name ?? throw new NullReferenceException(nameof(name));
    }
    public virtual List<ConsoleReportPiece> GenerateReport()
    {
        return new List<ConsoleReportPiece> { new(ForegroundColor, BackgroundColor, Line) };
    }

    public string Name { get; set; }
}