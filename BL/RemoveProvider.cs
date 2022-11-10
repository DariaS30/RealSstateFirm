using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RemoveProvider
    {
        public static void RemoveClient(string filename, string pasportData)
        {
            List<Client> clienList = EntityContext<Client>.ReadFile(filename);
            for (int i = 0; i < clienList.Capacity; ++i)
            {
                if (clienList[i]._pasportData == pasportData)
                {
                    clienList.RemoveAt(i);
                    break;
                }
            }
            EntityContext<Client>.ClearFile(filename);
            foreach (Client client in clienList)
            {
                EntityContext<Client>.WriteInFile(filename, client);
            }
        }

        public static void RemoveEstate(string filename, string adress)
        {
            List<RealEstate> estateList = EntityContext<RealEstate>.ReadFile(filename);
            for (int i = 0; i < estateList.Capacity; ++i)
            {
                if (estateList[i]._address == adress)
                {
                    estateList.RemoveAt(i);
                    break;
                }
            }
            EntityContext<RealEstate>.ClearFile(filename);
            foreach (RealEstate estate in estateList)
            {
                EntityContext<RealEstate>.WriteInFile(filename, estate);
            }
        }
        
        public static void RemoveEstateFromClient(string filename, string passportdata, int number, string adress)
        {
            List<Client> clientList = EntityContext<Client>.ReadFile(filename);
            Client searchedClient = SearchProvider.SearchOfClientByNumber(passportdata, filename);
            foreach (Client client in clientList)
            {
                if (searchedClient._pasportData == client._pasportData)
                {
                    client.RemoveEstate(adress, number);
                }
            }
            //clearing of client file
            EntityContext<Client>.ClearFile(filename);
            foreach (Client client in clientList)
            {
                client._estateCount--;
                EntityContext<Client>.WriteInFile(filename, client);
            }
        }
    }
}
