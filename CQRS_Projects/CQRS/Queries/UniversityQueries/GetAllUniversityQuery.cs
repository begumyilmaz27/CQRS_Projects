using CQRS_Projects.CQRS.Results.UniversityResults;
using MediatR;
using System.Collections.Generic;

namespace CQRS_Projects.CQRS.Queries.UniversityQueries
{
    //parantez içine propları tanımladığımız results ları gönderiyoruz. 
    public class GetAllUniversityQuery: IRequest<List<GetAllUniversityQueryResult>>
    {
    }
}
