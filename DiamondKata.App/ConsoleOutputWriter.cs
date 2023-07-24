namespace DiamondKata.App
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
