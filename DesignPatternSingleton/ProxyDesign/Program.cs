using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesign
{
    class Program
    {//Run same methods at the sametime Class...
        static void Main(string[] args)
        {
            CreditBase cm = new CreditManagerProxy();
            Console.WriteLine(  cm.Calculate()); 
            Console.WriteLine(  cm.Calculate()); 
           
        }
    }

    abstract class CreditBase 
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1222);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }

}
