using CQRS_Projects.CQRS.Queries.UniversityQueries;
using CQRS_Projects.CQRS.Results.UniversityResults;
using CQRS_Projects.DAL.Context;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Projects.CQRS.Handlers.UniversityHandlers
{
    public class GetUniversityByIDQueryHandler : IRequestHandler<GetUniversityByIDQuery, GetUniversityByIDQueryResult>
    {
        private readonly ProductContext _context;

        public GetUniversityByIDQueryHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<GetUniversityByIDQueryResult> Handle(GetUniversityByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Universities.FindAsync(request.id);
            return new GetUniversityByIDQueryResult
            {
                UniversityID = values.UniversityID,
                City = values.City,
                Name = values.Name,
                Population = values.Population
            };
        }
    }
}
