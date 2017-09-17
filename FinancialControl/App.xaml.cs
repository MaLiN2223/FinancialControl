using System.Configuration;
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
            var apiUrl = ConfigurationManager.AppSettings["restService"];
            var window = new MainWindow(apiUrl);
            window.Show();
        }

    }
}
