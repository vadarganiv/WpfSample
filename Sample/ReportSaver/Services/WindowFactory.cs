using System.Windows;
using Ninject;

namespace ReportSaver.Services
{
    public class WindowFactory
    {
        private readonly IKernel _kernel;
        public WindowFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T GetInstance<T>() where T : Window
        {
           return _kernel.Resolve<T>();
        }
    }
}
