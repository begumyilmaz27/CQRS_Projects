using CQRS_Projects.CQRS.Commands.StudentCommands;
using CQRS_Projects.CQRS.Commands.UniversityCommand;
using CQRS_Projects.DAL.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Projects.CQRS.Handlers.UniversityHandlers
{
    public class RemoveUniversityCommandHandler:IRequestHandler<RemoveUniversityCommand>
    {
        private readonly ProductContext _context;

        public RemoveUniversityCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveUniversityCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Universities.Find(request.id);
            _context.Universities.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;  
        }
    }
}
