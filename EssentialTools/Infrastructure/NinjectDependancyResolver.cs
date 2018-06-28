using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using EssentialTools.Models;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependancyResolver : IDependencyResolver
    {
        private IKernel ikernel;
        public NinjectDependancyResolver(IKernel ikernelPara)
        {
            ikernel = ikernelPara;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return ikernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ikernel.GetAll(serviceType);
        }
        public void AddBindings()
        {
            ikernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
}