using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATM_Application
{
    /// <summary>
    /// Interaction logic for BalanceMenu.xaml
    /// </summary>
    public partial class BalanceMenu : Window
    {

        public BalanceMenu()
        {
            InitializeComponent();

            using (StreamReader r = new StreamReader(sPath))
            {
                string line;
                while ((line = r.ReadLine()) != null) // while there is text in sPath 
                {
                    Balance.Text = $"{line}$";
                }
            }

        }

        const string sPath = "C:/Users/User/Documents/ATM_Data/Money.txt"; // Save path for money

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void BckMM_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Close();
            mainMenu.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);     

        }

        private void Balance_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
