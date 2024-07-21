using BasicAPI.Data;
using BasicAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace BasicAPI
{
    public class ExchangeService
    {

        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public ExchangeService(HttpClient httpClient,ApplicationDbContext context)
        {

            _httpClient = httpClient;
            _context= context;

        }

        public async Task<List<Post>>GetPost()
        {

            var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            return JsonConvert.DeserializeObject<List<Post>>(response);

        }

        public async Task SavePost()
        {

            var posts = await GetPost();

            foreach (var item in posts)
            {
                _context.Post.Add(item);
            }

            await _context.SaveChangesAsync();
        }


    }
}
