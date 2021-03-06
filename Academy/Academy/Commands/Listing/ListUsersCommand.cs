﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase db;

        public ListUsersCommand(IAcademyFactory factory, IDatabase db)
        {
            this.factory = factory;
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var trainers = this.db.Trainers;
            var students = this.db.Students;

            if (trainers.Any())
            {
                foreach (var trainer in trainers)
                {
                    builder.AppendLine(trainer.ToString());
                }
            }

            if (students.Any())
            {
                foreach (var student in students)
                {
                    builder.AppendLine(student.ToString());
                }
            }

            if (builder.ToString().Equals(""))
            {
                return "There are no registered users!";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
