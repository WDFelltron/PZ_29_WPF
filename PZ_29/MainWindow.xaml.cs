using System;
using System.Collections.Generic;
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
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using BankLibrary;

namespace PZ_29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank<Account> bank = new Bank<Account>("ЮнитБанк");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenAccount(bank);
            bank.CalculatePercentage();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Withdraw(bank);
            bank.CalculatePercentage();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Put(bank);
            bank.CalculatePercentage();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CloseAccount(bank);
            bank.CalculatePercentage();
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            bank.CalculatePercentage();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            bank.CalculatePercentage();
        }
        private void OpenAccount(Bank<Account> bank)
        {
            Output.Text = "Укажите сумму для создания счета:";
            decimal sum = Convert.ToDecimal(Input.Text);
            Output.Text = "Введите тип счета: 'До востребования' или 'Депозит'";
            AccountType accountType;
            string type = Input.Text;
            if (type == "До востребования")
            {
                accountType = AccountType.Deposit;
                bank.Open(accountType,
                sum,
                AddSumHandler, // обработчик добавления средств на счет
                WithdrawSumHandler, // обработчик вывода средств
                (o, e) => Output.Text = e.Message, // обработчик начислений процентов в виде лямбдавыражения
                CloseAccountHandler, // обработчик закрытия счета
                OpenAccountHandler); // обработчик открытия счета
            }
            else if (type == "Депозит")
            {
                accountType = AccountType.Ordinary;
                bank.Open(accountType,
            sum,
            AddSumHandler, // обработчик добавления средств на счет
            WithdrawSumHandler, // обработчик вывода средств
            (o, e) => Output.Text = e.Message, // обработчик начислений процентов в виде лямбдавыражения
            CloseAccountHandler, // обработчик закрытия счета
            OpenAccountHandler); // обработчик открытия счета
            }

        }
        private void Withdraw(Bank<Account> bank)
        {
            Output.Text = "Укажите сумму для вывода со счета:";
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Output.Text = "Введите id счета:";
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Withdraw(sum, id);
        }
        private void Put(Bank<Account> bank)
        {
            Output.Text = "Укажите сумму, чтобы положить на счет:";
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Output.Text = "Введите Id счета:";
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Put(sum, id);
        }
        private void CloseAccount(Bank<Account> bank)
        {
            Output.Text = "Введите id счета, который надо закрыть:";
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Close(id);
        }
        // обработчики событий класса Account
        // обработчик открытия счета
        private void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Output.Text = e.Message;
        }
        // обработчик добавления денег на счет
        private void AddSumHandler(object sender, AccountEventArgs e)
        {
            Output.Text = e.Message;
        }
        // обработчик вывода средств
        private void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Output.Text = e.Message;
            if (e.Sum > 0)
                Output.Text = "Идем тратить деньги";
        }
        // обработчик закрытия счета
        private void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Output.Text = e.Message;
        }
    }
}
