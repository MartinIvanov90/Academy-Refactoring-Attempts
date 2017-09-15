using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Commands.Logger;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Ninject;
using Ninject.Modules;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");

            this.Bind<ICommand>().To<CreateCourseCommand>().Named("InternalCreateCourse");
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("InternalCreateCourseResult");
            this.Bind<ICommand>().To<CreateLectureCommand>().Named("InternalCreateLecture");
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named("InternalCreateSeason");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("InternalCreateStudent");
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named("InternalCreateTrainer");

            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateCourse")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourse"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());
            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateCourseResult")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateCourseResult"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());
            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateLecture")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateLecture"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());
            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateSeason")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateSeason"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());
            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateStudent")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateStudent"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());
            this.Bind<ICommand>().To<CreateLoggerDecorator>()
                .Named("CreateTrainer")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalCreateTrainer"))
                .WithConstructorArgument(this.Kernel.Get<IWriter>());



            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");

        }
    }
}
