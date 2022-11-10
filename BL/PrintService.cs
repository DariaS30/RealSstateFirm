using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PrintService
    {
        //method to print all clients
        public static StringBuilder StringClients(string filename)
        {
            StringBuilder clientstrings = new StringBuilder();
            foreach (var item in ReadWriteProvider.ReadClient(filename))
            {
                clientstrings.Append(item.ToString() + "\n");
            }
            return clientstrings;
        }

        //method to sort clients by sername
        public static StringBuilder SortBySername(string filename)
        {
            StringBuilder clientstrings = new StringBuilder();
            List<Client> cliens = ReadWriteProvider.ReadClient(filename);
            cliens.Sort(delegate (Client x, Client y) {
                return x._sername.CompareTo(y._sername);
            });
            foreach (var item in cliens)
            {
                clientstrings.Append(item.ToString() + "\n");
            }
            return clientstrings;
        }

        //method to sort clients by name
        public static StringBuilder SortByName(string filename)
        {
            StringBuilder clientstrings = new StringBuilder();
            List<Client> cliens = ReadWriteProvider.ReadClient(filename);
            cliens.Sort(delegate (Client x, Client y) {
                return x._name.CompareTo(y._name);
            });
            foreach (var item in cliens)
            {
                clientstrings.Append(item.ToString() + "\n");
            }
            return clientstrings;
        }

        //method to sort clients by banknumber
        public static StringBuilder SortByBankNumber(string filename)
        {
            StringBuilder clientstrings = new StringBuilder();
            List<Client> cliens = ReadWriteProvider.ReadClient(filename);
            cliens.Sort(delegate (Client x, Client y) {
                return x._bankNumber.CompareTo(y._bankNumber);
            });
            foreach (var item in cliens)
            {
                clientstrings.Append(item.ToString() + "\n");
            }
            return clientstrings;
        }


        public static StringBuilder StringEstates(string filename)
        {
            StringBuilder estatestrings = new StringBuilder();
            foreach (var item in ReadWriteProvider.ReadRealEstate(filename))
            {
                estatestrings.Append(item.ToString() + "\n");
            }
            return estatestrings;
        }

        public static StringBuilder StringSimularEstates(string filename, string filename2, string clientNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder type = null;
            try
            {
                type = stringBuilder.Append(SearchProvider.SearchOfClientTypeByNumber(clientNumber, filename).ToString());
            }
            catch { throw; }

            //return stringBuilder;
            StringBuilder estatestrings = new StringBuilder();
            foreach (var item in ReadWriteProvider.ReadRealEstate(filename2))
            {
                if(type.ToString() == item._type)
                {
                    estatestrings.Append(item.ToString() + "\n");
                }
            }
            return estatestrings;
        }


        public static StringBuilder StringClient(string filename, string clientNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append(SearchProvider.SearchOfClientByNumber(clientNumber, filename).ToString());
            }
            catch { throw; }
            return stringBuilder;
        }

        public static StringBuilder StringClientWithEstates(string filename, string clientNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                Client client = SearchProvider.SearchOfClientByNumber(clientNumber, filename);

                stringBuilder.Append($"{client._name} {client._sername} has {client._estateCount} estates. It's:\n");
                foreach (var estate in client.RealEstates)
                {
                    stringBuilder.Append($"His estate is in {estate._location}, {estate._address}, {estate._number} | coast: {estate._coast}$ |  type: {estate._type}\n").ToString();
                }
            }
            catch { throw; }
            return stringBuilder;
        }

        public static StringBuilder StringEsate(string filename, string adress, int number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append(SearchProvider.SearchOfEstateByNumberAndAdress(adress, number, filename).ToString());
            }
            catch { throw; }
            return stringBuilder;
        }

    }
}
