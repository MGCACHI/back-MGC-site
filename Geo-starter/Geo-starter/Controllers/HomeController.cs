using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geo_starter.Models;

namespace Geo_starter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            //ViewBag.text1="0 such as 'NO information'";
            //List<car> car_list = new List<car>();
            //car_list.Add(new car() { Model = "Mersedes", Year = 1490 });
            //car_list.Add(new car() { Model = "BMW", Year = 2000 });
            //car_list.Add(new car() { Model = "Jiaguar", Year = 2010 });

            return View(/*car_list*/);
        }
        [HttpPost]
        public ActionResult About(string Name, string Surname)
        {
            ViewBag.name = Name;
            ViewBag.surname = Surname;
            return View();
        }

        //login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string surname, string mail, string job, string language, string phone, int age = 0)
        {
            if (checker(name, surname, mail, job, language, phone, age))
            {
                ViewBag.error = "შეავსეთ ყველა მოთხოვნა";
                return View();
            }
            else
            {
                MGC_DataDataContext db = new MGC_DataDataContext();

                student_table st = new student_table();
                st.Name = name;
                st.Surname = surname;
                st.Email = mail;
                st.Job = job;
                st.Language = language;
                st.Phone = phone;
                st.Age = age;

                db.student_tables.InsertOnSubmit(st);
                db.SubmitChanges();

                return RedirectToAction("List");
            }
        }
        public bool checker(string name, string surname, string mail, string job, string language, string phone, int age)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(job) || string.IsNullOrEmpty(language) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(age.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult List()
        {
            MGC_DataDataContext db = new MGC_DataDataContext();
            return View(db.student_tables.ToList());
        }
        public ActionResult Edit(int id)
        {
            MGC_DataDataContext db = new MGC_DataDataContext();

            return View(db.student_tables.Where(x=>x.ID==id).SingleOrDefault());
        }
        

    }
}