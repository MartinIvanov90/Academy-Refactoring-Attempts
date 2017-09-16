using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase db;

        public ListUsersInSeasonCommand(IAcademyFactory factory, IDatabase db)
        {
            this.factory = factory;
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            if(parameters.Count != 1)
            {
                throw new ArgumentOutOfRangeException("you have to pick a season");
            }
            var seasonId = parameters[0];
            var season = this.db.Seasons[int.Parse(seasonId)];

            return season.ListUsers();
        }
    }
}
