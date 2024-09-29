using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult ShowDetails(int id)
        {
            //create an instance of the Student model 
            // ... this data would normally come from a database ... 
            Student st = new Student();
            if (id == 10) //creating one sample student 
            {
                st.FirstName = "  Aylin";
                st.LastName = "Hopper";
                st.Major = Major.CS;
                st.IsVeteran = true;
                st.GPA = 4.0;
                st.AdmissionDate = DateTime.Parse("2022-08-15");
            }
            else  //creating another sample student 
            {
                st.FirstName = "Rahsaan";
                st.LastName = "Lubowitz";
                st.Major = Major.IT;
                st.IsVeteran = false;
                st.GPA = 3.95;
                st.AdmissionDate = DateTime.Parse("2021-01-07");
            }
            ViewBag.student = st; //pass the student to the view 
            return View();

        }
    }
}
