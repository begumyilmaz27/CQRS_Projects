using CQRS_Projects.CQRS.Commands.StudentCommands;
using CQRS_Projects.CQRS.Handlers.StudentHandlers;
using CQRS_Projects.CQRS.Queries.StudentQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Projects.Controllers
{
    public class StudentController : Controller
    {

        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly GetAllStudentQueryHandler _getAllStudentQueryHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly GetStudentByIDQueryHandler _getStudentByIDQueryHandler1;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;


        public StudentController(
            CreateStudentCommandHandler createStudentCommandHandler,
            GetAllStudentQueryHandler getAllStudentQueryHandler,
            RemoveStudentCommandHandler removeStudentCommandHandler,
            GetStudentByIDQueryHandler getStudentByIDQueryHandler1,
            UpdateStudentCommandHandler updateStudentCommandHandler
            )
        {
            _createStudentCommandHandler = createStudentCommandHandler;
            _getAllStudentQueryHandler = getAllStudentQueryHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _getStudentByIDQueryHandler1 = getStudentByIDQueryHandler1;
            _updateStudentCommandHandler = updateStudentCommandHandler;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentCommand command)
        {
            _createStudentCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var values = _getAllStudentQueryHandler.Handle();
            return View(values);
        }
        public IActionResult DeleteStudent(int id)
        {
            _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var values = _getStudentByIDQueryHandler1.Handle(new GetStudentByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateStudent(UpdateStudentCommand command)
        {
            _updateStudentCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
