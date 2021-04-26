using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public BankCart bankCarts { get; set; }

        public void Show()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Bank Cart: {bankCarts}");
        }
    }
    class BankCart
    {
        public string BankName { get; set; }
        public string Username { get; private set; }
        public string PAN { get; private set; }
        public string PIN { get; set; }
        public int CVC { get; private set; }
        public DateTime ExpireTime { get; set; }
        public decimal Balance { get; set; }

        public void Settings(Client a)
        {
            Random ramdom = new Random();
            Username = a.Name + a.Surname;
            int pancon = Username.GetHashCode();
            PAN = Convert.ToString(pancon);
            CVC = ramdom.Next(100, 999);
            Balance = ramdom.Next(100, 100000);
        }

        public void Show()
        {
            Console.WriteLine($"Bank Name: {BankName}");
            Console.WriteLine($"Userame: {Username}");
            Console.WriteLine($"PAN: {PAN}");
            Console.WriteLine($"PIN: {PIN}");
            Console.WriteLine($"CVC: {CVC}");
            Console.WriteLine($"Expire Date: {ExpireTime.Month}/{ExpireTime.Year}");
            Console.WriteLine($"Balance: {Balance}");
        }

    }
    class Bank
    {
        public Client[] Client { get; set; }
        public int CountCart { get; private set; }
        public void AddCart(ref Client cl)
        {
            Client[] temp = new Client[++CountCart];
            if (Client != null)
            {
                Client.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cl;
            Client = temp;
        }

        public void Show()
        {
            foreach (var item in Client)
            {
                item.Show();
            }
        }
        public void CartBalance(BankCart c)
        {
            Console.WriteLine($"Balance: {c.Balance}");
        }
    }
    class Program
    {
        static bool checkingBN(string BN)
        {
            if (BN == "" || BN == " " || BN == null)
            {
                throw new Exception("BANK NAME IS INCORRECT");
            }
            else
            {
                return true;
            }
        }
        static bool checkingPAN(string PAN)
        {
            if (PAN.Length != 16)
            {
                throw new Exception("PAN IS INCORRECT");
            }
            else
            {
                return true;
            }
        }
        static bool checkingPIN(string PIN)
        {
            if (PIN.Length != 4)
            {
                throw new Exception("PIN IS INCORRECT");
            }
            else
            {
                return true;
            }
        }
        static bool checkingDate(DateTime date)
        {
            if (date.Year < DateTime.Now.Year || date.Month < DateTime.Now.Month)
            {
                throw new Exception("Cart is expired");
            }
            else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            int[] datetime = new int[2] { 2023, 12 };
            BankCart bc = new BankCart
            {
                ExpireTime = new DateTime(2023, 12, 5),
                PIN = "5523"
            };
            Client client = new Client
            {
                Name = "Name",
                Surname = "Surname"
            };
            bc.Settings(client);
            Console.WriteLine(bc.CVC);
            Console.WriteLine(bc.Username);
            Console.WriteLine(bc.PAN);
            try
            {
                checkingPAN(bc.PAN);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                checkingPIN(bc.PIN);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                checkingDate(bc.ExpireTime);
                bc.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                checkingBN(bc.BankName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}


