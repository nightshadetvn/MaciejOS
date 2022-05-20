using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
          
            Console.WriteLine("Nazwa uzytkownika : ");
            string username = Console.ReadLine();
            
            
            if (username != "maciej")
            {
                Sys.Power.Shutdown();                
            }
            else
            Console.WriteLine("Haslo :");
            string password = Console.ReadLine();
            if (password != "os")
            {
                BeforeRun();
                Sys.Power.Shutdown();
            }
            else
                Console.WriteLine("Zalogowany!");


        }

        protected override void Run()
        {
            string splash = @"
.___  ___.      ___       ______  __   _______        __       ______        _______.
|   \/   |     /   \     /      ||  | |   ____|      |  |     /  __  \      /       |
|  \  /  |    /  ^  \   |  ,----'|  | |  |__         |  |    |  |  |  |    |   (----`
|  |\/|  |   /  /_\  \  |  |     |  | |   __|  .--.  |  |    |  |  |  |     \   \    
|  |  |  |  /  _____  \ |  `----.|  | |  |____ |  `--'  |    |  `--'  | .----)   |   
|__|  |__| /__/     \__\ \______||__| |_______| \______/      \______/  |_______/    
                                                                                     
";
            string input = "";

            Console.WriteLine(splash);
            Console.WriteLine("MaciejOS >");
            input = Console.ReadLine();

            CommandHandler(input);
        }

        private void CommandHandler(string input)
        {
            if (input == "help")
            {
                Console.WriteLine("help - pokazuje ci te strone");
                Console.WriteLine("shutdown - wylacza pc z 5 sec opoznieniem");
                Console.WriteLine("restart - restartuje twoj komputer z 5 sec opoznieniem");
                Console.WriteLine("clear - wyczysca terminal");
                Console.WriteLine("echo - powtarza twoja wiadomosc po komendzie");
                
            }
            else if (input == "shutdown")
            {
                Console.WriteLine("Wylaczenie za 5 sec.");
                System.Threading.Thread.Sleep(5000);
                Sys.Power.Shutdown();
            }
            else if (input == "clear")
            {
                Console.Clear();
            }
            else if (input.StartsWith("echo "))
{
                Console.WriteLine(input[5..input.Length]);
            }
            else if (input == "restart")
            {
                Console.WriteLine("Restart za 5 sec.");
                System.Threading.Thread.Sleep(5000);
                Sys.Power.Reboot();
            }
            else if(input == "")
            Console.WriteLine("");
        }
       }

}
