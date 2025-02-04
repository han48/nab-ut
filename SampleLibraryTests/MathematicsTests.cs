using SampleLibrary;

namespace SampleLibraryTests;

[TestClass]
public sealed class MathematicsTests
{
    Mathematics Mathematics = new Mathematics();

    [TestMethod]
    public void Addition_NormalCase()
    {
        int result = Mathematics.addition(10, 5);
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Addition_FloatNormalCase()
    {
        float result = Mathematics.addition(10f, 5f);
        Assert.AreEqual(15f, result);
    }

    [TestMethod]
    public void Subtraction_NormalCase()
    {
        int result = Mathematics.subtraction(10, 5);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Division_NormalCase()
    {
        int result = Mathematics.division(10, 5);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Multiplication_NormalCase()
    {
        int result = Mathematics.multiplication(10, 5);
        Assert.AreEqual(50, result);
    }
}
