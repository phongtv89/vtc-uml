namespace Excercise1;

public class QuadraticEquation
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public double[] Resolve()
    {
        if (A == 0)
        {
            throw new InvalidOperationException("Coefficient A cannot be zero for a quadratic equation.");
        }

        double discriminant = B * B - 4 * A * C;

        if (discriminant < 0)
        {
            // No real roots
            return null;
        }
        else if (discriminant == 0)
        {
            // One real root
            double x = -B / (2 * A);
            return new double[] { x };
        }
        else
        {
            // Two real roots
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double x1 = (-B + sqrtDiscriminant) / (2 * A);
            double x2 = (-B - sqrtDiscriminant) / (2 * A);
            return new double[] { x1, x2 };
        }
    }
}