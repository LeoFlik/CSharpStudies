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
    
        public void ShowMessages( string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public ResultEnumService GetString(ref string input, string message)
        {
            Console.WriteLine(message);
            string temp = Console.ReadLine()?? string.Empty;
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

            } while(ResultEnumService == ResultEnumService.Exception);
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

        public ResultEnumService GetUsuary(ref Usuary usuary, string nameMessage, string docNumberMessage, string birthDateMessage, string addressMessage, string houseNumberMessage)
        {
            Console.Clear();
            string name = string.Empty;
            uint docNumber = 0;
            DateTime birthDate = DateTime.MinValue;
            string address = string.Empty;
            uint houseNumber = 0;

            if (GetString(ref name, nameMessage) == ResultEnumService.Exit)
                return ResultEnumService.Exit;

            if (GetUInt(ref docNumber, docNumberMessage) == ResultEnumService.Exit)
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
    }
}