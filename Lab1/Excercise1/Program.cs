// See https://aka.ms/new-console-template for more information
// https://claude.ai/public/artifacts/35c01647-f563-48e7-8404-393ffd0fe7f7
Console.WriteLine("Quadratic Equation Solver");
Console.WriteLine("Equation format: Ax^2 + Bx + C = 0");

// Input coefficients
Console.Write("Enter coefficient A: ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter coefficient B: ");
double b = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter coefficient C: ");
double c = Convert.ToDouble(Console.ReadLine());

// Create an instance of the solver
QuadraticEquation equation = new QuadraticEquation { A = a, B = b, C = c };

Viewer viewer = new Viewer();
viewer.ShowResult(equation);

