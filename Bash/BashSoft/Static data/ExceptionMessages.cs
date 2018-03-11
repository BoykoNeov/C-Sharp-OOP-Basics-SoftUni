namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";
        public const string DataAlreadyInitializedException = "Data is already initialized!";
        public const string DataNotInitializedExceptionMessage = "The data structure must be initialized first in order to make any operations with it.";
        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";
        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";
        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to access needs a higher level of access priviliges than you currently have.";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders";
        public const string UnableToGoHigherInPartitionHierarchy = "You are trying to access a level higher than the root at current partition!";
        public const string InvalidCommand = "The command {0} is invalid";
        public const string UnableToParseNumber = "The sequence you have written is not a valid number.";
        public const string InvalidTakeQuantityParameter = "The take command expected does not match the format wanted!";
        public const string InvalidTakeCommand = "The take command is invalid!";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program";
        public const string ErrorDownloadingFile = "File download was unsuccessful";
    }
}