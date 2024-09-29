using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class InstructorController : Controller
    {

        // Sample Data
        List<Instructor> InstructorsList = new List<Instructor>()
            {
                new Instructor() {
                    InstructorId = 100,
                FirstName = "Maegan", LastName = "Borer",
                IsTenured=false, HiringDate=DateTime.Parse("2018-08-15"),
                Rank = Ranks.AssistantProfessor},
                new Instructor() {InstructorId = 200,
                FirstName = "Antonietta ", LastName = "Emmerich",
                IsTenured=true, HiringDate=DateTime.Parse("2022-08-15"),
                Rank = Ranks.AssociateProfessor},
                new Instructor() {InstructorId = 300,
                FirstName = "Antonietta", LastName = "Lesch",
                IsTenured=false, HiringDate=DateTime.Parse("2015-01-09"),
                Rank = Ranks.FullProfessor},
                new Instructor() {InstructorId = 400,
                FirstName = "Anjali", LastName = "Jakubowski",
                IsTenured=true, HiringDate=DateTime.Parse("2016-01-10"),
                Rank = Ranks.Adjunct}
            };

        // GET: InstructorController
        public IActionResult Index()
        {
            return View(InstructorsList); // retourne la vue Index.cshtml
        }


        public IActionResult DisplayAll()
        {
            // Par defaut la methode Index renvoie vers la vue Index
            // Si on souhaite retourner une vue avec un nom different
            // de celui de l'action on procede ainsi
            return View("Index", InstructorsList); // retourne la vue Index.cshtml
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", InstructorsList); // Redirection!
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            InstructorsList.Add(instructor);
            return View("Index", InstructorsList); // retourne la vue Index.cshtml avec la nouvelle liste
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Return View au sein de l'action Edit retournera la vue Edit.cshtml
            Instructor? intrs = InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == id);

            if (intrs != null)
            {
                return View(intrs);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            Instructor? instr = InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == instructor.InstructorId);

            if (instr != null)
            {
                instr.FirstName = instructor.FirstName;
                instr.LastName = instructor.LastName;
                instr.IsTenured = instructor.IsTenured;
                instr.HiringDate = instructor.HiringDate;
                instr.Rank = instructor.Rank;

                return View("Index", InstructorsList);
            }

            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            Instructor? instr = InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == id);


            if (instr != null)
            {
                return View(instr);
            }

            return NotFound();
        }


    }
}
