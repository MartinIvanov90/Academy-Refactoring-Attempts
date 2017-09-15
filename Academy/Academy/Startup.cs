using Academy.Core;
using Academy.Core.Contracts;
using Academy.Ninject;
using Ninject;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // Singleton design pattern
            // Ensures that there is only one instance of Engine in existance
            //var engine = Engine.Instance;
            //engine.Start();
            IKernel kernel = new StandardKernel(new AcademyModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
