using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace GhanbodeWebbApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
        public IActionResult Todolist(int id, string title, string description)
        {
            
            return View();
        }

        public IActionResult Todolist(int id, string title, string description)
        {
            TodolistItem newItem = new TodolistItem
            {
                Id = id,
                Title = title,
                Description = description
            };

            todolist.Add(newItem);

            
            return View("Todolist", todolist);
        }

    }
    
}