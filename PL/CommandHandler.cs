using BL;
using System;

namespace PL
{
    public class CommandHandler
    {
        public void CommandHandle()//method of comand line
        {
            EntityMenu.HelpMenu();
            bool stop = false;
            while (!stop)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "client"://case of client
                        EntityMenu.ClientMenu();
                        string data = Console.ReadLine();
                        switch (data)
                        {
                            case "add"://case of adding client
                                bool isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputClient();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Client was added!");
                                break;
                            case "showall"://case of show all client
                                string clients = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clients = PrintService.StringClients(InputLogic.FileClientPath).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "remove"://case of remowing client
                                string pasportData = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        pasportData = InputLogic.InputForClient("pasportData");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                try { RemoveProvider.RemoveClient(InputLogic.FileClientPath, pasportData); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "search"://case of searching client
                                clients = null;
                                string clientbumber = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clientbumber = InputLogic.InputForClient("pasportData");
                                        clients = PrintService.StringClient(InputLogic.FileClientPath, clientbumber).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "change"://case of changing client
                                clientbumber = null;
                                isSuccess = false;
                                Console.WriteLine("Now enter information about previous client:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clientbumber = InputLogic.InputForClient("pasportData");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                try { RemoveProvider.RemoveClient(InputLogic.FileClientPath, clientbumber); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                isSuccess = false;
                                Console.WriteLine("Now enter information about new client:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputClient();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Client was changed!");
                                break;
                            case "sortbyname"://case of sorting client by name
                                clients = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clients = PrintService.SortBySername(InputLogic.FileClientPath).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "sortbysername"://case of sorting client by sername
                                clients = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clients = PrintService.SortByName(InputLogic.FileClientPath).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "sortbybanknumber"://case of sorting client by banknumber
                                clients = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clients = PrintService.SortByBankNumber(InputLogic.FileClientPath).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "addestate"://case of adding estate for client
                                isSuccess = false;
                                string estateAdress = null;
                                int number = 0;
                                string clientnubumber = null;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        estateAdress = InputLogic.InputForEstate("address");
                                        number = InputLogic.InputIntEstate("number");
                                        clientnubumber = InputLogic.InputForClient("pasportData");
                                        EntityService.AddEstateForClient(InputLogic.FileClientPath, clientnubumber, InputLogic.FilEstatePath, number, estateAdress);
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Estate was added!");
                                break;
                            case "showestates"://case of show estate 
                                clients = null;
                                string clientpass = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clientpass = InputLogic.InputForClient("pasportData");
                                        clients = PrintService.StringClientWithEstates(InputLogic.FileClientPath, clientpass).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "removecoach":
                                clientbumber = null;
                                estateAdress = null;
                                number = 0;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clientbumber = InputLogic.InputForClient("pasportData");
                                        estateAdress = InputLogic.InputForEstate("address");
                                        number = InputLogic.InputIntEstate("number");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                try { RemoveProvider.RemoveEstateFromClient(InputLogic.FileClientPath, clientbumber, number, estateAdress); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                        }
                        break;
                    case "estate"://case of estates
                        EntityMenu.EstateMenu();
                        string data2 = Console.ReadLine();
                        switch (data2)
                        {
                            case "add":
                                bool isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputEstate();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Estate was added!");
                                break;
                            case "showall"://case of show all estates
                                string estates = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        estates = PrintService.StringEstates(InputLogic.FilEstatePath).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(estates);
                                break;
                            case "remove"://case of remowing estate
                                string adress = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        adress = InputLogic.InputForEstate("address");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                try { RemoveProvider.RemoveEstate(InputLogic.FilEstatePath, adress); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "change"://case of changing estate
                                adress = null;
                                isSuccess = false;
                                Console.WriteLine("Now enter information about previous reserve:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        adress = InputLogic.InputForEstate("address");
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                try { RemoveProvider.RemoveEstate(InputLogic.FilEstatePath, adress); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                isSuccess = false;
                                Console.WriteLine("Now enter information about new client:");
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        InputLogic.InputEstate();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                Console.WriteLine("Estate was changed!");
                                break;
                            case "searchforclient"://case of searching estate for client
                                estates = null;
                                string clients = null;
                                string clientbumber = null;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        clientbumber = InputLogic.InputForClient("pasportData");
                                        clients = PrintService.StringSimularEstates(InputLogic.FileClientPath, InputLogic.FilEstatePath, clientbumber).ToString();

                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                            case "search"://case of searching estate
                                clients = null;
                                string estateAdress = null;
                                int number = 0;
                                isSuccess = false;
                                while (!isSuccess)
                                {
                                    try
                                    {
                                        estateAdress = InputLogic.InputForEstate("address");
                                        number = InputLogic.InputIntEstate("number");
                                        clients = PrintService.StringEsate(InputLogic.FilEstatePath, estateAdress, number).ToString();
                                        isSuccess = true;
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                }
                                Console.WriteLine(clients);
                                break;
                        }
                        break;

                    case "end"://case of end
                        stop = true;
                        Console.WriteLine("Tap any key on the keyboard, to stop program.");
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }
            }
        }
    }
}
