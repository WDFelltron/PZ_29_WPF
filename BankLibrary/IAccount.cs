using System;


namespace BankLibrary
{
    public interface IAccount
    {
        void Put(decimal sum);
        decimal Withdraw(decimal sum);
        // опишите метод пополнения счета – void Put(decimal sum)
        // опишите метод снятия со счета – decimal Withdraw(decimal sum)
    }
}
