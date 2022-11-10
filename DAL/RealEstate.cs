using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class RealEstate//class
    {
        public string _address;
        public int _number;
        public string _location;
        public int _coast;
        public string _type;
        public bool _isArended = false
            ;
        public RealEstate() { }//empty constructor
        public RealEstate(string address, int number, string location, int coast, string type, bool isArended)//constructor
        {
            _address = address;
            _number = number;
            _location = location;
            _coast = coast;
            _type = type;
            _isArended = isArended;
        }

        //overrided method Tostring
        public override string ToString() => $"{_location}, {_address}, {_number} | coast: {_coast}$ |  type: {_type}";
    }
}
