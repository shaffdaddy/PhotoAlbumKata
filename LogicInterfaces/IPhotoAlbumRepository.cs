using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface IPhotoAlbumRepository
    {
        Task<IEnumerable<Photo>> GetPhotos();
    }
}
