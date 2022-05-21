﻿using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {

        public String usernameValue()
        {
            return "maciej";
        }

        public String passwordValue()
        {
            return "os";
        }

        protected override void BeforeRun()
        {
            string splash = @"
.___  ___.      ___       ______  __   _______        __       ______        _______.
|   \/   |     /   \     /      ||  | |   ____|      |  |     /  __  \      /       |
|  \  /  |    /  ^  \   |  ,----'|  | |  |__         |  |    |  |  |  |    |   (----`
|  |\/|  |   /  /_\  \  |  |     |  | |   __|  .--.  |  |    |  |  |  |     \   \    
|  |  |  |  /  _____  \ |  `----.|  | |  |____ |  `--'  |    |  `--'  | .----)   |   
|__|  |__| /__/     \__\ \______||__| |_______| \______/      \______/  |_______/    
                                                                                     
";
            Console.Clear();
          
            Console.WriteLine("Nazwa uzytkownika : ");
            string username = usernameValue();
            string inputusername = Console.ReadLine();
            
            
            
            if (inputusername != username)
            {
                Sys.Power.Shutdown();                
            }
            else
            Console.WriteLine("Haslo :");

            
            string inputpassword = Console.ReadLine();
            string password = passwordValue();

            if (inputpassword != password)
            {
                Sys.Power.Shutdown();
            }
            else
                Console.WriteLine(splash);
                Console.WriteLine("Zalogowany!");


        }

        protected override void Run()
        {

            string input = "";

            Console.WriteLine("MaciejOS >");
            input = Console.ReadLine();

            CommandHandler(input);
        }

        private void CommandHandler(string input)
        {
            string username = usernameValue();
            string password = passwordValue();
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
            else if(input == "logout")
            {
                BeforeRun();
            }
            else if(input == "whoami")
            {
                Console.WriteLine(username);
            }
            Console.WriteLine("");
        }
       }

}
