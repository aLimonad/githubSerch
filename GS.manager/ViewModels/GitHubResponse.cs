using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GS.manager.ViewModels
{
    public class GitHubResponse
    {
        [Key]
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Project> items { get; set; }
    }
}
