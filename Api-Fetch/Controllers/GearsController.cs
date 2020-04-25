using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api_Fetch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Api_Fetch.Controllers
{
    public class GearsController : Controller
    {
        private readonly IConfiguration _config;
        public GearsController(IConfiguration config)
        {
            _config = config;
        }
        //COMPUTED PROPERTY FOR THE CONNECTION
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
 


        // GET: Gears
        public async Task<ActionResult> Index()
        {
            var gear =  await GetGearRecord();
            return View(gear);
        }

        private async Task<GearRecord> GetGearRecord()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync($"https://api.sierra.com/api/1.0/products/?api_key=a13e35793a797e828b12e82f51d4ba88");
                return JsonConvert.DeserializeObject<GearRecord>(content);
            }

        }
    
 


        // GET: Gears/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gears/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Gears/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gears/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Gears/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        //private static async Task<Gear> GearSearch(string name)
        //{
        //    string key = "AIzaSyAF3M0uelGbxyrv6QuVqrHcfFxM3a3nelc";

        //    string queryName = "";

        //    if (title != null)
        //    {
        //        queryName = title;
        //    }

        //    string queryAuthor = "";

        //    if (author != null && queryName != null)
        //    {
        //        queryAuthor = $"+inauthor:{author}";
        //    }
        //    else if (author != null)
        //    {
        //        queryAuthor = $"inauthor:{author}";
        //    }


        //    string queries = $"{queryName}{queryAuthor}";

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var content = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={queries}&key={key}");
        //            return JsonConvert.DeserializeObject<BookRecord>(content);
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        // POST: Gears/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}