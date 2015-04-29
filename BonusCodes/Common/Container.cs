using BonusCodes.Services;
using LightInject;

namespace BonusCodes.Common
{
    public static class Container
    {
        private static ServiceContainer container;

        static Container()
        {
            InitializeContainer();
        }

        private static void InitializeContainer()
        {
            container = new ServiceContainer();
            container.Register<IBonusCodesService, BonusCodesService>(new PerContainerLifetime());

            container.BeginScope();
        }

        public static ServiceContainer GetContainer()
        {
            return container;
        }
    }
}