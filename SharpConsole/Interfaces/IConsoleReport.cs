namespace SharpConsole.Interfaces;

public interface IConsoleReport
{
    public  List<ConsoleReportPiece> GenerateReport();
    public string Name { get; set; }
}