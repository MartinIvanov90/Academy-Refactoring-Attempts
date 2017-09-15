using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Core.Providers
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.Seasons = new List<ISeason>();
            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons { get; private set; }

        public IList<IStudent> Students { get; private set; }

        public IList<ITrainer> Trainers { get; private set; }
    }
}
