using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DepositMenu.xaml
    /// </summary>
    public partial class DepositMenu : Window
    {
        public DepositMenu()
        {
            InitializeComponent();
        }

        const string sPath = "C:/Users/User/Documents/ATM_Data/Money.txt"; // Save path for money
        const string sPath1 = "C:/Users/User/Documents/ATM_Data/PreviousTransactions.txt"; // Save path for money


        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void BckMM_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Close();
            mainMenu.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
      
        private void AmountD_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            AmountD.MaxLength = 4;
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            if (AmountD.Text != "")
            {
                int i = Int16.Parse(AmountD.Text.ToString());

                if (i < 1001)
                {
                    BalanceMenu menu = new BalanceMenu();
                    string money = menu.Balance.Text.Trim(new Char[] { '$' });
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);  // create streamwriter variable SaveFile with the sPath
                    System.IO.StreamWriter saveFile = new System.IO.StreamWriter(sPath1, true);  // create streamwriter variable SaveFile with the sPath1
                    string deposit = $"Deposited {i}$";

                    if (AmountD.Text != "")
                    {
                        if (menu.Balance.Text != "")
                        {
                            SaveFile.WriteLine(Int32.Parse(money) + Int32.Parse(AmountD.Text)); // Save money amount to text file
                            SaveFile.Close();
                            saveFile.WriteLine(deposit);
                            saveFile.Close();

                        }
                        else
                        {
                            SaveFile.WriteLine(Int32.Parse(AmountD.Text)); // Save money amount to text file
                            SaveFile.Close();
                            saveFile.WriteLine(deposit);
                            saveFile.Close();
                        }
                    }

                    Action action = new Action();
                    Close();
                    action.Show();

                }
                else if (i >= 1001)
                {
                    Rect1.Visibility = Visibility.Visible;
                    Invalid.Visibility = Visibility.Visible;
                }
            }
          
        }

        private void AmountD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Deposit_Click(this, new RoutedEventArgs());
            }
        }
    }
}
