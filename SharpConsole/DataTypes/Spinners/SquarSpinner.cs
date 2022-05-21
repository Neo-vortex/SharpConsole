using SharpConsole.Interfaces;

namespace SharpConsole.DataTypes.Spinners;

public class SquarSpinner : IConsoleSpinner
{
    public SquarSpinner(ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.White)
    {
        BackgroundColor = backgroundColor;
        ForegroundColor = foregroundColor;
    }
    public int SpinnerStringLength { get; set; } = 2;
    public bool Active { get; set; } = true;
    public string DoneString { get; set; } = "✓";
    public string FailedString { get; set; } = "x";
    public IConsoleSpinner WithDoneString(string doneString)
    {
        DoneString = doneString;
        return this;
    }

    public IConsoleSpinner WithFailedString(string failedString)
    {
        FailedString = failedString;
        return this;
    }

    private  int CurrentFrame { get;  set; } = 0;
    public ConsoleColor BackgroundColor { get; set; }

    public ConsoleColor ForegroundColor { get; set; }
    public void Tick()
    {
        CurrentFrame++;
    }

    public List<ConsoleReportPiece> GetSpinnerString()
    {
        if (!Active)
        {
            return Result ? new List<ConsoleReportPiece> { new( ForegroundColor, BackgroundColor,DoneString) } : new List<ConsoleReportPiece> { new( ForegroundColor, BackgroundColor,FailedString) };
        }
        switch (CurrentFrame)
        {
            case 0:
                return  new List<ConsoleReportPiece>{ new( ForegroundColor, BackgroundColor, ".")};
            case 1:
                return  new List<ConsoleReportPiece>{ new( ForegroundColor, BackgroundColor, "..")};
            case 2:
                return  new List<ConsoleReportPiece>{ new( ForegroundColor, BackgroundColor, ".:")};
            case 3:
                return  new List<ConsoleReportPiece>{ new( ForegroundColor, BackgroundColor, "::")};
            default:
                CurrentFrame = 0;
                return  new List<ConsoleReportPiece>{ new( ForegroundColor, BackgroundColor, ".")};
        }
    }

    public bool Result { get; set; }

    public void Done()
    {
        Active = false;
        Result = true;
    }

    public void Failed()
    {
        Active = false;
        Result = false;
    }


}