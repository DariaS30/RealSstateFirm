using BL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestProject1
{
    [TestClass]
    public class ReadWriteProviderTest
    {
        [TestMethod()]
        public void ReadTrain_should_return_list_of_trains_after_reading_file()
        {
            string Path = @"D:\Ырср\Clients.bin";
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
                Assert.AreEqual(expect[i]._pasportData, readTrains[i]._pasportData);
                Assert.AreEqual(expect[i]._bankNumber, readTrains[i]._bankNumber);
                Assert.AreEqual(expect[i]._money, readTrains[i]._money);
                Assert.AreEqual(expect[i]._wonderType, readTrains[i]._wonderType);
            }
        }

        [TestMethod()]
        public void ReadTrain_should_throw_exception_about_empty_stream()
        {
            string Path = @"D:\Ырср\Clients.bin";

            //act
            EntityContext<Client>.ClearFile(Path);

            //assert
            Assert.ThrowsException<SerializationException>(() => ReadWriteProvider.ReadClient(Path));
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
    }
}
