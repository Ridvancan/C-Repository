using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Buisness.DependencyResolver.Ninject
{
   public  class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BuisnessModule());
            return kernel.Get<T>();
        }
    }
}
