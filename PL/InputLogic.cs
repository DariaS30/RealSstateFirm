using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BLLExeptions;

namespace PL
{
    public class InputLogic
    {
        //file paths for clients and estates
        public static readonly string FileClientPath = @"C:\Users\darya\OneDrive\Робочий стіл\course\Clients.bin";
        public static readonly string FilEstatePath = @"C:\Users\darya\OneDrive\Робочий стіл\course\Estates.bin";

        //methods to insert client values
        public static void InputClient()
        {
            bool isSuccess = false;
            string name = null, sername = null, phone = null, pasportData = null, bankNumber = null, type = null;
            int money = 0;
            while (!isSuccess)
            {
                try
                {
                    name = InputForClient("name");
                    sername = InputForClient("sername");
                    phone = InputForClient("phone");
                    pasportData = InputForClient("pasportData");
                    bankNumber = InputForClient("bankNumber");
                    type = InputForClient("type");
                    money = InputInt("money");
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            EntityService.AddClient(FileClientPath, name, sername, phone, pasportData, bankNumber, money, type);
        }

        //method for client value
        public static string InputForClient(string line)
        {
            string pattern, data;
            if (line == "name")
            {
                pattern = "[A-Z]{1}[a-z]";
                Console.WriteLine("Enter Client name(Example: John):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "sername")
            {
                pattern = "[A-Z]{1}[a-z]";
                Console.WriteLine("Enter Client serame(Example: Johnson):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "phone")
            {
                pattern = "^[+]{1}[0-9]{12}$";
                Console.WriteLine("Enter Client phone(Example: +3805023345):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "pasportData")
            {
                pattern = "^[A-D]{1}[0-9]{10}$";
                Console.WriteLine("Enter Client pasportData(Example: A3805023345):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "bankNumber")
            {
                pattern = "^[0-9]{8}$";
                Console.WriteLine("Enter Client Bunk Number(Example: 35023345):");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else if (line == "type")
            {
                pattern = "^(1F|2F|3F|PH)$";
                Console.WriteLine("Types of estates:\n\t1F - one flore;\n\t2F - twp floores;\n" +
                    "\t3F - three flores;\n\tPH - Private House.");
                Console.WriteLine("Enter 2 upperspace letters to choose house type:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else throw new NotPassedValueException();
        }

        //method for estate values
        public static void InputEstate()
        {
            bool isSuccess = false;
            string address = null, location = null, type = null;
            int coast = 0, number = 0;
            bool isArended = false;
            while (!isSuccess)
            {
                try
                {
                    location = InputForEstate("location");
                    address = InputForEstate("address");
                    number = InputIntEstate("number");
                    type = InputForEstate("type");
                    coast = InputIntEstate("coast");
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            }
            EntityService.AddEstate(FilEstatePath, address, number, location, coast, type, isArended);
        }

        //method for estate value
        public static string InputForEstate(string line)
        {
            string pattern, data;
            if (line == "location")
            {
                Console.WriteLine("Enter address(Example: London):");
                data = Console.ReadLine();
                return data;
            }
            else if (line == "address")
            {
                Console.WriteLine("Enter address(Example: Jonson Street):");
                data = Console.ReadLine();
                return data;
            }
            else if (line == "type")
            {
                pattern = "^(1F|2F|3F|PH)$";
                Console.WriteLine("Types of estates:\n\t1F - one flore;\n\t2F - twp floores;\n" +
                    "\t3F - three flores;\n\tPH - Private House.");
                Console.WriteLine("Enter 2 upperspace letters to choose house type:");
                data = Console.ReadLine();
                if (!VerifyInputService.IsInputCorrect(data, pattern))
                    throw new NotPassedValueException();
                return data;
            }
            else throw new NotPassedValueException();
        }

        //method of inputing int value for client
        public static int InputInt(string line)
        {
            string data;
            if (line == "money")
            {
                Console.WriteLine("Enter Client money(Example: 4399):");
                data = Console.ReadLine();
                return Int32.Parse(data);
            }
            else return 0;
        }

        //method of inputing int value for estate
        public static int InputIntEstate(string line)
        {
            string data;
            string data2;
            if (line == "coast")
            {
                Console.WriteLine("Enter Estate coast(Example: 4399):");
                data = Console.ReadLine();
                return Int32.Parse(data);
            }
            else if(line == "number")
            {
                Console.WriteLine("Enter Estate number(Example: 44):");
                data2 = Console.ReadLine();
                return Int32.Parse(data2);
            }
            else return 0;
        }
    }
}
