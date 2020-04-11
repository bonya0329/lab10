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

        Dictionary<string, Person> people = new Dictionary<string, Person>();
        [HttpPost]
        public string Id(string name, string data, string group)
        {

            string[] dataSplit = data.Split('.');
            string s = name + dataSplit[0] + dataSplit[1] + dataSplit[2] + group;
            string value = RandomString(s);
            
            people.Add(value, new Person() { Name = name , Data = data, Group = group});
            return $"Hello! {name} + your id = {value} go to /say ";           

        }

        public string SearchById(string id)
        {
            /*foreach (var studentId in people.Keys)
            {
                if (studentId == id) {
                    return ("Student " + people.Values);
                }
                
            }*/
            var trs = people.Select(a => String.Format("<tr><td>{0}</td><td>{1}</td></tr>", a.Key, a.Value));

            var tableContents = String.Concat(trs);

            var table = "<table>" + tableContents + "</table>";
            return table;
        }

        private static Random random = new Random();
        public static string RandomString(string str)
        {
            return new string(Enumerable.Repeat(str, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IActionResult ShowMessage()
        {
            return View();
        }
    }
}