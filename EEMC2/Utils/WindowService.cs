using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EEMC2.Utils
{
    public class WindowService
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public void OpenUserControl(Type userControlType, Type userControlVMType)
        {
            object userControlVMInstance = _serviceProvider.GetRequiredService(userControlVMType);

            OpenUserControl(userControlType, userControlVMInstance);
        }

        public void OpenUserControl(Type userControlType, object userControlVMInstance)
        {
            ContentControl userControlInstance = (ContentControl)Activator.CreateInstance(userControlType);

            Window window = new Window
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Title = "Добавление курса",
                Content = userControlInstance,
                DataContext = userControlVMInstance
            };

            window.Show();
        }
    }
}
