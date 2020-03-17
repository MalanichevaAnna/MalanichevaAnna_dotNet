using System;
using System.Linq;
using LR_1.DL.ReaderWriter;
namespace LR_1.BL
{
    public static class ConsoleParser
    {
        private const string inputArgument = "-i";
        private const string outputArgument = "-o";
        private const string formatArgument = "-f";

        public static void ParseConsoleArguments(string[] args, out string inputFile, out string outputFile, out Format format)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length < 6)
            {
                throw new ArgumentException("Check the arguments");
            }

            if (!args.Contains(inputArgument) || !args.Contains(outputArgument) || !args.Contains(formatArgument))
            {
                throw new ArgumentException("Argument don't present");
            }

            if (args.Where((argument, index) => (index % 2 == 0) 
                        && argument != inputArgument
                        && argument != outputArgument
                        && argument != formatArgument).Count() != 0)
            {
                throw new ArgumentException("Invalid order of arguments");
            }

            inputFile = args[Array.IndexOf(args, inputArgument) + 1];
            outputFile = args[Array.IndexOf(args, outputArgument) + 1];

            string formatName = args[Array.IndexOf(args, formatArgument) + 1].ToLower();

            if (!Enum.TryParse(formatName, true, out format))
            {
                throw new ArgumentException("Invalid format name");
            }

            outputFile = string.Concat(outputFile, ".", formatName);
        }
    }
}
