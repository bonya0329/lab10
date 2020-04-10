using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab10.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Id(string name, string data, string group)
        {

            string[] dataSplit = data.Split('.');
            string s = name + dataSplit[0] + dataSplit[1] + dataSplit[2] + group;
            string value = RandomString(s);

            return $"Привет! {name} + your id = {value}";
        }
        private static Random random = new Random();
        public static string RandomString(string str)
        {
            return new string(Enumerable.Repeat(str, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}