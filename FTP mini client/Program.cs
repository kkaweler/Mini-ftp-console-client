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
            Client A = new Client();
            string consoleCommand = " ";
            string[] commandSplit;
            do
            {
                consoleCommand = Console.ReadLine();
                commandSplit = consoleCommand.Split(new Char[] { ' ' });

                switch (commandSplit[0])
                {
                    case "connect":
                        try
                        {
                            A.connect(commandSplit[1] + "/");
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        break;

                    case "move":
                        try
                        {
                            A.moveToDir(commandSplit[1]+"/");
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        break;

                    case "moveback":
                        try
                        {
                            A.moveBack();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        } 
                        break;

                    case "download":
                        try
                        {
                            A.dowloadFile(commandSplit[1]);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    default :
                        Console.WriteLine("Unknown command " + commandSplit[0]);
                        break;
                }
            }
            while (consoleCommand != "exit");
        }
    }
}
