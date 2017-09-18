using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Academy.Tests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
  
        [TestMethod]
        public void ThrowException_WhenNullReaderIsGiven()
        {
            //Arrange
            Mock<IWriter> writerMock = new Mock<IWriter>();
            Mock<IParser> parserMock = new Mock<IParser>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(null, writerMock.Object, parserMock.Object));

        }
        [TestMethod]
        public void ThrowException_WhenNullWriterIsGiven()
        {
            //Arrange
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IParser> parserMock = new Mock<IParser>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, null,  parserMock.Object));
        }
        [TestMethod]
        public void ThrowException_WhenNullParserIsGiven()
        {
            //Arrange
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IWriter> writerMock = new Mock<IWriter>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, writerMock.Object, null));
        }
    }
}
