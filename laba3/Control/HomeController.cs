using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace laba3.Control
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Login, string password)
        {
            if (Login == null && password == null)
            {
                ViewData["error"] = @"Введите логин и пароль";
                return View();
            }
            else
            {
                StreamReader reader = new StreamReader(new FileStream("data.txt", FileMode.Open));
                string str = reader.ReadToEnd();
                reader.Close();
                int h = 0;
                string _Login=null, _password=null;
                foreach(var a in str.Split("|"))
                {
                    _Login = a.Split(",").First();
                    _password = a.Split(",").Take(2).Last();
                 
                    if (_Login == Login && _password == password)
                    {
                        return View("Views/Home/HomeUser.cshtml");
                    }

                    else if (_Login == Login)
                    {
                        ViewData["error"] = @"Неверный пароль";
                        return View();
                    }
                    else
                    {
                        ViewData["error"] = @"Неверный логин или пароль";
                    }
                }
                return View();
            }
        }

        public IActionResult Registration(string Login,
        string password,
         string password1,
        string Name,
        string Email,
         string pol,
        string Age
       )
        {
            ViewData["color"] = "black";
            ViewData["pass"] = "Повторите пароль";
            if (password == password1 && password != null)
            {
                try
                {
                    Startup.UserDate.Add(new Models.UserData(Login, password, Name, Email, Age, pol, DateTime.Now));
                    System.IO.File.AppendAllText("Data.txt", new Models.UserData(Login, password, Name, Email, Age, pol, DateTime.Now).ToString());
                }
                catch (ArgumentNullException e)
                {
                    return View();
                }
            }
            else if(password != null)
            {
                ViewData["pass"] = "Пароли не совпадают";
                ViewData["color"] = "red";
                return View();
            }
            else
            {
                ViewData["pass"] = "Повторите пароль";
                return View();
            }
            return View("Views/Home/HomeUser.cshtml");
        }
    }
}