using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class VerifyInputService//class of input verification
    {
        public static bool IsInputCorrect(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
