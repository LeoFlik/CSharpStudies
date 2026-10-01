using UserRegistry.Entities;
using UserRegistry.Service;

namespace UserRegistry;

class Program
{
    static void Main(string[] args)
    {
        DataBase dataBase = new DataBase();
        RegistryService registryService = new RegistryService(dataBase);
        registryService.ShowMessages("Welcome to the User Registry System!");
        registryService.InitializeRegistryService();
    

     
    }
}
