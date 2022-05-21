namespace SharpConsole;

public struct ConsoleReportPiece
{
    public ConsoleReportPiece(ConsoleColor foreground, ConsoleColor background, string text , int leftpad = 0 , int rightpad = 0)
    {
        Foreground = foreground;
        Background = background;
        LeftPad = leftpad;
        RightPad = rightpad;
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
    public int LeftPad { get; set; }
    public int RightPad { get; set; }
    public  ConsoleColor Foreground { get; private set; }
    public  ConsoleColor Background { get; private set; }
    public  string Text { get; private  set; }
}