using CQRS_Projects.CQRS.Commands.UniversityCommand;
using CQRS_Projects.DAL.Context;
using CQRS_Projects.DAL.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Projects.CQRS.Handlers.UniversityHandlers
{
    public class CreateUniversityCommandHandler:IRequestHandler<CreateUniversityCommand>
    {
        private readonly ProductContext _productContext;

        public CreateUniversityCommandHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Unit> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            _productContext.Universities.Add(new University
            {
                City = request.City,
                Name = request.Name,
                FacultyCount = request.FacultyCount,
                Population = request.Population,
            });
            await _productContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
