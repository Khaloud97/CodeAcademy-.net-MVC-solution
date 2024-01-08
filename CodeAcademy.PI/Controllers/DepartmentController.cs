using CodeAcademy.BLL.Interfaces;
using CodeAcademy.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.PI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentReposatory _departmentRepo;

        //IDepartmentReposatory depo = new DepartmentRepository();
        public DepartmentController(IDepartmentReposatory departmentrepo)
        {

            _departmentRepo = departmentrepo;
        }
        public IActionResult Index()
        {
            var deps = _departmentRepo.GetAll();
            return View(deps);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dep = _departmentRepo.Get(id.Value);
            return View(dep);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dep)
        {
            //if(dep == null)
            //{
            //    return badrequest();
            //}
            _departmentRepo.Create(dep);

            return RedirectToAction("Index");
        }

    }
}