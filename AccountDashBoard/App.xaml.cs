using AccountDashBoard.Mpdels;
using AccountDashBoard.Pages;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AccountDashBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // 使用 SingletonControl 创建并显示主窗口
            SingletonControl.CreateWindow(WindowType.Account);  // 假设您有一个名为 MainWindow 的枚举值
        }
    }

}
