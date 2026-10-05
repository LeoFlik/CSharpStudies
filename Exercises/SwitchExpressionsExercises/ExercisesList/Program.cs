namespace ExercisesList;

class Program
{
    static void Main(string[] args)
    {
        // try
        // {
        //     Console.WriteLine("Enter a month number (1-12):");
        //     int monthNumber = int.Parse(Console.ReadLine() ?? "0");
        //     Console.WriteLine("The month is: " + GetMonthName(monthNumber));
        // }
        // catch (ArgumentOutOfRangeException ex)
        // {
        //     Console.WriteLine($"Error: {ex.Message}");
        // }
        // 
       // Console.WriteLine("Enter your age:");
       Console.Write(DescribeObject("Hello, World!"));
    }

    static string GetMonthName(int monthNumber) => monthNumber switch
    {
        1 => "January",
        2 => "February",
        3 => "March",
        4 => "April",
        5 => "May",
        6 => "June",
        7 => "July",
        8 => "August",
        9 => "September",
        10 => "October",
        11 => "November",
        12 => "December",
        _ => throw new ArgumentOutOfRangeException(nameof(monthNumber), "Month number must be between 1 and 12.")
    };

    static string GetAgeCategory(int age) => age switch
    {
        < 0 => throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative."),
        < 13 => "Child",
        < 20 => "Teenager",
        < 65 => "Adult",
        _ => "Senior"
    };

    static string? DescribeObject(object? obj) 
    {
        return obj switch
        {
        null => "This is a null value.",
        int i when i < 0 => $"This is a negative integer: {i}",
        int i when i == 0 => "This is zero.",
        int i when i%2 == 0 => $"This is an even integer: {i}",
        int i when i%2 != 0 => $"This is an odd integer: {i}",
        int i => $"This is an integer: {i}",
        string s => $"This is a string: {s}",
        bool b => $"This is a boolean: {b}",
        _ => "This is an unknown type."
    };
    }
}
