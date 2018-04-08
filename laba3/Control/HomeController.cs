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
        private string _login;
        private string _Password;
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
                string _Login = null, _password = null;
                foreach (var a in str.Split("|"))
                {
                    _Login = a.Split(",").First();
                    _password = a.Split(",").Take(2).Last();

                    if (_Login == Login && _password == password)
                    {
                        _login = Login;
                        _Password = password;
                        var model = new Models.UserData(a.Split(",").Take(1).Last(), a.Split(",").Take(2).Last(), a.Split(",").Take(3).Last(), a.Split(",").Take(4).Last(), a.Split(",").Take(5).Last(), a.Split(",").Take(6).Last(), DateTime.Parse(a.Split(",").Take(7).Last()));
                        return View("Views/Home/HomeUser.cshtml",model);
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
            else if (password != null)
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
            var model = new Models.UserData(Login, password, Name, Email, Age, pol, DateTime.Now);

            return View("Views/Home/HomeUser.cshtml",model);
        }

        public IActionResult HomeUser()
        {
            StreamReader reader = new StreamReader(new FileStream("data.txt", FileMode.Open));
            string str = reader.ReadToEnd();
            reader.Close();
            string _Login = null, _password = null;
            foreach (var a in str.Split("|"))
            {
                _Login = a.Split(",").First();
                _password = a.Split(",").Take(2).Last();

                if (_Login == _login && _password == _Password)
                {
                    var model = new Models.UserData(a.Split(",").Take(1).Last(), a.Split(",").Take(2).Last(), a.Split(",").Take(3).Last(), a.Split(",").Take(4).Last(), a.Split(",").Take(5).Last(), a.Split(",").Take(6).Last(), DateTime.Parse(a.Split(",").Take(7).Last()));
                    return View();
                }
            }
            return View();
        }
    }
}