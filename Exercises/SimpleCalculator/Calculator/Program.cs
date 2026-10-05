namespace Calculator;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Simple Calculator!");
        Console.WriteLine("Enter the first number:");
        double num1 = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
        Console.WriteLine("Enter the second number:");
        double num2 = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
        Console.WriteLine("What do you want to do with those numbers?");
        Console.WriteLine("[A]dd");
        Console.WriteLine("[S]ubtract");
        Console.WriteLine("[M]ultiply");
        Console.WriteLine("[D]ivide");
        string operation = Console.ReadLine() ?? string.Empty;
        double Sum(double a, double b) => a + b;
        double Subtract(double a, double b) => a - b;
        double Multiply(double a, double b) => a * b;
        double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN; // Return NaN to indicate an error
            }
            return a / b;
        }

        double result = operation.ToUpper() switch
        {
            "A" => Sum(num1, num2),
            "S" => Subtract(num1, num2),
            "M" => Multiply(num1, num2),
            "D" => Divide(num1, num2),
            _ => throw new InvalidOperationException("Invalid operation")
        };

        Console.WriteLine($"The result is: {result}");
     
    }




    
}
