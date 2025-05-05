namespace Excercise1;
public class Viewer
{
    public void ShowResult(QuadraticEquation equation)
    {
        var result = equation.Resolve();

        if (result == null)
        {
            Console.WriteLine("No real roots exist.");
        }
        else if (result.Length == 1)
        {
            Console.WriteLine($"For the equation {equation.A}x^2 + {equation.B}x + {equation.C} = 0:");
            Console.WriteLine($"One root: x = {result[0]}");
        }
        else
        {
            Console.WriteLine($"For the equation {equation.A}x^2 + {equation.B}x + {equation.C} = 0:");
            Console.WriteLine($"Two roots: x1 = {result[0]}, x2 = {result[1]}");
        }
    }
}