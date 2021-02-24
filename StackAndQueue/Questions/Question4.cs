using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace StackAndQueue.Questions
{
    class Buyer
    {
        private readonly string name;
        private int cartList;


        public string Name => name;
        public int CurrCartList { get => cartList; set => cartList = value; }


        //return success confirmation
        public bool PurchaseConfirmation()
        {
            CurrCartList = 0;
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Buyer buyer &&
                   name == buyer.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }

        public Buyer(string name, int cartList = 0)
        {
            this.name = name;
            CurrCartList = cartList;
        }
    }

    class Сashier
    {
        public Queue<Buyer> Byuers = new();
        private int chashierNumber;
        private readonly int AVG_Time_To_Service_One_Purchase_SECONDS;

        public int ChashierNumber { get => chashierNumber; set => chashierNumber = value; }
        public int GetQueueStat { get => Byuers.Count; }

        public void AddNewByuer(Buyer buyer)
        {
            Byuers.Enqueue(buyer);
            Console.WriteLine($"Cashier number {chashierNumber} added enqueue {buyer.Name}(Products:{buyer.CurrCartList}). Total Queue is {GetQueueStat}.");
            _ = Task.Run(() =>
            {
                //need add cancellationtoken if you need an option so that the buyer can leave the queue on their own ^_^
                while (Byuers.Peek() != buyer)
                    Thread.Sleep(500);

                Buyer CurrentBuyer = Byuers.Peek();
                Thread.Sleep((CurrentBuyer.CurrCartList * AVG_Time_To_Service_One_Purchase_SECONDS * 1000) + new Random().Next(1, 5) * 500);
                RemoveByuer();
            });
        }

        public void RemoveByuer()
        {
            Buyer CurrentBuyer = Byuers.Peek();
            Console.Write($"Cashier number {chashierNumber} served {CurrentBuyer.Name}.");
            Byuers.Dequeue();
            CurrentBuyer.PurchaseConfirmation();
            Console.WriteLine($"Total Queue is { GetQueueStat }.");
        }

        public Сashier(int ChashierNumber, int AVG_Time_To_Service_One_Purchase_SECONDS)
        {
            this.ChashierNumber = ChashierNumber;
            this.AVG_Time_To_Service_One_Purchase_SECONDS = AVG_Time_To_Service_One_Purchase_SECONDS;
        }
    }


    class Question4
    {
        internal void Init()
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);
            Сashier сashierFirst = new Сashier(1, 1);
            Сashier сashierSecond = new Сashier(2, 2);

            сashierFirst.AddNewByuer(new Buyer("Yurii", 3));
            сashierFirst.AddNewByuer(new Buyer("Ann", 2));

            сashierSecond.AddNewByuer(new Buyer("Nikola", 3));

            сashierFirst.AddNewByuer(new Buyer("Vasiliy", 6));
            сashierFirst.AddNewByuer(new Buyer("Nina", 1));

            сashierSecond.AddNewByuer(new Buyer("Nazarii", 2));
            сashierSecond.AddNewByuer(new Buyer("Larisa", 4));

            сashierFirst.AddNewByuer(new Buyer("Alex", 3));
            Console.ReadKey();
        }
    }
}
