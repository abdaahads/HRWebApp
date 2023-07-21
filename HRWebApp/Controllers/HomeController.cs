using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRWebApp.Models;
using BOL;
using DAL;
using System.Collections.Generic;
using System.Globalization;

namespace HRWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd"));
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Employees()
    {
        List<Employee> empList = DBManager.GetAllEmployees();
        ViewBag.EmployeeList = empList;
        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Register(string id, string empName, string designation, string city, string department, string salary)
    {

        Employee newEmployee = new Employee(int.Parse(id), empName, designation, city, Enum.Parse<Department>(department), int.Parse(salary));
        DBManager.InsertEmployee(newEmployee);
        return RedirectToAction("Employees");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Console.WriteLine(id);
        DBManager.DeleteEmployeeById(id);
        return RedirectToAction("Employees");
    }

    [HttpGet]
    public IActionResult UpdateDetails(int id)
    {
        Employee foundEmp = DBManager.GetEmployeeById(id);

        if(foundEmp != null)
        {
            ViewBag.FOUNDEMP = foundEmp;
            return View();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateEmployeeDetails(string id, string empname, string designation, string department, string city, string salary)
    {
        Employee updateEmp = new Employee(int.Parse(id), empname, designation, city, Enum.Parse<Department>(department), int.Parse(salary));

        Console.WriteLine(updateEmp);
        DBManager.UpdateEmployee(updateEmp);

        return RedirectToAction("Employees");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

