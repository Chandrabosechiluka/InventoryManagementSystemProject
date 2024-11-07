using InventoryManagementSystemProject.Presentation;

namespace InventoryManagementSystemProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.ShowMenu();
        }
    }
}
