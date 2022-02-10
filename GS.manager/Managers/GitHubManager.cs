using GS.manager.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GS.manager.Managers
{
    public class GitHubManager
    {
        public async Task<GitHubResponse> SearchProjects(string uri)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "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");
            client.DefaultRequestHeaders.Add("User-Agent", "TestApp");
            var content = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<GitHubResponse>(content);
        }
    }
}
