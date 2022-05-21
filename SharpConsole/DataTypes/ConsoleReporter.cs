using SharpConsole.Interfaces;

namespace SharpConsole.DataTypes{}

public class ConsoleReporter
{
    public TimeSpan RefreshRate { get; private set; } = TimeSpan.FromSeconds(1);
    private Thread _updater_thread;
    private object _lock = new();
    public List<IConsoleReport> Reports { private get; set; } = new();
    private bool _duty;


    public T GetReportByName<T>(string name)
    {
        return (T) Reports.Single(rpt => rpt.Name == name);
    }
    private static void ClearLine(int lines = 1)
    {
        for (var i = 1; i <= lines; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(  string.Join("", Enumerable.Repeat(' ' , Console.WindowWidth)));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
    
    public  bool TryRemoveReport(string name)
    {
        lock (_lock)
        {
            var report = Reports.SingleOrDefault(rpt => rpt.Name == name);
            if (report == null) return false;
            Reports.Remove(report);
            return true;
        }
    }
    
    public  bool TryAddReport(IConsoleReport report , out ConsoleReporter newReport)
    {
        lock (_lock)
        {
            newReport = this;
            if (Reports.Contains(report)) return false;
            Reports.Add(report);
            return true;
        }
    }
    
    public ConsoleReporter  AddNewReport(IConsoleReport report)
    {
        lock (_lock)
        {
            if (Reports.Any(rpt => rpt.Name == report.Name))
            {
                throw new ArgumentException($"Report with name {report.Name} already exists");
            }
            Reports.Add(report);
        }

        return this;
    }

    public void Run()
    {
        _duty = true;
        _updater_thread = new Thread(updater);
        _updater_thread.IsBackground = true;
        _updater_thread.Start();
    }

    public void Stop()
    {
            _duty = false;
            _updater_thread.Join();
            lock (_lock)
            {
                foreach (var reportElement in Reports)
                {
                    var report = reportElement.GenerateReport();
                    foreach (var r in report)
                    {
                        Console.ForegroundColor = r.Foreground;
                        Console.BackgroundColor = r.Background;
                        Console.Write(r.Text.PadLeft(r.LeftPad).PadRight(r.RightPad));
                    }
                    Console.WriteLine();
                }
            }
    }
    
    private void updater()
    {
        while (_duty)
        {
            lock (_lock)
            {
                foreach (var reportElement in Reports)
                {
                    var report = reportElement.GenerateReport();
                    foreach (var r in report)
                    {
                        Console.ForegroundColor = r.Foreground;
                        Console.BackgroundColor = r.Background;
                        Console.Write(r.Text.PadLeft(r.LeftPad).PadRight(r.RightPad));
                    }
                    Console.WriteLine();
                }
            }
            Thread.Sleep(RefreshRate.Milliseconds);
            ClearLine(Reports.Count);
        }
    }
    
    public ConsoleReporter WithRefreshRate(TimeSpan refreshRate)
    {
        RefreshRate = refreshRate;
        return this;
    }
}
