using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

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
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
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
            var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing("0:\\");

            if (input == "help")
            {
                Console.WriteLine("help - pokazuje ci te strone");
                Console.WriteLine("shutdown - wylacza pc z 5 sec opoznieniem");
                Console.WriteLine("restart - restartuje twoj komputer z 5 sec opoznieniem");
                Console.WriteLine("clear - wyczysca terminal");
                Console.WriteLine("echo - powtarza twoja wiadomosc po komendzie");
                Console.WriteLine("logout - wylogowywuje sie z konta");
                Console.WriteLine("whoami - pokazuje na jakim koncie jestes");
                Console.WriteLine("df - pokazuje ilosc wolnego miejsca w MB");
                Console.WriteLine("ls - pokazuje pliki, ich rozmiar w KB i jego zawartosc");

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
            else if (input == "logout")
            {
                BeforeRun();
            }
            else if (input == "whoami")
            {
                Console.WriteLine(username);
            }
            else if (input == "df")
            {
                long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:\\");
                Console.WriteLine("Dostepne miejsce (w MB): " + available_space / 1000000);
            }
            else if (input == "ls")
            {
                try
                {
                    foreach (var directoryEntry in directory_list)
                    {
                        var file_stream = directoryEntry.GetFileStream();
                        var entry_type = directoryEntry.mEntryType;
                        if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.File)
                        {
                            byte[] content = new byte[file_stream.Length];
                            file_stream.Read(content, 0, (int)file_stream.Length);
                            Console.WriteLine("Nazwa pliku: " + directoryEntry.mName);
                            Console.WriteLine("Rozmiar pliku (w KB): " + directoryEntry.mSize);
                            Console.WriteLine("Zawartosc: ");
                            foreach (char ch in content)
                            {
                                Console.Write(ch.ToString());
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            Console.WriteLine("");
        }
       }

}
