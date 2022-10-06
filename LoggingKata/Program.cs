using LoggingKata;
using System.IO;

const string csvPath = "TacoBell-US-AL.csv";
RunTaco newTaco = new RunTaco();
newTaco.Run(csvPath);
Console.ReadKey();

