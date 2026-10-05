namespace ToDoConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        List<string> tasks = [];
        //char userInput = ' ';
        Console.WriteLine("Hello!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all tasks");
            Console.WriteLine("[A]dd a task");
            Console.WriteLine("[R]emove a task");
            Console.WriteLine("[E]xit");
           

            char userChoice = char.Parse(Console.ReadKey(true).KeyChar.ToString());
            char userInput = char.ToUpper(userChoice);

            switch (userInput)
            {
                case 'S':
                    PrintTasks(tasks);
                    break;
                case 'A':
                    AddTask(tasks);
                    break;
                case 'R':
                    RemoveTask(tasks);
                    break;
                case 'E':
                    exit = true;
                    Console.WriteLine("Exiting the application.");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

       

    }

    public static void PrintTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            ShowEmptyMessage();
            return;
        }
        else
        {
            Console.WriteLine("Your tasks list:");
        }
        foreach (var task in tasks)
        {
            int index = tasks.IndexOf(task) + 1;
            Console.WriteLine($"{index}. {task}");
        }
        Console.WriteLine();
    }


    public static void AddTask(List<string> tasks)
    {
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("Enter a new task (3-50 characters):");
            string input = Console.ReadLine() ?? "";
            if (IsInputValid(input, tasks))
            {
                tasks.Add(input);
                Console.WriteLine($"Task '{input}' added.");
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    public static bool IsInputValid(string input, List<string> tasks)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        else if (input.Length < 3 || input.Length > 50)
        {
            return false;
        }
        else if (tasks.Contains(input))
        {
            return false;
        }
        return true;
    }

    public static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            ShowEmptyMessage();
            return;
        }
        Console.WriteLine("Enter the task number you want to remove:");
        PrintTasks(tasks);
        int taskNumber;
        bool isValidInput = false;
        while (!isValidInput)
        {
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    isValidInput = true;
                    string removedTask = tasks[taskNumber - 1];
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine($"Task '{removedTask}' removed.");
                }
                else
                {
                    Console.WriteLine($"Invalid task number. Please enter a number between 1 and {tasks.Count}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid task number.");
            }
        }
    }
    
    private static void ShowEmptyMessage()
    {
        Console.WriteLine("No tasks found.");
    }

}

