using ASPBookProject.Models;
using ASPBookProject.Services.FakeDataService;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class InstructorController : Controller
    {
        // Injection de dependance
        private readonly IFakeDataService _fakeDataService;

        // Sample Data
        // List<Instructor> InstructorsList = new List<Instructor>()
        //     {
        //         new Instructor() {
        //             InstructorId = 100,
        //         FirstName = "Maegan", LastName = "Borer",
        //         IsTenured=false, HiringDate=DateTime.Parse("2018-08-15"),
        //         Rank = Ranks.AssistantProfessor},
        //         new Instructor() {InstructorId = 200,
        //         FirstName = "Antonietta ", LastName = "Emmerich",
        //         IsTenured=true, HiringDate=DateTime.Parse("2022-08-15"),
        //         Rank = Ranks.AssociateProfessor},
        //         new Instructor() {InstructorId = 300,
        //         FirstName = "Antonietta", LastName = "Lesch",
        //         IsTenured=false, HiringDate=DateTime.Parse("2015-01-09"),
        //         Rank = Ranks.FullProfessor},
        //         new Instructor() {InstructorId = 400,
        //         FirstName = "Anjali", LastName = "Jakubowski",
        //         IsTenured=true, HiringDate=DateTime.Parse("2016-01-10"),
        //         Rank = Ranks.Adjunct}
        //     };

        // Constructor Injection
        public InstructorController(IFakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }

        // GET: InstructorController
        public IActionResult Index()
        {
            return View(_fakeDataService.InstructorsList); // retourne la vue Index.cshtml
        }


        public IActionResult DisplayAll()
        {
            // Par defaut la methode Index renvoie vers la vue Index
            // Si on souhaite retourner une vue avec un nom different
            // de celui de l'action on procede ainsi
            // return View("Index", _fakeDataService.InstructorsList); // retourne la vue Index.cshtml
            return View("Index");
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", _fakeDataService.InstructorsList); // Redirection!
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            // verification de la validite du model avec ModelState
            if (!ModelState.IsValid)
            {
                return View();
            }

            _fakeDataService.InstructorsList.Add(instructor);
            // return View("Index", _fakeDataService.InstructorsList); // retourne la vue Index.cshtml avec la nouvelle liste
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            // Return View au sein de l'action Edit retournera la vue Edit.cshtml
            Instructor? intrs = _fakeDataService.InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == id);

            if (intrs != null)
            {
                return View(intrs);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            // verification de la validite du model avec ModelState
            if (!ModelState.IsValid)
            {
                return View();
            }

            Instructor? instr = _fakeDataService.InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == instructor.InstructorId);

            if (instr != null)
            {
                instr.FirstName = instructor.FirstName;
                instr.LastName = instructor.LastName;
                instr.IsTenured = instructor.IsTenured;
                instr.HiringDate = instructor.HiringDate;
                instr.Rank = instructor.Rank;

                // return View("Index", _fakeDataService.InstructorsList);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Instructor? instr = _fakeDataService.InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == id);

            if (instr != null) // Si l'instructeur est trouvé
            {
                return View(instr); // On retourne la vue Delete.cshtml avec l'instructeur à supprimer
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
            //return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int InstructorId)

        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Instructor? instr = _fakeDataService.InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == InstructorId);


            if (instr != null) // Si l'instructeur est trouvé
            {
                _fakeDataService.InstructorsList.Remove(instr); // On le supprime de la liste
                // return View("Index", _fakeDataService.InstructorsList); // On retourne la vue Index.cshtml avec la nouvelle liste
                return RedirectToAction("Index");
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
        }

        [HttpGet]
        public IActionResult ShowDetails(int id)
        {
            Instructor? instr = _fakeDataService.InstructorsList.FirstOrDefault<Instructor>(ins => ins.InstructorId == id);


            if (instr != null)
            {
                return View(instr);
            }

            return NotFound();
        }


    }
}
