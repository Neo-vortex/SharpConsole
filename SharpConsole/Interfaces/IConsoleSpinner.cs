namespace SharpConsole.Interfaces;

public interface IConsoleSpinner : IConsoleTickable 
{
    public List<ConsoleReportPiece> GetSpinnerString();
    
    public  bool Result { get; set; }

    public void Done();

    public void Failed();
    
    public  int SpinnerStringLength { get;  set; }
    
    public  bool Active { get;  set; }
    
    public string DoneString { get; set; }
    
    public  string FailedString { get; set; }
    
    public  IConsoleSpinner WithDoneString(string doneString);
    public  IConsoleSpinner WithFailedString(string failedString);
}