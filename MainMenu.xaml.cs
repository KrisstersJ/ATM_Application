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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace ATM_Application
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {

        public int money = 100;

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        const string sPath = "C:/Users/User/Documents/ATM_Data/Money.txt"; // Save path for money
        const string sPath1 = "C:/Users/User/Documents/ATM_Data/PreviousTransactions.txt"; // Save path for transactions

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            WithdrawMenu withdrawMenu = new WithdrawMenu();
            Visibility = Visibility.Hidden;
            withdrawMenu.Show();
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            BalanceMenu balanceMenu = new BalanceMenu();
            Visibility = Visibility.Hidden;
            balanceMenu.Show();
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            DepositMenu depositMenu = new DepositMenu();
            Visibility = Visibility.Hidden;
            depositMenu.Show();
        }

        private void Transactions_Click(object sender, RoutedEventArgs e)
        {
            PreviousTransactionsMenu previousTransactionsMenu = new PreviousTransactionsMenu();
            Visibility = Visibility.Hidden;
            previousTransactionsMenu.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void _10D_Click(object sender, RoutedEventArgs e)
        {                        
            BalanceMenu menu = new BalanceMenu();
            string money = menu.Balance.Text.Trim(new Char[] { '$' });

            if (Int32.Parse(money) >= 10)
            {

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);  // create streamwriter variable SaveFile with the sPath
                System.IO.StreamWriter saveFile = new System.IO.StreamWriter(sPath1, true);  // create streamwriter variable SaveFile with the sPath
                string Withdrawal = "Withdrew 10$";

                if (menu.Balance.Text != "")
                {
                    SaveFile.WriteLine(Int32.Parse(money) - 10); // Save money amount to text file
                    SaveFile.Close();
                    saveFile.WriteLine(Withdrawal);
                    saveFile.Close();
                }

                Action action = new Action();
                Close();
                action.Show();

            }
            else if (Int32.Parse(money) <= 10)
            {
                ActionN actionN = new ActionN();
                Close();
                actionN.Show();
            }
        }

        private void _20D_Click(object sender, RoutedEventArgs e)
        {
            BalanceMenu menu = new BalanceMenu();
            string money = menu.Balance.Text.Trim(new Char[] { '$' });

            if (Int32.Parse(money) >= 20)
            {

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);  // create streamwriter variable SaveFile with the sPath
                System.IO.StreamWriter saveFile = new System.IO.StreamWriter(sPath1, true);  // create streamwriter variable SaveFile with the sPath1
                string Withdrawal = "Withdrew 20$";

                if (menu.Balance.Text != "")
                {
                    SaveFile.WriteLine(Int32.Parse(money) - 20); // Save money amount to text file
                    SaveFile.Close();
                    saveFile.WriteLine(Withdrawal);
                    saveFile.Close();
                }

                Action action = new Action();
                Close();
                action.Show();

            }
            else if (Int32.Parse(money) <= 20)
            {
                ActionN actionN = new ActionN();
                Close();
                actionN.Show();
            }
        }

        private void _50D_Click(object sender, RoutedEventArgs e)
        {
            BalanceMenu menu = new BalanceMenu();
            string money = menu.Balance.Text.Trim(new Char[] { '$' });

            if (Int32.Parse(money) >= 50)
            {

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);  // create streamwriter variable SaveFile with the sPath
                System.IO.StreamWriter saveFile = new System.IO.StreamWriter(sPath1, true);  // create streamwriter variable SaveFile with the sPath1
                string Withdrawal = "Withdrew 50$";

                if (menu.Balance.Text != "")
                {
                    SaveFile.WriteLine(Int32.Parse(money) - 50); // Save money amount to text file
                    SaveFile.Close();
                    saveFile.WriteLine(Withdrawal);
                    saveFile.Close();
                }

                Action action = new Action();
                Close();
                action.Show();

            }
            else if (Int32.Parse(money) <= 50)
            {
                ActionN actionN = new ActionN();
                Close();
                actionN.Show();
            }
        }
    }
}
