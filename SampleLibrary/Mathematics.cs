namespace SampleLibrary;

public class Mathematics : IMathematics
{
    public int addition(int a, int b)
    {
        return a + b;
    }

    public float addition(float a, float b)
    {
        return a + b;
    }

    public int subtraction(int a, int b)
    {
        return a - b;
    }

    public int division(int a, int b)
    {
        return a / b;
    }

    public int multiplication(int a, int b)
    {
        return a * b;
    }
}
