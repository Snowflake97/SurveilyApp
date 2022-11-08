using System.IO;
using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("somefile", true)]
    [TestFixture("some file", true)]
    [TestFixture(@"TestsDirectoryCreatedBySnowflakeAndCanEasilyBeDeleted/nestedfile", true)]
    public class FileSaver_SaveToFile_IsFileExistsTest
    {
        private readonly FileSaver _fileSaver;
        private readonly bool _expectedResult;

        public FileSaver_SaveToFile_IsFileExistsTest(string testInput, bool expectedResult)
        {
            _fileSaver = new FileSaver(testInput, "", "test content");
            _expectedResult = expectedResult;
        }

        [Test]
        public void SaveToFile_IsFileExistsTest()
        {
            _fileSaver.SaveToFile();
            var methodResult = _fileSaver.IsFileExists();
            Assert.AreEqual(_expectedResult, methodResult);
            File.Delete(_fileSaver.PathToFile);
        }
    }
}