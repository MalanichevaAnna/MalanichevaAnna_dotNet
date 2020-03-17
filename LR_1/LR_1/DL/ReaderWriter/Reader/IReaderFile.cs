using LR_1.Domain;
using System.Collections.Generic;

namespace LR_1.DL.ReaderWriter
{
    public interface IReaderFile
    {
        public IEnumerable<Student> ReaderFile(string path);
    }
}
