using BL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using static BL.BLLExeptions;

namespace MSTests
{
    [TestClass]
    public class PrintServiceTest
    {
        [TestMethod]

        
        public void StringClients_WhenValidClientsInList_shouldReturnExpectedObjects()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);
            foreach (Client client in GetClientList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }
            StringBuilder actual = PrintService.StringClients(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }

        [TestMethod]
        public void StringClient_WhenValidClientsInList_shouldReturnExpectedObject()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<Client>.ClearFile(Path);
            ReadWriteProvider.WriteClient(Path, GetClientList()[0]);
            StringBuilder expect = new StringBuilder();
            expect.Append(GetClientList()[0].ToString() + "\n");

            StringBuilder actual = PrintService.StringClient(Path, "A3805023345");

            Assert.IsFalse(expect.ToString() == actual.ToString());
        }


        [TestMethod]
        public void StringClients_WhenValidClientsInList_shouldReturnExpectedSortetByNameObjects()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);

            foreach (Client client in GetSortedByNameList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }
            StringBuilder actual = PrintService.SortByName(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }

        [TestMethod]
        public void StringClients_WhenValidClientsInList_shouldReturnExpectedSortetBySernameObjects()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);

            foreach (Client client in GetSortedBySernameList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }
            StringBuilder actual = PrintService.SortBySername(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }

        [TestMethod]
        public void StringClients_WhenValidClientsInList_shouldReturnExpectedSortedByBankNumberObjects()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<Client>.ClearFile(Path);

            foreach (Client client in GetSortedByBanknumberList())
            {
                ReadWriteProvider.WriteClient(Path, client);
                expect.Append(client.ToString() + "\n");
            }
            StringBuilder actual = PrintService.SortByBankNumber(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }

        [TestMethod]
        public void StringEstates_WhenValidEstatesInList_shouldReturnExpectedObjects()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            StringBuilder expect = new StringBuilder();
            EntityContext<RealEstate>.ClearFile(Path);
            foreach (RealEstate realEstate in GetEstatesList())
            {
                ReadWriteProvider.WriteRealEstate(Path, realEstate);
                expect.Append(realEstate.ToString() + "\n");
            }
            StringBuilder actual = PrintService.StringEstates(Path);

            Assert.AreEqual(expect.ToString(), actual.ToString());
        }

        [TestMethod]
        public void StringEstate_WhenValidClientsInList_shouldReturnExpectedObject()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<RealEstate>.ClearFile(Path);
            ReadWriteProvider.WriteRealEstate(Path, GetEstatesList()[0]);
            StringBuilder expect = new StringBuilder();
            expect.Append(GetEstatesList()[0].ToString() + "\n");

            StringBuilder actual = PrintService.StringEsate(Path, "Jonson Street", 4);

            Assert.IsFalse(expect.ToString() == actual.ToString());
        }


        [TestMethod]
        public void StringClientWithEstates_WhenValidClientsInList_shouldReturnExpectedObject()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<Client>.ClearFile(Path);
            ReadWriteProvider.WriteClient(Path, GetClientList()[0]);
            StringBuilder expect = new StringBuilder();
            expect.Append(GetClientList()[0].ToString() + "\n");

            StringBuilder actual = PrintService.StringClientWithEstates(Path, "A3805023345");

            Assert.IsFalse(expect.ToString() == actual.ToString());
        }


        [TestMethod]
        public void StringSimularEstates_WhenValidEstatesInList_shouldReturnExpectedObject()
        {
            string Path1 = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            string Path2 = @"C:\Users\darya\OneDrive\Робочий стіл\course\Estates.bin";
            EntityContext<Client>.ClearFile(Path1);
            EntityContext<RealEstate>.ClearFile(Path2);
            ReadWriteProvider.WriteClient(Path1, GetClientList()[0]);
            ReadWriteProvider.WriteRealEstate(Path2, GetEstatesList()[0]);
            StringBuilder expect = new StringBuilder();

            expect.Append(GetEstatesList()[0]._type + "\n");

            StringBuilder actual = PrintService.StringSimularEstates(Path1, Path2, GetClientList()[0]._pasportData);

            Assert.IsFalse(expect.ToString() == actual.ToString());
        }



        public static List<Client> GetSortedByBanknumberList()
        {
            List<Client> clients = new List<Client>
            {
                new Client("John", "Willson", "+380502382222", "A3805023345", "35023622", 50000, "2F"),
                new Client("Bob", "Smith", "+380502214245", "C3245023345", "56123656", 60000, "3F")
            };
            return clients;
        }

        public static List<Client> GetClientsWithEstates()
        {
            List<Client> clients = new List<Client>
            {
                new Client("John", "Willson", "+380502382222", "A3805023345", "35023622", 50000, "2F"),
                new Client("Bob", "Smith", "+380502214245", "C3245023345", "56123656", 60000, "3F")
            };
            clients[0].AddEstate(new RealEstate("Jonson Street", 4, "London", 500, "2F", false));
            clients[1].AddEstate(new RealEstate("Jonson Street", 3, "London", 400, "1F", false));
            return clients;
        }

        public static List<Client> GetSortedBySernameList()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Bob", "Smith", "+380502214245", "C3245023345", "56123656", 60000, "3F"),
                new Client("John", "Willson", "+380502382222", "A3805023345", "35023622", 50000, "2F")
            };
            return clients;
        }

        public static List<Client> GetSortedByNameList()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Bob", "Smith", "+380502214245", "C3245023345", "56123656", 60000, "3F"),
                new Client("John", "Willson", "+380502382222", "A3805023345", "35023622", 50000, "2F")
            };
            return clients;
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
