using CoreMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDBContext _context;
        private IWebHostEnvironment _hostEnvironment;
        public EmployeeController(CompanyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("FirstName,LastName")]
        Employee employeeData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var arrEmployeeData = new[] { employeeData };
                    string path = Path.Combine(this._hostEnvironment.WebRootPath, "Files/") + "";

                    String json = Newtonsoft.Json.JsonConvert.SerializeObject(arrEmployeeData);
                    System.IO.File.WriteAllText(path + employeeData.FirstName + "_" + employeeData.LastName + ".json", json);
                    
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        #region "Code of SQL Database"

        //public IActionResult Index()
        //{
        //    // var employees = await _context.Employees.ToListAsync();
        //    //var employees = new Employee();
        //    return View();
        //}

        //AddOrEdit Get Method
        //public async Task<IActionResult> AddOrEdit(int? employeeId)
        //{
        //    ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
        //    ViewBag.IsEdit = employeeId == null ? false : true;
        //    if (employeeId == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        var employee = await _context.Employees.FindAsync(employeeId);

        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(employee);
        //    }        
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddOrEdit(int employeeId, [Bind("EmployeeId,FirstName,LastName")]
        //Employee employeeData)
        //{
        //   // bool IsEmployeeExist = false;
        //    var arrEmployeeData = new[] { employeeData };
        //    string path = Path.Combine(this._hostEnvironment.WebRootPath, "Files/") + "";

        //    String json = Newtonsoft.Json.JsonConvert.SerializeObject(arrEmployeeData);
        //    System.IO.File.WriteAllText(path + "data.json", json);

        //    //Employee employee = await _context.Employees.FindAsync(employeeId);

        //    //if (employee != null)
        //    //{
        //    //    IsEmployeeExist = true;
        //    //}
        //    //else
        //    //{
        //    //    employee = new Employee();
        //    //}

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //           // employee.FirstName = employeeData.FirstName;
        //           // employee.LastName = employeeData.LastName;

        //           //if(IsEmployeeExist)
        //           // {
        //           //     _context.Update(employee);
        //           // }
        //           // else
        //           // {
        //           //     _context.Add(employee);
        //           // }                   
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employeeData);
        //}

        // Employee Details
        //public async Task<IActionResult> Details(int? employeeId)
        //{
        //    if (employeeId == null)
        //    {
        //        return NotFound();
        //    }
        //    var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);
        //}

        // GET: Employees/Delete/1
        //public async Task<IActionResult> Delete(int? employeeId)
        //{
        //    if (employeeId == null)
        //    {
        //        return NotFound();
        //    }
        //    var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        // POST: Employees/Delete/1
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int employeeId)
        //{
        //    var employee = await _context.Employees.FindAsync(employeeId);
        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        #endregion

    }
}
