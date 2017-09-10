namespace BashSoft.Exceptions
{
    using System;

    public class InvalidFileNameException : Exception
    {
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public InvalidFileNameException(string message)
            : base(message)
        {
        }

        public InvalidFileNameException()
            : base(ForbiddenSymbolsContainedInName)
        {
        }
    }
}