using FinancialControl.Repositories;
using Ninject.Modules;
using Ninject.Syntax;
using Utils;

namespace FinancialControl.Service
{
    public interface IIocContainer
    {
        IBindingToSyntax<T> Bind<T>();
    }
    public class IocContainer : NinjectModule, IIocContainer
    {
        public override void Load()
        {
            Bind<IIocContainer>().To<IocContainer>();
            Bind<ILogger>().To<Logger>();
            Bind<ISerializer>().To<Serializer>();
            Bind<IPathRepository>().To<PathRepository>();
            Bind<ICategoriesRepository>().To<CategoriesRepository>();
            Bind<IDataAccessProxy>().To<DatabaseProxy>();
        }


    }

}

