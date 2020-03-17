using System;
using System.Collections.Generic;
using System.Text;

namespace LR_1.DL.ReaderWriter
{
    public interface IWriter
    {
        public void Write(StudentAndSummaryMarkInfo info, string path);
    }
}
