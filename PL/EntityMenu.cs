using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class EntityMenu
    {
        //main menu 
        public static void HelpMenu() => Console.WriteLine("In that program you can do such action as:\n" +
           "\t client - to add, remove or recive some information about clients;\n" +
           "\t estate - to add, change, remove or recive information about estate\n" +
           "\t end - to end work.");

        //client menu
        public static void ClientMenu() => Console.WriteLine("Client commands:\n" +
            "\tadd - to add new client;\n" +
            "\tremove - to remove any client;\n" +
            "\tshowall - to show all clients with main information about them;\n" +
            "\tchange - to edit any client;\n" +
            "\tsortbyname - to sort clients by name;\n" +
            "\tsortbysername - to sort clients by sername;\n" +
            "\tsortbybanknumber - to sort clients by bank number;\n" +
            "\taddestate - to add estate for client;\n" +
            "\tremoveestate - to remove client's estate;\n" +
            "\tshowestate - to show client's estates;\n" +
            "\tsearch- to find client by its passportdata\n\tend - to go to the other command group.\n Choose one of them");

        // estate menu
        public static void EstateMenu() => Console.WriteLine("Estate commands:\n" +
            "\tadd- to add new estate;\n" +
            "\tremove - to remove any estate;\n" +
            "\tshowall - to show all estats with main information about them;\n" +
            "\tchange - to edit any estate;\n" +
            "\tsearchforclient - to find estate by type of client wonder\n" +
            "\tsearch - to find estate by its adress\n\tend - to go to the other command group.\n Choose one of them");
    }
}
