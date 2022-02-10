using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.data.Models;
using System.Linq;
using Newtonsoft.Json;
using GS.manager.ViewModels;
using System.Net.Http;
using GS.manager.Managers;

namespace GS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ApplicationContext db;
        private ProjectManager _pManager = new ProjectManager();

        public ProjectController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("{projectName}")]
        public async Task<ActionResult<IEnumerable<Project>>> Get(string projectName)
        {
            var projects = _pManager.GetProjectsInDB(db, projectName);

            return Ok(projects);
        }

        [HttpPost("{projectName}")]
        public async Task<ActionResult<GitProject>> Post(string projectName)
        {
            var projects = await _pManager.GetProjectsInDB(db, projectName);
            if(projects.Count() == 0)
            {
                projects = await _pManager.SaveProjectsToDB(db, projectName);
            }
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GitProject>> Delete(int id)
        {
            GitProject proj = db.GitProjects.FirstOrDefault(x => x.Id == id);
            if (proj == null)
            {
                return NotFound();
            }
            db.GitProjects.Remove(proj);
            await db.SaveChangesAsync();
            return Ok(proj);
        }
    }
}
