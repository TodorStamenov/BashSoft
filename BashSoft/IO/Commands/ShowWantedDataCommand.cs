namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("show")]
    public class ShowWantedDataCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public ShowWantedDataCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string username = this.Data[2];
                this.repository.GetStudentScoresFromCourse(courseName, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}