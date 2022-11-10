using BL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace MSTests
{
    [TestClass]
    public class SearchProviderTest
    {
        [TestMethod]
        public void SearchOfClientByNumber_WhenValidEstatesInList_shouldReturnExpectedObjectAfterSearch()
        {
            string clientNumber = "A3805023345";
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);
            foreach (Client client in GetClientList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }

            Client searchedClient = SearchProvider.SearchOfClientByNumber(clientNumber, Path);
            Assert.AreEqual(clientNumber, searchedClient._pasportData);
        }

        [TestMethod]
        public void SearchOfClientTypeByNumber_WhenValidClientsInList_shouldReturnExpectedObjectAfterSearch()
        {
            string clientNumber = "A3805023345";
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);
            foreach (Client client in GetClientList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }
            string expected = "2F";
            string searchedClient = SearchProvider.SearchOfClientTypeByNumber(clientNumber, Path);
            Assert.AreEqual(expected, searchedClient);
        }

        [TestMethod]
        public void SearchOfEstateByNumberAndAdress_WhenValidClientsInList_shouldReturnExpectedObjectAfterSearch()
        {
            string adress = "Jonson Street";
            int number = 4;
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<RealEstate>.ClearFile(Path);
            foreach (RealEstate realEstate in GetEstatesList())
            {
                ReadWriteProvider.WriteRealEstate(Path, realEstate);
                expect.Append(realEstate.ToString() + "\n");
            }
            RealEstate searchedClient = SearchProvider.SearchOfEstateByNumberAndAdress(adress, number, Path);
            Assert.AreEqual(adress, searchedClient._address);
            Assert.AreEqual(number, searchedClient._number);
        }


        public static List<Client> GetClientList()
        {
            List<Client> clients = new List<Client>
            {
                new Client("John", "Willson", "+380502382222", "A3805023345", "35023622", 50000, "2F"),
                new Client("Bob", "Smith", "+380502214245", "C3245023345", "56123656", 60000, "3F")
            };
            return clients;
        }

        public static List<RealEstate> GetEstatesList()
        {
            List<RealEstate> clients = new List<RealEstate>
            {
                new RealEstate("Jonson Street", 4, "London", 500, "2F", false),
                new RealEstate("Jonson Street", 3, "London", 400, "1F", false)
            };
            return clients;
        }
    }
}
