using MediatR;

namespace CQRS_Projects.CQRS.Commands.UniversityCommand
{
    public class RemoveUniversityCommand: IRequest
    {
        public RemoveUniversityCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
