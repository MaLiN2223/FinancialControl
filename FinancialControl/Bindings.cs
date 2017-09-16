
using FinancialControl;
using FinancialControl.Repositories;
using Ninject.Modules;
public class Bindings : NinjectModule
{
    private readonly IIocContainer _container;

    public Bindings(IIocContainer container)
    {
        _container = container;
    }

    public override void Load()
    {

        _container.Bind<IMainWindow>().To<MainWindow>();
    }
}