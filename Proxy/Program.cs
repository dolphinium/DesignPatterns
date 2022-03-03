using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CreditManager creditManager = new CreditManager();    --> the output will be waiting for 5 seconds then 5 seconds 
            CreditBase creditManager = new CreditManagerProxy();   //--> the output will be waiting for 5 seconds then second calculation comes instantly because we use cache
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());
            

            Console.ReadLine();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager:CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy:CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue=_creditManager.Calculate();
            }

            return _cachedValue;
        }
    }

}
