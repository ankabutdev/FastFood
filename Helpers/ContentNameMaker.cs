using System;
using System.IO;

namespace FastFood.Helpers;

public class ContentNameMaker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_" + Guid.NewGuid().ToString() + fileInfo.Extension;
    }
}
