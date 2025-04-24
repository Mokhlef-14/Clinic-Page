using ClincTask.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClincTask.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var doctors = _context.Doctors;
            return View(doctors.ToList());
        }
    }
}
