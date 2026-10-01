using System.Globalization;
using UserRegistry.Entities;
namespace UserRegistry.Service
{
    public class RegistryService
    {
        public DataBase DataBase { get; set; }
        public ResultEnumService ResultEnumService { get; set; }

        public RegistryService(DataBase dataBase)
        {
            DataBase = dataBase;
            ResultEnumService = ResultEnumService.Success;
        }

        public void ShowMessages(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public ResultEnumService GetString(ref string input, string message)
        {
            Console.WriteLine(message);
            string temp = Console.ReadLine() ?? string.Empty;
            if (temp == "s" || temp == "S")
            {
                ResultEnumService = ResultEnumService.Exit;
                return ResultEnumService;
            }
            else
            {
                ResultEnumService = ResultEnumService.Success;
                input = temp;

            }
            Console.Clear();
            return ResultEnumService;
        }

        public ResultEnumService GetUInt(ref uint input, string message)
        {
            do
            {

                try
                {
                    Console.WriteLine(message);
                    string temp = Console.ReadLine() ?? string.Empty;
                    if (temp == "s" || temp == "S")
                    {
                        ResultEnumService = ResultEnumService.Exit;
                        return ResultEnumService;
                    }
                    else
                    {
                        input = uint.Parse(temp);
                        ResultEnumService = ResultEnumService.Success;
                    }

                }
                catch (FormatException ex)
                {
                    ResultEnumService = ResultEnumService.Exception;
                    ShowMessages($"Error: {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    ResultEnumService = ResultEnumService.Exception;
                    ShowMessages($"Error: {ex.Message}");

                }
                catch (ArgumentException ex)
                {
                    ResultEnumService = ResultEnumService.Exception;
                    ShowMessages($"Error: {ex.Message}");
                }

            } while (ResultEnumService == ResultEnumService.Exception);
            Console.Clear();
            return ResultEnumService;
        }

        public ResultEnumService GetDateTime(ref DateTime input, string message)
        {
            do
            {
                try
                {
                    Console.WriteLine(message);
                    string temp = Console.ReadLine() ?? string.Empty;
                    if (temp == "s" || temp == "S")
                    {
                        ResultEnumService = ResultEnumService.Exit;
                        return ResultEnumService;
                    }
                    else
                    {
                        input = DateTime.ParseExact(temp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        ResultEnumService = ResultEnumService.Success;
                    }
                }
                catch (FormatException ex)
                {
                    ResultEnumService = ResultEnumService.Exception;
                    ShowMessages($"Error: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    ResultEnumService = ResultEnumService.Exception;
                    ShowMessages($"Error: {ex.Message}");
                }

            } while (ResultEnumService == ResultEnumService.Exception);
            Console.Clear();
            return ResultEnumService;
        }

        public ResultEnumService RegistryUser(ref Usuary usuary, string nameMessage, string docNumberMessage, string birthDateMessage, string addressMessage, string houseNumberMessage)
        {
            Console.Clear();
            string name = string.Empty;
            string? docNumber = string.Empty;
            DateTime birthDate = DateTime.MinValue;
            string address = string.Empty;
            uint houseNumber = 0;

            if (GetString(ref name, nameMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            if (GetString(ref docNumber, docNumberMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            if (GetDateTime(ref birthDate, birthDateMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            if (GetString(ref address, addressMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            if (GetUInt(ref houseNumber, houseNumberMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            usuary = new Usuary(name, docNumber, birthDate, address, houseNumber);
            DataBase.AddUsuary(usuary);
            Console.WriteLine("Adding user: ");
            PrintUserInfo(usuary);
            ShowMessages("User added successfully!");
            return ResultEnumService.Success;
        }

        public void PrintUserInfo(Usuary usuary)
        {
            Console.WriteLine(usuary.ToString());
        }
        public void PrintUserInfoList(List<Usuary> usuaryList)
        {
            foreach (var usuary in usuaryList)
            {
                PrintUserInfo(usuary);
                Console.WriteLine("--------------------");
            }
        }

        public void SerchUser()
        {
            Console.WriteLine("Enter the document number to search for users (or 's' to exit):");
            string input = Console.ReadLine() ?? string.Empty.ToLower();
            if (input == "s")
                return;
            List<Usuary>? usuaryList = DataBase.GetUsuaryByDocNumber(input);
            if (usuaryList != null && usuaryList.Count > 0)
            {
                Console.WriteLine($"Found {usuaryList.Count} user(s) with DocNumber {input}:");
                PrintUserInfoList(usuaryList);
            }
            else
            {
                Console.WriteLine($"No users found with DocNumber {input}.");
            }
            ShowMessages((string.Empty));
        }

        public void RemoveUser()
        {
            Console.WriteLine("Enter the document number to remove users (or 's' to exit):");
            string input = Console.ReadLine() ?? string.Empty.ToLower();
            if (input == "s")
                return;
            List<Usuary>? usuaryList = DataBase.RemoveUsuaryByDocNumber(input);
            if (usuaryList != null && usuaryList.Count > 0)
            {
                Console.WriteLine($"Removed {usuaryList.Count} user(s) with DocNumber {input}:");
                PrintUserInfoList(usuaryList);
            }
            else
            {
                Console.WriteLine($"No users found with DocNumber {input}.");
            }
            ShowMessages((string.Empty));
        }


        public void InitializeRegistryService()
        {
            DataBase dataBase = new DataBase();
            RegistryService registryService = new RegistryService(dataBase);

            while (true)
            {
                Console.WriteLine("User Registry System");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Search User by Document Number");
                Console.WriteLine("3. Remove User by Document Number");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        Usuary usuary = null!;
                        registryService.RegistryUser(ref usuary, "Enter Name (or 's' to exit):", "Enter Document Number (or 's' to exit):", "Enter Birth Date (dd/MM/yyyy) (or 's' to exit):", "Enter Address (or 's' to exit):", "Enter House Number (or 's' to exit):");
                        break;
                    case "2":
                        registryService.SerchUser();
                        break;
                    case "3":
                        registryService.RemoveUser();
                        break;
                    case "4":
                        return;
                    default:
                        registryService.ShowMessages("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

