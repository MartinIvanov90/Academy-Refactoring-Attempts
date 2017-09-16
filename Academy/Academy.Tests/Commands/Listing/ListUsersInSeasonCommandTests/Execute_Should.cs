using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        private delegate string ExecuteCommand(List<string> input);

        [TestMethod]
        public void ListUsersInSeason_WhenHasNone()
        {
            //Arrange
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();
            var newSeason = new Season(2016, 2016, Initiative.CoderDojo);
            
            //IList<IStudent> studentList
            IList<ISeason> seasonList = new List<ISeason>();
            seasonList.Add(newSeason);
            dbMock.SetupGet<IList<ISeason>>(x => x.Seasons).Returns(seasonList);

            var listUsers = new ListUsersInSeasonCommand(factoryMock.Object, dbMock.Object);
            //Act 
            var listUsersCommandExecutionResults = listUsers.Execute(new List<string>() { "0" });
            //Assert
            Assert.AreEqual($"There are no users in this season!", listUsersCommandExecutionResults);
        }
        [TestMethod]
        public void ListUsersInSeason_WhenUsersExist()
        {
            //Arrange
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();
            var newSeason = new Season(2016, 2016, Initiative.CoderDojo);
            var newTrainer = new Trainer("Mincho", new List<string>());
            var newStudent = new Student("ICHI", Track.Dev);

            //IList<IStudent> studentList
            newSeason.Students.Add(newStudent);
            newSeason.Trainers.Add(newTrainer);
            IList<ISeason> seasonList = new List<ISeason>();
            seasonList.Add(newSeason);
            dbMock.SetupGet<IList<ISeason>>(x => x.Seasons).Returns(seasonList);

            var listUsers = new ListUsersInSeasonCommand(factoryMock.Object, dbMock.Object);
            //Act
            var listUsersCommandExecutionResults = listUsers.Execute(new List<string>() { "0" });
            //Assert
            Assert.AreEqual($"{newTrainer}{Environment.NewLine}{newStudent}", listUsersCommandExecutionResults);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowArgumentOutOfRange_WhenNotEnoughParametersAreGiven()
        {
            //Arrange
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IAcademyFactory>();
            var listUsers = new ListUsersInSeasonCommand(factoryMock.Object, dbMock.Object);
            //Act 
            ExecuteCommand command = new ExecuteCommand(listUsers.Execute);
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command(new List<string>() {}));
        }
    }
}
