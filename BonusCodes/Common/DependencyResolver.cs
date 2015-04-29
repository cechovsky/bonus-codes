using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace BonusCodes.Common
{
    public class DependencyResolver : IDependencyResolver
    {
        public void Dispose()
        {
            Container.GetContainer().Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.GetContainer().GetInstance(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.GetContainer().GetAllInstances(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IDependencyScope BeginScope()
        {
            Container.GetContainer().BeginScope();
            return new DependencyResolver();
        }
    }
}