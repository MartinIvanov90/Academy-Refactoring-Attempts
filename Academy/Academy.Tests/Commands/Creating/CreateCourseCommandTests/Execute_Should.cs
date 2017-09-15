using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Commands.Creating.CreateCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateCourseAndReturnString_WhenProperArgumentsAreGiven()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var newSeason = new Season(2016, 2016, Initiative.CoderDojo);
            var newCourse = new Course("BostanTeshkarlyk", 7, new DateTime(2017, 01, 24), new DateTime(2017, 07, 24));
            newSeason.Courses.Add(newCourse);
            IList <ISeason> seasonList = new List<ISeason>();
            IList<ICourse> courseList = new List<ICourse>();
            seasonList.Add(newSeason);
            engineMock.SetupGet<IList<ISeason>>(x => x.Seasons).Returns(seasonList);

            var createCommand = new CreateCourseCommand(factoryMock.Object, engineMock.Object);
            //Act & Assert 0
            Assert.AreEqual($"Course with ID {newSeason.Courses.Count} was created in Season 0.", createCommand.Execute(new List<string>() { "0", "JavaScriptOOP", "2", "2017-01-24" }));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowArgumentOutOfRange_WhenNotEnoughParametersAreGiven()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var createCommand = new CreateCourseCommand(factoryMock.Object, engineMock.Object);
            //Act & Assert 
            var result = createCommand.Execute(new List<string>() { "0", "JavaScriptOOP", "2"});
        }
    }
}
