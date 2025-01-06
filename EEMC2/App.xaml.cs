using EEMC2.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace EEMC2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocator.Init();

            base.OnStartup(e);
        }
    }

}
