using System.IO;
using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture(@"TestsDirectoryCreatedBySnowflakeAndCanEasilyBeDeleted", true)]
    [TestFixture(@"TestsDirectoryCreatedBySnowflakeAndCanEasilyBeDeleted\nested1\nested2\\nested3\nested4", true)]
    [TestFixture(@"TestsDirectoryCreatedBySnowflakeAndCanEasilyBeDeleted\nested1\nested2//nested3\nested4//////nested5",
        true)]
    [TestFixture(@"", true)] // current directory
    public class FileSaver_CreateDirectory_IsDirectoryExitsTest
    {
        private readonly FileSaver _fileSaver;
        private readonly bool _expectedResult;
        private readonly string _testInput;

        public FileSaver_CreateDirectory_IsDirectoryExitsTest(string testInput, bool expectedResult)
        {
            _fileSaver = new FileSaver();
            _testInput = testInput;
            _fileSaver.DirectoryPath = testInput;
            _expectedResult = expectedResult;
            _fileSaver.CreateDirectory();
        }

        [Test]
        public void CreateDirectory_IsDirectoryExitsTest()
        {
            var methodResult = _fileSaver.IsDirectoryExits();
            Assert.AreEqual(_expectedResult, methodResult);
            if (!string.IsNullOrEmpty(_testInput))
            {
                Directory.Delete(@"TestsDirectoryCreatedBySnowflakeAndCanEasilyBeDeleted", true);
            }
        }
    }
}