using Logic;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("Must have at least one argument for album id");
            }

            try
            {
                var albumId = Convert.ToInt32(args[0]);

                var repo = new PhotoAlbumRepository("https://jsonplaceholder.typicode.com/photos");
                var controller = new PhotoController(repo);

                var photos = controller.GetPhotosById(albumId).GetAwaiter().GetResult();

                foreach (var photo in photos)
                {
                    Console.WriteLine("[" + photo.Id + "] " + photo.Title);
                }

                Console.ReadLine();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Argument " + args[0] + " must be an integer");
            }
        }
    }
}
