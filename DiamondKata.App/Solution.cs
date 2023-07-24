namespace DiamondKata.App
{
    public class Solution
    {
        private readonly IOutputWriter _outputWriter;

        public Solution(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        /// <summary>
        /// Given a character from the alphabet, prints a diamond of its 
        /// output with that character being the midpoint of the diamond.
        /// </summary>
        /// <param name="input">
        /// An upper or lower case character from the alphabet.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if input character is not a letter of the alphabet.
        /// </exception>
        public void DrawLetter(char input)
        {
            if (!IsValidInput(input))
            {
                throw new ArgumentException("Input character must be a letter of the alphabet");
            }

            var initial = char.IsUpper(input) ? 'A' : 'a';
            DrawLetter(input, initial, initial);
        }

        /// <summary>
        /// Returns a boolean indicating whether or not the character is valid for a diamond.
        /// </summary>
        /// <param name="input">
        /// The input character to check.
        /// </param>
        public bool IsValidInput(char input)
        {
            return (input >= 'A' && input <= 'Z') || (input >= 'a' && input <= 'z');
        }

        private void DrawLetter(char input, char initial, char current)
        {
            var margin = new string(' ', input - current);
            var padding = current != initial ? new string(' ', ((current - initial) * 2) - 1) : "";

            DrawLine(margin, padding, current);

            if (current < input)
            {
                DrawLetter(input, initial, (char)(current + 1));
                DrawLine(margin, padding, current);
            }
        }

        private void DrawLine(string margin, string padding, char letter)
        {
            _outputWriter.WriteLine($"{margin}{letter}{padding}{(padding.Length > 0 ? letter : "")}{margin}");
        }
    }
}
