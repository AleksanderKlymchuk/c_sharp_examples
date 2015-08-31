using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using WebApi.Infrastructure;

namespace WebApi
{
    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {

            return new NinjectScope(kernel.BeginBlock());
        }

    }
}
