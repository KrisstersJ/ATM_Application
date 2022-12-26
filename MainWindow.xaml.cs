using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int i = 2;

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void PIN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {           
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            PIN.MaxLength = 4;
        }

        private void EnterPIN_Click(object sender, RoutedEventArgs e)
        {
            BalanceMenu balanceMenu = new BalanceMenu();

            if (PIN.Text == "1234")
            {          
                MainMenu mainMenu = new MainMenu();
                Close();
                mainMenu.Show();

            }
            else if (i > 0)
            {
                WrongPIN.Visibility = Visibility.Visible;
                Attempts.Text = $"{i} ATTEMPTS LEFT";
                i--;
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void PIN_GotFocus(object sender, RoutedEventArgs e)
        {
            PIN.IsEnabled = false;
            PIN.IsEnabled = true;
        }

        private void PIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnterPIN_Click(this, new RoutedEventArgs());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

    }
}
