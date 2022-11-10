using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BLLExeptions;

namespace BL
{
    public class SearchProvider
    {
        //method of search client
        public static Client SearchOfClient(string filename)
        {
            List<Client> clients = EntityContext<Client>.ReadFile(filename);
            foreach (var client in clients)
            {
                 return client;
            }
            throw new NoClientException();
        }

        //method of search client by number
        public static Client SearchOfClientByNumber(string clientNumber, string filename)
        {
            List<Client> clients = EntityContext<Client>.ReadFile(filename);
            foreach (var client in clients)
            {
                if (client._pasportData == clientNumber)
                {
                    return client;
                }
            }
            throw new NoClientException();
        }

        //method of search estate by number and address
        public static RealEstate SearchOfEstateByNumberAndAdress(string address, int number, string filename)
        {
            List<RealEstate> estates = EntityContext<RealEstate>.ReadFile(filename);
            foreach (var estate in estates)
            {
                if ((estate._address == address) && (estate._number == number))
                {
                    return estate;
                }
            }
            throw new NoClientException();
        }

        //method of search client type by number
        public static string SearchOfClientTypeByNumber(string clientNumber, string filename)
        {
            List<Client> clients = EntityContext<Client>.ReadFile(filename);
            foreach (var client in clients)
            {
                if (client._pasportData == clientNumber)
                {
                    return client._wonderType;
                }
            }
            throw new NoClientException();
        }
    }
}
