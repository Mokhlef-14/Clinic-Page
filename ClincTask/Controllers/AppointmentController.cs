using ClincTask.Data;
using ClincTask.Models;
using Hospital512.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Hospital512.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _Context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var appointments = _Context.Appointments.Include(e => e.Doctor);
            return View(appointments.ToList());
        }


        public IActionResult Book(int id)
        {
            var doc = _Context.Doctors.FirstOrDefault(d => d.Id == id);
            return View(doc);
        }
        [HttpPost]
        public IActionResult Book(Appointment appoint, int DoctorId)
        {

            var doc = _Context.Doctors.FirstOrDefault(d => d.Id == DoctorId);
            if (appoint.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                return View(doc);
            }



            _Context.Add(new Appointment
            {
                PatientName = appoint.PatientName,

                Date = appoint.Date,
                Time = appoint.Time,
                DoctorID = doc.Id
            });
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var appointment = _Context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                _Context.Appointments.Remove(appointment);
                _Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }


}