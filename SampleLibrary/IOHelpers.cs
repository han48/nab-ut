namespace SampleLibrary;

public class IOHelpers
{
    public static bool createDirectory(string path)
    {
        if (!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
        }
        return true;
    }
}
