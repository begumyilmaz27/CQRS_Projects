using CQRS_Projects.CQRS.Queries.UniversityQueries;
using CQRS_Projects.CQRS.Results.UniversityResults;
using CQRS_Projects.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Projects.CQRS.Handlers.UniversityHandlers
{
    public class GetAllUniversityQueryHandler:IRequestHandler<GetAllUniversityQuery,List<GetAllUniversityQueryResult>>
    {
        private readonly ProductContext _context;

        public GetAllUniversityQueryHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllUniversityQueryResult>> Handle(GetAllUniversityQuery request, CancellationToken cancellationToken)
        {
            //veri listleme işleminde universities den sonra select diyorduk. 
            return await _context.Universities.Select(x=>
            new GetAllUniversityQueryResult
            {
                UniversityID = x.UniversityID,
                Name = x.Name,
                Town = x.City
            }).AsNoTracking().ToListAsync();
        }
    }
}
