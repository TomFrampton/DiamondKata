namespace DiamondKata.App.Tests
{
    public class SolutionTests
    {
        private IOutputWriter _outputWriter;

        [SetUp]
        public void Setup()
        {
            _outputWriter = Substitute.For<IOutputWriter>();
        }

        [Test]
        public void DrawLetter_WhenA_ShouldDrawDiamond()
        {
            var solution = new Solution(_outputWriter);

            solution.DrawLetter('A');

            _outputWriter.Received(1).WriteLine("A");
        }

        [Test]
        public void DrawLetter_WhenB_ShouldDrawDiamond()
        {
            var solution = new Solution(_outputWriter);

            solution.DrawLetter('B');

            Received.InOrder(() =>
            {
                _outputWriter.WriteLine(" A ");
                _outputWriter.WriteLine("B B");
                _outputWriter.WriteLine(" A ");
            });
        }

        [Test]
        public void DrawLetter_WhenE_ShouldDrawDiamond()
        {
            var solution = new Solution(_outputWriter);

            solution.DrawLetter('E');

            Received.InOrder(() =>
            {
                _outputWriter.WriteLine("    A    ");
                _outputWriter.WriteLine("   B B   ");
                _outputWriter.WriteLine("  C   C  ");
                _outputWriter.WriteLine(" D     D ");
                _outputWriter.WriteLine("E       E");
                _outputWriter.WriteLine(" D     D ");
                _outputWriter.WriteLine("  C   C  ");
                _outputWriter.WriteLine("   B B   ");
                _outputWriter.WriteLine("    A    ");
            });
        }

        [Test]
        [TestCase('1')]
        [TestCase('£')]
        [TestCase('/')]
        [TestCase('Ö')]
        [TestCase(' ')]
        public void DrawLetter_WhenNotLetter_ShouldThrowArgumentException(char input)
        {
            var solution = new Solution(_outputWriter);

            Assert.Throws<ArgumentException>(() => solution.DrawLetter(input));
        }

        [Test]
        [TestCase('a')]
        [TestCase('m')]
        [TestCase('z')]
        [TestCase('A')]
        [TestCase('M')]
        [TestCase('Z')]
        public void IsValidInput_WhenValidInput_ShouldReturnTrue(char input)
        {
            var solution = new Solution(_outputWriter);

            Assert.True(solution.IsValidInput(input));
        }

        [Test]
        [TestCase('1')]
        [TestCase('£')]
        [TestCase('/')]
        [TestCase('Ö')]
        [TestCase(' ')]
        public void IsValidInput_WhenInvalidInput_ShouldReturnFalse(char input)
        {
            var solution = new Solution(_outputWriter);

            Assert.False(solution.IsValidInput(input));
        }
    }
}
