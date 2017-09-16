using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Tests.Core.EngineTests.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Academy.Tests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void ReturnError_WhenEmptyCommandIsGiven()
        {
            //Arrange
            Mock<IParser> parserMock = new Mock<IParser>();
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            readerMock.SetupSequence(x => x.ReadLine()).Returns("").Returns("Exit");

            MockWriter writerMock = new MockWriter();

            IEngine engine = new Engine(readerMock.Object, writerMock, parserMock.Object, dbMock.Object, commandFactoryMock.Object);

            //Act
            engine.Start();
     
            //Assert
            Assert.AreEqual("Value cannot be null.Parameter name: Command cannot be null or empty.",
                            Regex.Replace(writerMock.MessageString, @"\r\n?|\n", ""));
        }
        // writer \wo Moq
        [TestMethod]
        public void ReturnString_WhenCommandIsGiven()
        {
            //Arrange
            IList<IStudent> studentList = new List<IStudent>();
            IList<ISeason> seasonList = new List<ISeason>();
            ISeason season = new Season(2016, 2017, Initiative.CoderDojo);
            Mock<IParser> parserMock = new Mock<IParser>();
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommand> commandToExecute = new Mock<ICommand>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            seasonList.Add(season);

            commandToExecute.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("Student with ID 0 was created");
            parserMock.Setup<IList<string>>(x => x.ParseParameters(It.IsAny<string>())).Returns(new List<string>());
            parserMock
                .Setup<ICommand>(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(commandToExecute.Object);
            readerMock.SetupSequence(x => x.ReadLine()).Returns("AddStudentToSeason Pesho 0").Returns("Exit");
            dbMock.Setup<IList<IStudent>>(x => x.Students).Returns(studentList);
            dbMock.Setup<IList<ISeason>>(x => x.Seasons).Returns(seasonList);

            MockWriter writerMock = new MockWriter();

            IEngine engine = new Engine(readerMock.Object, writerMock, parserMock.Object, dbMock.Object, commandFactoryMock.Object);
            
            //Act
            engine.Start();

            //Assert
            Assert.AreEqual("Student with ID 0 was created",
                            Regex.Replace(writerMock.MessageString, @"\r\n?|\n", ""));
        }

        // writer \w Moq
        [TestMethod]
        public void ReturnString_WhenCommandIsGivenRevision()
        {
            //Arrange
            IList<IStudent> studentList = new List<IStudent>();
            IList<ISeason> seasonList = new List<ISeason>();
            ISeason season = new Season(2016, 2017, Initiative.CoderDojo);
            Mock<IParser> parserMock = new Mock<IParser>();
            Mock<IReader> readerMock = new Mock<IReader>();
            Mock<IDatabase> dbMock = new Mock<IDatabase>();
            Mock<ICommand> commandToExecute = new Mock<ICommand>();
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            seasonList.Add(season);

            commandToExecute.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns("Student with ID 0 was created");
            parserMock.Setup<IList<string>>(x => x.ParseParameters(It.IsAny<string>())).Returns(new List<string>());
            parserMock
                .Setup<ICommand>(x => x.ParseCommand(It.IsAny<string>()))
                .Returns(commandToExecute.Object);
            readerMock.SetupSequence(x => x.ReadLine()).Returns("AddStudentToSeason Pesho 0").Returns("Exit");
            dbMock.Setup<IList<IStudent>>(x => x.Students).Returns(studentList);
            dbMock.Setup<IList<ISeason>>(x => x.Seasons).Returns(seasonList);

            Mock<IWriter> writerMock = new Mock<IWriter>();

            IEngine engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, dbMock.Object, commandFactoryMock.Object);

            //Act
            engine.Start();

            //Assert
            writerMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
        }

    }
}
