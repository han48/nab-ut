using System.Diagnostics.CodeAnalysis;

namespace SampleLibrary;

[ExcludeFromCodeCoverage]
public class MathematicsV2 : IMathematics
{
    /// <summary>
    /// Addition 2 integer
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="OverflowException"></exception>
    public int addition(int a, int b)
    {
        if ((b > 0 && a > int.MaxValue - b) || (b < 0 && a < int.MinValue - b))
        {
            throw new OverflowException("Addition over flow number");
        }
        return a + b;
    }

    public float addition(float a, float b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtraction 2 integer
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int subtraction(int a, int b)
    {
        checked 
        {
            return a - b;
        }
    }

    /// <summary>
    /// Division 2 integer
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <exception cref="DivideByZeroException">When b is zero</exception>
    /// <returns></returns>
    public int division(int a, int b)
    {
        return a / b;
    }

    public int multiplication(int a, int b)
    {
        return a * b;
    }
}
