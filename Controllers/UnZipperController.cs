using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_api.Commons;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnZipperController : ControllerBase
    {

        [HttpGet]
        public string Get(string zipPath)
        {
            UnZipper.UnZipFolder(zipPath);
            return "UnZip OK";
        }

        [HttpPost]
        public string SendZipAndUnZipIt(IFormFile InputZip)
        {
            string fileName = InputZip.FileName;
            string targetFolderName = "/app/InputFolder";

            Directory.CreateDirectory(targetFolderName);
            FileStream fileStream = new FileStream(targetFolderName + "/" + fileName, FileMode.Create);

            InputZip.CopyTo(fileStream);
            fileStream.Close();
            fileStream.Dispose();
            UnZipper.UnZipFolder("/app/InputFolder/test.zip");

            return "Send and Unzip file OK : " + fileName;
        }
    }
}
