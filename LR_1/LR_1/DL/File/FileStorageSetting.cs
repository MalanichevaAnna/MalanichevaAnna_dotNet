using System;
using System.Collections.Generic;
using System.Text;

namespace LR_1.Domain
{
    public class FileStorageSetting : IFileStorageSetting
    {
        public string FileNameWhithData { get;  set; }
        public FileStorageSetting(string pathFile)
        {
            FileNameWhithData = pathFile;
        }
        
    }
}
