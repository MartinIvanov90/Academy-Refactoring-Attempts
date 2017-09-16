using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly ICommandFactory commandFactory;


        public Engine(IReader reader, IWriter writer, IParser parser,ICommandFactory commandFactory)
        {

            this.reader = reader ?? throw new ArgumentNullException("reader went wrong! cant be null!");
            this.writer = writer ?? throw new ArgumentNullException("writer went wrong! cant be null!");
            this.parser = parser ?? throw new ArgumentNullException("parser went wrong! cant be null!");
            this.commandFactory = commandFactory ?? throw new ArgumentNullException("command factory went wrong! cant be null!");

        }



        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            //var command = this.parser.ParseCommand(commandAsString,this);
            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.builder.AppendLine(executionResult);
        }
    }
}
