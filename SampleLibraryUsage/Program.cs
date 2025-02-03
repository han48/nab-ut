using System;
using SampleLibrary;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please input action!!!");
        }
        string action = args[0].ToLower();

        switch (action)
        {
            case "sum":
            case "addition":
                {
                    _ = int.TryParse(args[1], out int input1);
                    _ = int.TryParse(args[2], out int input2);
                    int result = Mathematics.addition(input1, input2);
                    Console.WriteLine($"{input1} + {input2} = {result}");
                    break;
                }
            case "sumf":
            case "additionfloat":
                {
                    _ = float.TryParse(args[1], out float input1);
                    _ = float.TryParse(args[2], out float input2);
                    float result = Mathematics.addition(input1, input2);
                    Console.WriteLine($"{input1} + {input2} = {result}");
                    break;
                }
            case "sub":
            case "subtraction":
                {
                    _ = int.TryParse(args[1], out int input1);
                    _ = int.TryParse(args[2], out int input2);
                    int result = Mathematics.subtraction(input1, input2);
                    Console.WriteLine($"{input1} - {input2} = {result}");
                }
                break;
            case "div":
            case "division":
                {
                    _ = int.TryParse(args[1], out int input1);
                    _ = int.TryParse(args[2], out int input2);
                    int result = Mathematics.division(input1, input2);
                    Console.WriteLine($"{input1} / {input2} = {result}");
                }
                break;
            case "mul":
            case "multiplication":
                {
                    _ = int.TryParse(args[1], out int input1);
                    _ = int.TryParse(args[2], out int input2);
                    int result = Mathematics.multiplication(input1, input2);
                    Console.WriteLine($"{input1} * {input2} = {result}");
                }
                break;

            case "mkdir":
            case "create_directory":
                {
                    string path = args[1];
                    bool result = IOHelpers.createDirectory(path);
                    Console.WriteLine($"File create: {(result ? "Success" : "Fail")}");
                    break;
                }

            default:
                Console.WriteLine($"Un-support action {action}!!!");
                break;
        }
    }
}