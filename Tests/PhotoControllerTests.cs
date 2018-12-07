using Logic;
using LogicInterfaces;
using Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class PhotoControllerTests
    {
        private IPhotoAlbumRepository repoMock;

        private PhotoController sut;

        [SetUp]
        public void Setup()
        {
            repoMock = Substitute.For<IPhotoAlbumRepository>();

            sut = new PhotoController(repoMock);
        }

        [Test]
        public async Task GivenAlbumIdWhenIdIsFoundThenListOfPhotosInAlbumIsReturned()
        {
            var expected = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 1,
                    Id = 1,
                    Title = "FirstPhoto"
                },
                new Photo()
                {
                    AlbumId = 1,
                    Id = 2,
                    Title = "SecondPhoto"
                }
            };

            int albumId = 1;

            repoMock.GetPhotos().Returns(expected);

            var actual = await sut.GetPhotosById(albumId);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GivenAlbumIdWhenIdIsFoundThenListOfPhotosMatchingPhotAlbumIdIsReturned()
        {
            var photos = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 1,
                    Id = 1,
                    Title = "FirstPhoto"
                },
                new Photo()
                {
                    AlbumId = 1,
                    Id = 2,
                    Title = "SecondPhoto"
                },
                new Photo()
                {
                    AlbumId = 2,
                    Id = 3,
                    Title = "ThirdPhoto"
                }
            };

            int albumId = 1;

            repoMock.GetPhotos().Returns(photos);

            var actual = await sut.GetPhotosById(albumId);
            var expected = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 1,
                    Id = 1,
                    Title = "FirstPhoto"
                },
                new Photo()
                {
                    AlbumId = 1,
                    Id = 2,
                    Title = "SecondPhoto"
                },
            };

            Assert.AreEqual(expected[0].AlbumId, actual.ElementAt(0).AlbumId);
            Assert.AreEqual(expected[0].Id, actual.ElementAt(0).Id);
            Assert.AreEqual(expected[0].Title, actual.ElementAt(0).Title);
            Assert.AreEqual(expected[1].AlbumId, actual.ElementAt(1).AlbumId);
            Assert.AreEqual(expected[1].Id, actual.ElementAt(1).Id);
            Assert.AreEqual(expected[1].Title, actual.ElementAt(1).Title);
        }

        [Test]
        public async Task GivenAlbumIdWhenIdIsNotFoundThenNoPhotosAreReturned()
        {
            int id = 1;
            var expected = new List<Photo>()
            {
                new Photo()
                {
                    AlbumId = 0,
                    Id = 1,
                    Title = "FirstPhoto"
                },
                new Photo()
                {
                    AlbumId = 0,
                    Id = 1,
                    Title = "SecondPhot"
                }
            };

            repoMock.GetPhotos().Returns(expected);

            var actual = await sut.GetPhotosById(id);

            Assert.IsEmpty(actual);
        }
    }
}