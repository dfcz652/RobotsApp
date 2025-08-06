using Microsoft.Extensions.DependencyInjection;
using RobotApp.Services;
using RobotViewModels.Formatters;
using RobotViewModels.Interfaces;

namespace RobotViewModels
{
    public static class DependencyInjection
    {
        public static IServiceProvider CreateProvider()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IRobotsGateway, RobotsGatewayInMemory>();
            container.AddSingleton<IItemComparisonService, ItemComparisonReportService>();
            container.AddSingleton<IRobotsComparisonFormatter, ReportFormatter>();
            container.AddSingleton<ViewModel>();

            return container.BuildServiceProvider();
        }
    }
}
