using GS.data.Models;
using GS.manager.Managers;
using GS.manager.ViewModels;
using GS.site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GS.site.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private ProjectManager _pManager = new ProjectManager();

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> GetProjects(string projectName)
        {
            var projects = await _pManager.GetProjectsInDB(db, projectName);
            if (projects.Count() == 0)
            {
                projects = await _pManager.SaveProjectsToDB(db, projectName);
            }
            return PartialView(projects);
        }
    }
}
