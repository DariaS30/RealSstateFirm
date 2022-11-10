using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Client//class
    {
        //class parameters 
        public string _name { get; set; }
        public string _sername;
        public string _phone;
        public string _pasportData;
        public string _bankNumber;
        public int _money;
        public string _wonderType;
        public List<RealEstate> RealEstates;
        public int _estateCount;


        public Client(){ }//empty constructor
        public Client(string name, string sername, string phone, string pasportData, string bankNumber, int money, string wonderType)
        {
            _name = name;
            _sername = sername;
            _phone = phone;
            _pasportData = pasportData;
            _bankNumber = bankNumber;
            _money = money;
            _wonderType = wonderType;
            RealEstates = new List<RealEstate>();
            _estateCount = 0;
        }//constructor

        public void ShowEstate(string address, int number)//method to show estate of object 
        {
            foreach (RealEstate estates in RealEstates)
            {
                estates.ToString();
                if ((estates._address == address) && (estates._number == number))
                {
                    RealEstates.Remove(estates);
                    _estateCount--;
                }
            }
        }

        public void AddEstate(RealEstate tmp)//method to add estate of object 
        {
            if(_estateCount < 5)
            {
                RealEstates.Add(tmp);
                _estateCount++;
            }
            else throw new MaximumEstateNumberException();
        }
        
        public void RemoveEstate(string address, int number)//method to delete estate of object 
        {
            foreach (RealEstate estates in RealEstates)
            {
                if ((estates._address == address) && (estates._number == number))
                {
                    RealEstates.Remove(estates);
                }
            }
        }

        
        //overrided method Tostring
        public override string ToString() => $"{_name} {_sername} | {_phone} | {_pasportData} |  {_bankNumber} |  {_money}$ | Wander Type: {_wonderType} count of estates = {_estateCount}";
    }
}
