using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //exception of maximum estates number
    public class MaximumEstateNumberException : Exception
    {
        public override string Message => "Maximum estate number in client!";
    }
}
