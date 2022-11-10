using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class ReadWriteProvider//class of reading and writing objects
    {
        public static List<Client> ReadClient(string filename) => EntityContext<Client>.ReadFile(filename);

        public static List<RealEstate> ReadRealEstate(string fileName) => EntityContext<RealEstate>.ReadFile(fileName);

        public static void WriteClient(string filename, Client client) { EntityContext<Client>.WriteInFile(filename, client); }

        public static void WriteRealEstate(string filename, RealEstate estate) { EntityContext<RealEstate>.WriteInFile(filename, estate); }
    }
}
