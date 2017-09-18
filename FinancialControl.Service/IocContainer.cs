using FinancialControl.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using ServiceStack.Configuration;

namespace FinancialControl.Service
{
    public interface IIocContainer
    {
        IBindingToSyntax<T> Bind<T>();
    }

    public class IocContainer : NinjectModule, IIocContainer, IContainerAdapter
    {
        private readonly IKernel _kernel;

        public IocContainer(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public T TryResolve<T>()
        {
            return _kernel.CanResolve<T>() ? _kernel.Get<T>() : default(T);
        }

        public override void Load()
        {
            _kernel.Bind<IDataAccessProxy>().To<DatabaseProxy>();
        }
    }
}