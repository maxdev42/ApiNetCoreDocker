using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace web_api.Commons
{
    public class UnZipper
    {
        public static void UnZipFolder(String zipPath)
        {
            String pathCopy = zipPath;
            String unzipDirectory = pathCopy.Remove(pathCopy.Trim().Length - 4);
            ZipFile.ExtractToDirectory(zipPath, unzipDirectory);
        }
    }
}
