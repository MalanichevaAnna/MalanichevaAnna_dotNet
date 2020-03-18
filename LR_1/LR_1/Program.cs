using LR_1.BL;
using LR_1.BL.Ninject;
using Ninject;
using NLog;
using System;

namespace LR_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                ConsoleParser.ParseConsoleArguments(args, out var inputFile, out var outputFile, out var format);

                using var kernel = new StandardKernel(new Bindings(format));

                var fileProcessor = kernel.Get<FileProcessor>();

                var students = fileProcessor.Read(inputFile);

                fileProcessor.Write(outputFile, students);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }
    }
}
