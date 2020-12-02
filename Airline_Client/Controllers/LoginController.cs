using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Airline_Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Airline_Client.Controllers
{
    public class LoginController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));
        // GET: Login/Create
        [HttpGet]
        public ActionResult Login(string error="")
        {
            ViewBag.message = error;
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User user)
        {
            _log4net.Info("User Login Initiated");
            using (var httpClient = new HttpClient())
            {

                StringContent content1 = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response1 = await httpClient.PostAsync("https://localhost:44311/api/auth/login", content1))
                {
                    if (!response1.IsSuccessStatusCode)
                    {
                        ViewBag.message = "Invalid Login Credentials";
                        return View(user);
                    }





                    string stringJWT = await response1.Content.ReadAsStringAsync();
                    var jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);

                    _log4net.Info(user.Username + " successfully logged in");
                    HttpContext.Session.SetString("token", jwt.Token);
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

                    HttpContext.Session.SetString("Username", user.Username);
                    return RedirectToAction("Index", "Ticket");

                }


            }
        }
        public ActionResult Logout()
        {
            
            HttpContext.Session.Remove("token");
            // HttpContext.Session.SetString("user", null);
            
            HttpContext.Session.Clear();
            _log4net.Info(HttpContext.Session.GetString("Username") + " Successfully logged out");
            return View("Login");
        }
    }
}