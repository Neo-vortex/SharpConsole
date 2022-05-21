using SharpConsole.DataTypes;
using SharpConsole.DataTypes.ConsoleReports;
using SharpConsole.DataTypes.Spinners;

var cr = new ConsoleReporter();


var filedownloadreport = new SpinnerConsoleReports("simple progress", "filedownloadreport" , ConsoleColor.Green).WithSpinner(
    new SquarSpinner(foregroundColor: ConsoleColor.Green).WithDoneString("†"));

cr.AddNewReport(filedownloadreport);
cr.AddNewReport(
    new SpinnerConsoleReports("simple progress2", "dummy", ConsoleColor.Green).WithSpinner(
        new SquarSpinner(foregroundColor: ConsoleColor.Green)));
cr.WithRefreshRate(TimeSpan.FromMilliseconds(50));
cr.Run();
for (int i = 0; i < 50; i++)
{
    System.Threading.Thread.Sleep(50); 
    (cr.GetReportByName<SpinnerConsoleReports>(nameof(filedownloadreport)) ).Tick();
}
(cr.GetReportByName<SpinnerConsoleReports>(nameof(filedownloadreport)) ).Spinner.Done();
(cr.GetReportByName<SpinnerConsoleReports>("dummy")  ).Spinner.Failed();

while (true)
{
    System.Threading.Thread.Sleep(2000);
    
}