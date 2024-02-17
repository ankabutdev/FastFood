using System.IO;
using System.Linq;
using System.Reflection;

namespace FastFood.Constants;

public class ContentConstant
{
    private static readonly string IMAGE_CONTENTS_PATH;
    private static readonly string IMAGE_ROOT_PATH = "Assets/Images";

    static ContentConstant()
    {
        string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

        string[] directories = currentPath.Split(Path.DirectorySeparatorChar);

        IMAGE_CONTENTS_PATH = string.Join(Path.DirectorySeparatorChar.ToString(), directories.Take(directories.Length - 3));
    }

    public static string GetImageContentsPath()
    {
        return IMAGE_CONTENTS_PATH + "\\";
    }

    public static string GetImageRootPath()
    {
        return GetImageContentsPath() + IMAGE_ROOT_PATH;
    }
}
