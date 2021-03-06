﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System;

namespace Academy.Commands.Creating
{
    public class CreateCourseCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase db;

        public CreateCourseCommand(IAcademyFactory factory, IDatabase db)
        {
            this.factory = factory;
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            if(parameters.Count != 4)
            {
                throw new ArgumentOutOfRangeException("Not enough parameters for this command!");
            }
            var seasonId = parameters[0];
            var name = parameters[1];
            var lecturesPerWeek = parameters[2];
            var startingDate = parameters[3];

            var season = this.db.Seasons[int.Parse(seasonId)];
            var course = this.factory.CreateCourse(name, lecturesPerWeek, startingDate);
            season.Courses.Add(course);

            return $"Course with ID {season.Courses.Count - 1} was created in Season {seasonId}.";
        }
    }
}
