using Microsoft.Extensions.DependencyInjection;
using RobotAppUIWinForms;
using RobotViewModels;

namespace RobotAppWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var provider = DependencyInjection.CreateProvider();
            var viewModel = provider.GetRequiredService<ViewModel>();

            ApplicationConfiguration.Initialize();
            Application.Run(new StartScreenForm(viewModel));
        }
    }
}