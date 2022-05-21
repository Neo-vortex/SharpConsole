using SharpConsole.DataTypes.ConsoleReports;
using SharpConsole.DataTypes.Spinners;

namespace Examples.Examples;

public class SquarSpinnerExample : IExample
{
    public Task Run()
    {
        return Task.Run(() =>
        {
            var cr = new ConsoleReporter();
            var filedownloadreport =
                new SpinnerConsoleReports("simple progress", "filedownloadreport", ConsoleColor.Green).WithSpinner(
                new SquarSpinner(foregroundColor: ConsoleColor.Green).WithDoneString("†"));

            var dummyreport =  new SpinnerConsoleReports("simple progress2", "dummyreport", ConsoleColor.Green).WithSpinner(
                new SquarSpinner(foregroundColor: ConsoleColor.Green));
            
            
            cr.AddNewReport(filedownloadreport);
            cr.AddNewReport(dummyreport);
            cr.WithRefreshRate(TimeSpan.FromMilliseconds(50));
            cr.Run();
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200); 
                (cr.GetReportByName<SpinnerConsoleReports>(nameof(filedownloadreport)) ).Tick();
                Thread.Sleep(200); 
            }
            (cr.GetReportByName<SpinnerConsoleReports>(nameof(filedownloadreport))).Spinner.Done();
            (cr.GetReportByName<SpinnerConsoleReports>(nameof(dummyreport))).Spinner.Failed();

        });
    }

    public string Info()
    {
        return "SquarSpinnerExample : Simple dot based spinner";
    }
}