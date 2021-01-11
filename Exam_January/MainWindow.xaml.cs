using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// Name: Andrew Casey
/// Student ID S00200841
/// Class Games Development
/// GitHub : https://github.com/s00200841/Exam_January
/// i doubt i will come close to finished in 2 hrs, will see!!
/// got as far as adding Deposit and Withdraw 
/// couldnt get withdraw done in time, have to finish and upload now
/// realy needed 3 hrs but done what i could 
/// </summary>
namespace Exam_January
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        ObservableCollection<Account> filterAccounts = new ObservableCollection<Account>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Savings Account
            SavingsAccount sAcc1 = new SavingsAccount("Sentinal", "Komton", 50000);
            SavingsAccount sAcc2 = new SavingsAccount("Reginald", "Bloomington", 9000000);

            // Current Account
            CurrentAccount cAcc1 = new CurrentAccount("Poor", "Stevens", 250.30m);
            CurrentAccount cAcc2 = new CurrentAccount("Tom", "Richardson", 5034569);

            accounts.Add(sAcc1);
            accounts.Add(sAcc2);
            accounts.Add(cAcc1);
            accounts.Add(cAcc2);

            lbx_Accounts.ItemsSource = accounts.OrderBy(c => c.LastName);
        }

        private void lbx_Accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account selectedAccount = lbx_Accounts.SelectedItem as Account;

            if(selectedAccount != null)
            {
                tblk_FirstName.Text = selectedAccount.FirstName;
                tblk_LastName.Text = selectedAccount.LastName;
                tblk_Balance.Text = selectedAccount.Balance.ToString();

                foreach(Account account in accounts)
                {
                    if (selectedAccount == account as SavingsAccount)
                    {
                        SavingsAccount selectSavingAccount = lbx_Accounts.SelectedItem as SavingsAccount;
                        tblk_AccountType.Text = "Savings Account";

                    }
                    if (selectedAccount == account as CurrentAccount)
                    {
                        CurrentAccount selectCurrentAccount = lbx_Accounts.SelectedItem as CurrentAccount;
                        tblk_AccountType.Text = "Current Account";
                    }
                }
            }
        }

        private void cbox_Checked(object sender, RoutedEventArgs e)
        {
            bool check = true;
            filterAccounts.Clear();
            lbx_Accounts.ItemsSource = null;

            if (cbox_CurrentAccount.IsChecked == true && cbox_SavingAccount.IsChecked == true)
            {
                lbx_Accounts.ItemsSource = accounts.OrderBy(c => c.LastName);
            }
            else
            {
                if (cbox_CurrentAccount.IsChecked == true)
                {
                    check = true;
                }
                else if (cbox_SavingAccount.IsChecked == true)
                {
                    check = false;
                }

                foreach (Account account in accounts)
                {
                    if (check)
                    {
                        if (account as CurrentAccount != null)
                        {
                            filterAccounts.Add(account);
                        }
                    }
                    if (!check)
                    {
                        if (account as SavingsAccount != null)
                        {
                            filterAccounts.Add(account);
                        }
                    }
                }
                lbx_Accounts.ItemsSource = filterAccounts.OrderBy(c => c.LastName);
            }
        }


        private void btn_Deposit_Clicked(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = lbx_Accounts.SelectedItem as Account;
            string input = tbx_TransactionAmount.Text;
            decimal inputd;
            bool isDecimal = decimal.TryParse(input, out inputd);
            if (isDecimal)
                selectedAccount.Deposit(inputd);
            tblk_Balance.Text = selectedAccount.Balance.ToString();
        }

        private void btn_Withdraw_Clicked(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = lbx_Accounts.SelectedItem as Account;
            string input = tbx_TransactionAmount.Text;
            decimal inputd;
            bool isDecimal = decimal.TryParse(input, out inputd);

            decimal temp = Convert.ToDecimal(tblk_AccountBalance.Text);
            decimal.TryParse(tblk_AccountBalance.Text, out temp);
            if (isDecimal && inputd < temp)
                selectedAccount.Withdraw(inputd);
            tblk_Balance.Text = selectedAccount.Balance.ToString();
        }
    }
}
