using SharpConsole.Interfaces;

namespace SharpConsole.DataTypes.Spinners;

public class EmptySpinner : IConsoleSpinner
{
    private  int CurrentFrame { get;  set; } = 0;
    public ConsoleColor BackgroundColor { get; set; }

    public ConsoleColor ForegroundColor { get; set; }
    public  void Tick()
    {
    }

    public EmptySpinner(ConsoleColor foregroundColor = ConsoleColor.Black, ConsoleColor backgroundColor = ConsoleColor.White)
    {
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
    }
    public EmptySpinner()
    {
    }
    

    public List<ConsoleReportPiece> GetSpinnerString()
    {
        return new List<ConsoleReportPiece> { new(ForegroundColor, BackgroundColor, string.Empty) };
    }

    public bool Result { get; set; }

    public void Done()
    {
        throw new NullReferenceException("You did not set any spinner to call it done");
    }

    public void Failed()
    {
        throw new NullReferenceException("You did not set any spinner to call it finished");
    }

    public int SpinnerStringLength { get; set; } = 0;
    public bool Active { get; set; } = false;
    public string DoneString { get; set; } = "";
    public string FailedString { get; set; } = "";
    public IConsoleSpinner WithDoneString(string doneString)
    {
        throw new NullReferenceException("You did not set any spinner to change it's done string");
    }

    public IConsoleSpinner WithFailedString(string failedString)
    {
        throw new NullReferenceException("You did not set any spinner to change it's failed string");
    }
}