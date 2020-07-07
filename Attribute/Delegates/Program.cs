using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();//void metodlara elçilik. delegasyon delegator alligator.
    public delegate void MyDelegate2(string text);
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.SendMessage();
            cm.ShowAlert();

            MyDelegate myDelegate = cm.ShowAlert;
            myDelegate += cm.SendMessage;
            myDelegate();
            //Delegates
            Console.ReadLine();
            //Yapılacak işlemleri belli şartlara göre toplamak sıraya dizmek ve sıra halinde 
            //çağırmak*/*/*/*/*/*//**/*/*/
            myDelegate -= cm.SendMessage;
            /////////////////////////////////////
           
        }
    }
    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hi!");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Warning!");
        }
    }
}
