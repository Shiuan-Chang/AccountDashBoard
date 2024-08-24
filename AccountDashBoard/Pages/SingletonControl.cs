using AccountDashBoard.Component;
using AccountDashBoard.Mpdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountDashBoard.Pages
{
    class SingletonControl
    {
        // 獨體模式1：static 可以控制共用同一個instace，而不是一直new一個instance出來
        private static Window? currentWindow = null;
        private static Dictionary<WindowType,Window>tempWindow = new Dictionary<WindowType, Window>();

        //獨體模式2:透過建立class，控管使用時只有一個instance
        public static Window? CreateWindow(WindowType windowName) 
        {
            if(currentWindow != null) 
            {
                currentWindow.Close();
            }

            if (!tempWindow.TryGetValue(windowName, out currentWindow))
            {
                string typeName = $"AccountDashBoard.Pages.{windowName}";
                Type? t = Type.GetType(typeName);
                if (t != null && Activator.CreateInstance(t) is Window window)
                {
                    tempWindow[windowName] = window;
                    currentWindow = window;
                }
            }

            currentWindow?.Show();  // 确保窗口显示
            return currentWindow;

        }

        public static string CurrentFormType()
        {
            if (currentWindow != null)
            {
                return currentWindow.GetType().Name;
            }
            return null;
        }

    }
}
