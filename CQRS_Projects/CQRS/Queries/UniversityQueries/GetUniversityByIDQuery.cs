using CQRS_Projects.CQRS.Results.UniversityResults;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRS_Projects.CQRS.Queries.UniversityQueries
{
    //ID ye göre getirme işlemi yaptığımız için ve tek bir değer döndüğü için List kullanmadık. GetAllUniversityQuery da list kullanmıştık. 
    public class GetUniversityByIDQuery: IRequest<GetUniversityByIDQueryResult>
    {
        public GetUniversityByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
