using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FinancialControl.Repositories;
using Ninject;

namespace FinancialControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new Bindings(new IocContainer());
            var kernel = new StandardKernel(container);
            var window = kernel.Get<IMainWindow>();
            window.Show();
        }

    }
}
