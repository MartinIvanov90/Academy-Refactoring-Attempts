using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Commands.Contracts;
using Ninject;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand ReturnCommand(string command)
        {
            return this.kernel.Get<ICommand>(command);
        }
    }
}
