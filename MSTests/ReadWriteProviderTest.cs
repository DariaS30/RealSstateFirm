using BL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MSTests
{
    [TestClass]
    public class ReadWriteProviderTest
    {
        [TestMethod]
        public void ReadClient_WhenValidInput_shouldReturnList()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<Client>.ClearFile(Path);
            foreach (Client client in GetClientList())
            {
                ReadWriteProvider.WriteClient(Path, client);
            }
            List<Client> expect = GetClientList();
            List<Client> readTrains = ReadWriteProvider.ReadClient(Path);
            Assert.AreEqual(expect.Count, readTrains.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i]._name, readTrains[i]._name);
                Assert.AreEqual(expect[i]._sername, readTrains[i]._sername);
                Assert.AreEqual(expect[i]._phone, readTrains[i]._phone);
                Assert.AreEqual(expect[i]._bankNumber, readTrains[i]._bankNumber);
                Assert.AreEqual(expect[i]._pasportData, readTrains[i]._pasportData);
                Assert.AreEqual(expect[i]._money, readTrains[i]._money);
                Assert.AreEqual(expect[i]._wonderType, readTrains[i]._wonderType);
            }
        }

        [TestMethod()]
        public void ReadClient_WhenInvalidInput_shouldThrowExp()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<Client>.ClearFile(Path);
            Assert.ThrowsException<SerializationException>(() => ReadWriteProvider.ReadClient(Path));
        }

        [TestMethod]
        public void ReadEstate_WhenValidInput_shouldReturnList()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<RealEstate>.ClearFile(Path);
            foreach (RealEstate estate in GetEstatesList())
            {
                ReadWriteProvider.WriteRealEstate(Path, estate);
            }
            List<RealEstate> expect = GetEstatesList();
            List<RealEstate> readTrains = ReadWriteProvider.ReadRealEstate(Path);
            Assert.AreEqual(expect.Count, readTrains.Count);
            for (int i = 0; i < expect.Count; i++)
            {
                Assert.AreEqual(expect[i]._address, readTrains[i]._address);
                Assert.AreEqual(expect[i]._number, readTrains[i]._number);
                Assert.AreEqual(expect[i]._location, readTrains[i]._location);
                Assert.AreEqual(expect[i]._type, readTrains[i]._type);
                Assert.AreEqual(expect[i]._coast, readTrains[i]._coast);
            }
        }

        [TestMethod()]
        public void ReadEstate_WhenInvalidInput_shouldThrowExp()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<RealEstate>.ClearFile(Path);
            Assert.ThrowsException<SerializationException>(() => ReadWriteProvider.ReadRealEstate(Path));
        }

        [TestMethod()]
        public void WriteCleint_WhenInvalidInput_shouldLeaveInfoAfterAction()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<Client>.ClearFile(Path);
            var expected = GetClientList();

            foreach (var client in expected)
            {
                ReadWriteProvider.WriteClient(Path, client);
            }
            var actual = ReadWriteProvider.ReadClient(Path);


            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i]._name, actual[i]._name);
                Assert.AreEqual(expected[i]._sername, actual[i]._sername);
                Assert.AreEqual(expected[i]._phone, actual[i]._phone);
                Assert.AreEqual(expected[i]._pasportData, actual[i]._pasportData);
                Assert.AreEqual(expected[i]._bankNumber, actual[i]._bankNumber);
                Assert.AreEqual(expected[i]._wonderType, actual[i]._wonderType);
                Assert.AreEqual(expected[i]._money, actual[i]._money);
            }
        }

        [TestMethod()]
        public void WriteEstate_WhenInvalidInput_shouldLeaveInfoAfterAction()
        {
            string Path = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
            EntityContext<RealEstate>.ClearFile(Path);
            var expected = GetEstatesList();

            foreach (var estate in expected)
            {
                ReadWriteProvider.WriteRealEstate(Path, estate);
            }
            var actual = ReadWriteProvider.ReadRealEstate(Path);


            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i]._address, actual[i]._address);
                Assert.AreEqual(expected[i]._number, actual[i]._number);
                Assert.AreEqual(expected[i]._location, actual[i]._location);
                Assert.AreEqual(expected[i]._type, actual[i]._type);
                Assert.AreEqual(expected[i]._coast, actual[i]._coast);
            }
        }

        public static List<Client> GetClientList()
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
