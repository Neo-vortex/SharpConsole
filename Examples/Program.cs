using Examples;
using Examples.Examples;

var examples = new List<IExample>();
examples.Add( new SquarSpinnerExample());

foreach (var example in examples)
{
    Console.WriteLine(example.Info());
    Console.WriteLine(new string('-', Console.WindowWidth));
    example.Run().Wait();
    Console.Clear();
}
Console.WriteLine(new string('-', Console.WindowWidth));
Console.WriteLine("Done with Examples");
Console.ReadKey();
