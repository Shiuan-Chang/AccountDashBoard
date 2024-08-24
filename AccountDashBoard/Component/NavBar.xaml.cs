using AccountDashBoard.Mpdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using AccountDashBoard.Pages;

namespace AccountDashBoard.Component
{
    /// <summary>
    /// NavBar.xaml 的互動邏輯
    /// </summary>
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
            this.Loaded += NavBar_Load;
        }

        //private void ChangePage(object sender, EventArgs e)
        //{
        //    Button clickedButton = sender as Button;
        //    Enum.TryParse(clickedButton.Tag.ToString(), out PageType page);


        //}

        private void ChangePage(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Enum.TryParse(clickedButton?.Tag.ToString(), out WindowType window);
            Window ?currentWindow = SingletonControl.CreateWindow(window);
            currentWindow?.Show();
        }

        private void NavBar_Load(object sender, EventArgs e)
        {
            var PageTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t=> t.IsSubclassOf(typeof(Window)));
            int count =0;
            foreach (var pageType in PageTypes)
            {
                if (pageType.Name != "MainWindow") 
                {
                    count++;
                    string basePath = "C:\\CSharp練習\\記帳系統練習\\AccountDashBoard\\AccountDashBoard\\AccountDashBoard\\";
                    string imagePath = System.IO.Path.Combine(basePath, "Resources", "Images", pageType.Name + ".png");

                    Image image = new Image
                    {
                        Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                        Width = 20,
                        Height = 20,
                        Stretch = Stretch.Fill
                    };
                    Button button = new Button
                    {
                        Content = image,
                        Tag = pageType.Name,
                        Margin = new Thickness(5),
                        BorderBrush = Brushes.Transparent,
                        Background = new SolidColorBrush(Colors.Transparent),
                    };
                    button.Click += ChangePage;
                    buttonPanel.Children.Add(button);
                }               
            }
        }
        public void DisableButton(WindowType windowTypeName)
        {
            foreach (Button button in buttonPanel.Children.OfType<Button>())
            {
                if (button.Tag is WindowType tag && tag == windowTypeName)
                {
                    button.IsEnabled = false;
                }
            }
        }
    }
}
