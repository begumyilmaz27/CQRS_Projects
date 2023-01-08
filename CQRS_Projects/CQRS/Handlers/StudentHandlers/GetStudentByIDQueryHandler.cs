using CQRS_Projects.CQRS.Queries.StudentQueries;
using CQRS_Projects.CQRS.Results.StudentResults;
using CQRS_Projects.DAL.Context;

namespace CQRS_Projects.CQRS.Handlers.StudentHandlers
{
    public class GetStudentByIDQueryHandler
    {
        private readonly ProductContext _context;
        private int id;

        public GetStudentByIDQueryHandler(ProductContext context)
        {
            _context = context;
        }

        public GetStudentByIDQueryHandler(int id)
        {
            this.id = id;
        }

        public GetStudentByIDQueryResult Handle(GetStudentByIDQuery query)
        {
            var values = _context.Students.Find(query.id);
            return new GetStudentByIDQueryResult
            {
                Age = values.Age,
                City = values.City,
                Name = values.Name,
                Surname = values.Surname,
                StudentID = values.StudentID
            };
        }
    }
}
