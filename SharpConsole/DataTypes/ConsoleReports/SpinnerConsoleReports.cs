using SharpConsole.DataTypes.Spinners;
using SharpConsole.Interfaces;

namespace SharpConsole.DataTypes.ConsoleReports;

public class SpinnerConsoleReports : ConsoleLine, IConsoleTickable
{

    public IConsoleSpinner Spinner { get; private set; } = new EmptySpinner();

    public SpinnerConsoleReports(string line, string name , ConsoleColor foregroundColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black) : base(line, name ,foregroundColor, backgroundColor)
    {
    }

    public SpinnerConsoleReports WithSpinner(IConsoleSpinner spinner)
    {
        Spinner = spinner;
        return this;
    }

    public void Tick()
    {
        Spinner.Tick();
    }

    public override List<ConsoleReportPiece> GenerateReport()
    {
        var result = new List<ConsoleReportPiece>();
        result.AddRange(Spinner.GetSpinnerString());
        var spinger_char_length = Spinner.GetSpinnerString().Sum(x => x.Text.Length);

        if (Spinner.Active)
        {
            result.Add(new ConsoleReportPiece(ConsoleColor.White, ConsoleColor.Black,
                new string(' ', Spinner.SpinnerStringLength - spinger_char_length + 1)));
        }
        else
        {
            result.Add(new ConsoleReportPiece(ConsoleColor.White, ConsoleColor.Black,
                new string(' ',  1)));
        }
        
        result.Add(new(base.ForegroundColor, base. BackgroundColor, base.Line));
        return result;
    }
}

