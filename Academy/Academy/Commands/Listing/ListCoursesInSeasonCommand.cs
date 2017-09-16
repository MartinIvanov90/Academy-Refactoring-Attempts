using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListCoursesInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IDatabase db;

        public ListCoursesInSeasonCommand(IAcademyFactory factory, IDatabase db)
        {
            this.factory = factory;
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.db.Seasons[int.Parse(seasonId)];

            return season.ListCourses();
        }
    }
}
