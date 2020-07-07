using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class MessageManagerBase
    {
       public void Save()
        {
            Console.WriteLine("Saved!");
        }

        //public void SendSms()
        //{

        //}
        //public void SendEmail()
        //{

        //}

        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }

    class MailSender : MessageManagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("Sent With MailSender");
        }
    }
    class SmsSender : MessageManagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("Sent With SmsSender");
        }
    }
}

