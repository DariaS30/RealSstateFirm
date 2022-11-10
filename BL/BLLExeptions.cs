using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLLExeptions//class with exceptions
    {
        public class NoClientException : Exception//exception with null client
        {
            public override string Message => "No such client in database!";
        }
        public class NotPassedValueException : Exception//exception of not passive value
        {
            public override string Message => "Vallue do not pass to format!";
        }

        public class NotEnoughMoneyException : Exception//exception of not enough money
        {
            public override string Message => "Client has no money for this!";
        }

    }
}
