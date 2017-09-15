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
        //Assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowException_WhenNullReaderIsGiven()
        {
            //Arrange & Act
            Mock<IWriter> writerMock = new Mock<IWriter>();
            Mock<IParser> parserMock = new Mock<IParser>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            IEngine engine = new Engine(null, writerMock.Object, parserMock.Object,dbMock.Object, commandFactoryMock.Object);
        }
        [TestMethod]
        //Assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowException_WhenNullWriterIsGiven()
        {
            //Arrange & Act
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IParser> parserMock = new Mock<IParser>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            IEngine engine = new Engine(readerMock.Object, null, parserMock.Object, dbMock.Object, commandFactoryMock.Object);
        }
        [TestMethod]
        //Assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowException_WhenNullParserIsGiven()
        {
            //Arrange & Act
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IWriter> writerMock = new Mock<IWriter>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            IEngine engine = new Engine(readerMock.Object, writerMock.Object, null, dbMock.Object, commandFactoryMock.Object);
        }
    }
}
