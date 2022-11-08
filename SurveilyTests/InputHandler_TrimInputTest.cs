using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("somestring", "somestring")]
    [TestFixture("some string", "somestring")]
    [TestFixture("    somestring", "somestring")]
    [TestFixture("somestring      ", "somestring")]
    [TestFixture("some      string", "somestring")]
    [TestFixture("          somestring           ", "somestring")]
    [TestFixture("", "")]
    [TestFixture("              ", "")]
    public class InputHandler_TrimInputTest
    {
        private readonly InputHandler _inputHandler;
        private readonly string _testInput;
        private readonly string _expectedResult;

        public InputHandler_TrimInputTest(string testInput, string expectedResult)
        {
            _inputHandler = new InputHandler();
            _testInput = testInput;
            _expectedResult = expectedResult;
        }

        [Test]
        public void TrimInputTest()
        {
            var methodResult = _inputHandler.TrimInput(_testInput);
            Assert.AreEqual(_expectedResult, methodResult);
        }
    }
}