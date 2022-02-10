using GS.data.Models;
using GS.manager.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.manager.Managers
{
    public class ProjectManager
    {
        private GitHubManager _gManager = new GitHubManager();
       
        public async Task<IEnumerable<Project>> GetProjectsInDB(ApplicationContext db, string projectName)
        {
            var gitProjects = db.GitProjects
               .Where(p => p.SeacrhString.ToLower().Contains(projectName.ToLower()))
               .FirstOrDefault();
            var projects = new List<Project>();
            if (gitProjects != null)
            {
                projects = JsonConvert.DeserializeObject<List<Project>>(gitProjects.Results);
            }
            return projects;
        }

        public async Task<IEnumerable<Project>> SaveProjectsToDB(ApplicationContext db, string projectName)
        {
            var path = $"https://api.github.com/search/repositories?q={projectName}";
            var githubProjects = await _gManager.SearchProjects(path);
            var projects = githubProjects.items;
            if (projects.Count > 0)
            {
                var gitProect = new GitProject
                {
                    SeacrhString = path,
                    Results = System.Text.Json.JsonSerializer.Serialize(projects)
                };
                db.GitProjects.Add(gitProect);
                await db.SaveChangesAsync();
            }
            return projects;
        }
    }
}
