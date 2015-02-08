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
            Client A = new Client("ftp://ftp.mozilla.org/pub/mozilla.org/");
            string consoleCommand = " ";
            string[] commandSplit;
            do
            {
                consoleCommand = Console.ReadLine();
                commandSplit = consoleCommand.Split(new Char[] { ' ' });

                switch (commandSplit[0])
                {
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
