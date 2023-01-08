using MediatR;

namespace CQRS_Projects.CQRS.Commands.UniversityCommand
{
    public class UpdateUniversityCommand: IRequest
    {
        public int UniversityID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Population { get; set; }
    }
}
