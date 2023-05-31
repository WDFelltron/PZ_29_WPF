using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    public class AccountEventArgs
    {
        public string Message { get; set; }
        public decimal Sum { get; private set; }


        // создайте автосвойство сообщения (Message)
        // определите автосвойство суммы (Sum), на которую изменился счет, 
        // причем блок set сделайте приватным, для того чтобы внешний код не 
        // мог менять данную сумму.

        // определите конструктор класса, инициирующий Message и Sum
        public AccountEventArgs(string a, decimal b)
        {
            Message = a;
            Sum = b;
        }
    }
}
