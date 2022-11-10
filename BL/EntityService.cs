using System;
using DAL;
using static BL.BLLExeptions;

namespace BL
{
    public class EntityService//class
    {
        //method to add client in file
        public static void AddClient(string file, string name, string sername, string phone, string pasportData, string bankNumber, int money, string type)
            => EntityContext<Client>.WriteInFile(file, CreateEntity.CreateClient(name, sername, phone, pasportData, bankNumber, money, type));

        // method of adding existing 
        public static void AddClient(string file, Client client) => EntityContext<Client>.WriteInFile(file, client);

        //method to add estate in file
        public static void AddEstate(string file, string address, int number, string location, int coast, string type, bool isArended)
            => EntityContext<RealEstate>.WriteInFile(file, CreateEntity.CreateEstate(address, number, location, coast, type, isArended));

        //method to add estate for client
        public static void AddEstateForClient(string fileClient, string pasportData, string fileEstate, int number, string adress)
        {
            Client searchedClient = new Client();
            searchedClient = SearchProvider.SearchOfClientByNumber(pasportData, fileClient);
            RealEstate searchedEstate = new RealEstate();
            searchedEstate = SearchProvider.SearchOfEstateByNumberAndAdress(adress, number, fileEstate);
            if (searchedClient._money >= searchedEstate._coast)
            {
                RemoveProvider.RemoveClient(fileClient, pasportData);
                searchedClient.AddEstate(searchedEstate);
                searchedClient._money = searchedClient._money - searchedEstate._coast;
                AddClient(fileClient, searchedClient);
            }
            else throw new NotEnoughMoneyException();
        }
    }
}
