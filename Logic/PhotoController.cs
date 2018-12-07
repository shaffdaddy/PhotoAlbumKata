using LogicInterfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public class PhotoController
    {
        private readonly IPhotoAlbumRepository repo;

        public PhotoController(IPhotoAlbumRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Photo>> GetPhotosById(int id)
        {
            var photos = await repo.GetPhotos();

            return photos.Where(x => x.AlbumId == id).ToList();
        }
    }
}
