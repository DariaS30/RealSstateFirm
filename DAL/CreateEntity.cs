using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CreateEntity
    {
        //method to create client 
        public static Client CreateClient(string name, string sername, string phone, string pasportData, string bankNumber, int money, string type)
            => new Client(name, sername, phone, pasportData, bankNumber, money, type);

        //method to create estate 
        public static RealEstate CreateEstate(string address, int number, string location, int coast, string type, bool isArended)
            => new RealEstate(address, number, location, coast, type, isArended);
    }
}
