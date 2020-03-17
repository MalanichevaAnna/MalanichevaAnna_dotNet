using LR_1.DL.ReaderWriter;
using LR_1.DL.ReaderWriter.Writer;
using LR_1.Domain;
using Ninject.Modules;

namespace LR_1.BL.Ninject
{
    internal class Bindings : NinjectModule
    {
        private readonly Format _format;

        public Bindings(Format format)
        {
            _format = format;
        }

        public override void Load()
        {
            Bind<IReaderFile>().To<Reader>();
            Bind<FileProcessor>().To<FileProcessor>().InSingletonScope();
            switch (_format)
            {
                case Format.Json:
                    Bind<IWriter>().To<JsonWriter>();
                    break;
                case Format.Xlsx:
                    Bind<IWriter>().To<ExcelWriter>();
                    break;
                default:
                    break;
            }
        }
    }
}
