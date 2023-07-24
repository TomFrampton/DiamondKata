namespace DiamondKata.App
{
    public class Program
    {
        public static void Main()
        {
            var solution = new Solution(new ConsoleOutputWriter());

            Console.WriteLine("Welcome to Tom's Diamond Kata solution!");

            while (true)
            {
                Console.WriteLine("Please enter a letter...");

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !solution.IsValidInput(input[0]))
                {
                    Console.WriteLine("Input must be a letter");
                    continue;
                }

                Console.WriteLine("\nOutput:\n");

                var inputLetter = input[0];
                solution.DrawLetter(inputLetter);

                Console.WriteLine();
            }
        }
    }
}

