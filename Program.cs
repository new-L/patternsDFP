using System;

namespace ShieldDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Реализация Декоратор
            //Shield shield = new WoodenShield();
            //Console.WriteLine(shield.TypeShield);
            //shield = new LeatherEdging(shield);
            //Console.WriteLine(shield.TypeShield);
            //shield = new MetalRivet(shield);
            //Console.WriteLine(shield.TypeShield);
            #endregion

            #region Реализация Фасад
            //ATM m_Atm = new ATM();
            //ProcessingCenter m_PCenter = new ProcessingCenter();
            //Bank m_Bank = new Bank();

            //CashOut cashOut = new CashOut(m_Atm, m_PCenter, m_Bank);

            //Client client = new Client();
            //Console.Write("Сумма для вывода: ");
            //int cash = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            //client.Withdraw(cashOut, cash);
            #endregion

            #region Реализация Прокси
            Console.Write("Сумма для вывода: ");
            int cash = Convert.ToInt32(Console.ReadLine());
            Bank subject = new ATM();
            subject.Withdraw(cash);
            #endregion

            Console.ReadKey();
        }

        #region Декоратор
        //base class
        public abstract class Shield
        {
            public string TypeShield { get; set; }

            public Shield(string name)
            {
                TypeShield = name;
            }
        }


        //Обертка(декоратор)
        public class ShieldDecorator : Shield
        {
            protected Shield _shield;
            public ShieldDecorator(string name, Shield shield) : base(name)
            {
                _shield = shield;
            }
        }

        //Конкретная реализация
        public class WoodenShield : Shield
        {
            public WoodenShield() : base("Деревянный щит") { }
        }


        #region Модификации
        //Модификация(новый функционал)
        public class LeatherEdging : ShieldDecorator
        {
            public LeatherEdging(Shield shield) : base(shield.TypeShield + " с кожанной окантовкой", shield) { }
        }

        //Модификация(новый функционал)
        public class MetalRivet : ShieldDecorator
        {
            public MetalRivet(Shield shield) : base(shield.TypeShield + " с металическими заклепками", shield) { }
        }
        #endregion
        #endregion


        //#region Фасад
        //public class ATM
        //{ 
        //    public void CashWithdrawal(int cash)
        //    {
        //        Console.WriteLine($"Вывод: {cash} рублей. Пожалуйста, заберите денежные средства!");
        //    }
        //}


        //public class ProcessingCenter
        //{
        //    public void VerifyCard()
        //    {
        //        Console.WriteLine("[Карта верифицирована]");
        //    }
        //}

        //public class Bank
        //{
        //    public void VerifyUser()
        //    {
        //        Console.WriteLine($"[Пользователь с номером карты идентифицирован]");
        //    }

        //    public bool CheckBalance()
        //    {
        //        return true;
        //    }
        //}


        //public class Client
        //{
        //    public void Withdraw(CashOut m_CashOut, int cash)
        //    {
        //        m_CashOut.StartCashWithdraw(cash);
        //    }
        //}

        ////Фасад
        //public class CashOut
        //{
        //    private ATM m_Atm;
        //    private ProcessingCenter m_PCenter;
        //    private Bank m_Bank;

        //    public CashOut(ATM atm, ProcessingCenter pCenter, Bank bank)
        //    {
        //        m_Atm = atm;
        //        m_PCenter = pCenter;
        //        m_Bank = bank;
        //    }
        //    public void StartCashWithdraw(int cash)
        //    {
        //        m_PCenter.VerifyCard();
        //        m_Bank.VerifyUser();
        //        if(m_Bank.CheckBalance()) m_Atm.CashWithdrawal(cash);
        //    }
        //}
        //#endregion


        #region Прокси(Заместитель)
        
        //Subject
        public abstract class Bank
        {
            public abstract void Withdraw(int cash);
        }

        //Real Subject
        public class BankOffice : Bank
        {
            public override void Withdraw(int cash)
            {
                Console.WriteLine($"Вывод: {cash} рублей. Пожалуйста, заберите денежные средства!");
            }
        }
        //Proxy
        public class ATM : Bank
        {
            BankOffice realSubject;
            public override void Withdraw(int cash)
            {
                if (realSubject == null)
                    realSubject = new BankOffice();
                realSubject.Withdraw(cash);
            }
        }
        public class Client
        {
            public void Main()
            {
                Bank subject = new ATM();
                subject.Withdraw(10);
            }
        }
        #endregion

    }
}
