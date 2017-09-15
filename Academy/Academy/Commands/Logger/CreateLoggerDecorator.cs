using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Commands.Logger
{
    public class CreateLoggerDecorator : ICommand
    {
        private readonly ICommand commandToDecorate;
        private readonly IWriter writerModule;

        public CreateLoggerDecorator(ICommand commandToDecorate, IWriter writerModule)
        {
            this.commandToDecorate = commandToDecorate;
            this.writerModule = writerModule;
        }

        public string Execute(IList<string> parameters)
        {

            return ">>>"+DateTime.Now.ToString() + "\n" + commandToDecorate.Execute(parameters);

        }
    }
}
