using System.Windows;

namespace FinancialControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //  var apiUrl = ConfigurationManager.AppSettings["restService"];
            var initializer = new MapperInitializer();
            initializer.Initialize();

            log4net.Config.XmlConfigurator.Configure();
            var window = new MainWindow();
            window.Show();
        }

    }
}
