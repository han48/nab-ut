using SampleLibrary;

namespace SampleLibraryTests;

[TestClass]
public sealed class IOHelpersTest
{
    [TestMethod]
    public void CreateDirectory_NormalCase()
    {
        string path = "test";
        Directory.Delete(path);

        bool result = IOHelpers.createDirectory(path);
        Assert.AreEqual(Directory.Exists(path), result);

        result = IOHelpers.createDirectory(path);
        Assert.AreEqual(Directory.Exists(path), result);

        Directory.Delete(path);
    }
}
