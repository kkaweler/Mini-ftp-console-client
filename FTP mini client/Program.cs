using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_mini_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Commands list:");
            Console.WriteLine("connect 'connect ftp://ftp.mozilla.org/pub/mozilla.org'");
            Console.WriteLine("move 'move folder'");
            Console.WriteLine("moveback");
            Console.WriteLine("download 'download file' '\n");
            Client client = new Client();
            string.EMPTY consoleCommand;
            string[] commandSplit;
            do
            {
                consoleCommand = Console.ReadLine();
                commandSplit = consoleCommand.Split(new Char[] { ' ' });
                try
                {
                    switch (commandSplit[0])
                    {
                        case "connect":
                            client.Connect(commandSplit[1] + "/");
                            break;

                        case "move":
                            client.MoveToDir(commandSplit[1]+"/");
                            break;

                        case "moveback":
                            client.MoveBack();
                            break;

                        case "download":
                            client.DowloadFile(commandSplit[1]);
                            break;

                        default :
                            Console.WriteLine("Unknown command " + commandSplit[0]);
                            break;
                    }
                }
                catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
            }
            while (consoleCommand != "exit");
        }
    }
}
