using LogicInterfaces;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Logic
{
    public class PhotoAlbumRepository : IPhotoAlbumRepository
    {
        private string url;

        public PhotoAlbumRepository(string url)
        {
            this.url = url;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Photo>>(content);
            }
        }
    }
}
