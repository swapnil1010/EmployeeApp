using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>();

        // GET: Employee
        public ActionResult Index()
        {
            return View(employees);
        }

        // GET: Employee/Create
        [Route("Employee/Create")]
        public ActionResult CreateEmployee()
        {
            //Employee employee = new Employee();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee); // Return the view with validation errors
            }
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        [Route("Employee/Edit/{id?}")]
        public ActionResult EditEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost,ActionName("EditEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee)
        {
            var existingEmployee = employees.Find(e => e.Id == employee.Id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Address = employee.Address;
            existingEmployee.Mobile = employee.Mobile;
            existingEmployee.DOB = employee.DOB;
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5

        public ActionResult Delete(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employees.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}
