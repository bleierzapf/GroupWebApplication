using System;
using System.Collections.Generic;
using GroupWebApplication.Models;
using Org.BouncyCastle.Crypto.Engines;

namespace GroupWebApplication.Data
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ImageDbContext>
    {
        protected override void Seed(ImageDbContext context)
        {
            var images = new List<ImageModel>
            {
                new ImageModel
                {
                    Date = "2019-01-01", Media_Type = "image", Title = "The Sombrero Galaxy in Infrared",
                    Url = "https://apod.nasa.gov/apod/image/1901/sombrero_spitzer_1080.jpg",
                    Explanation =
                        "This floating ring is the size of a galaxy.  In fact, it is a galaxy -- or at least part of one: the photogenic Sombrero Galaxy, one of the largest galaxies in the nearby Virgo Cluster of Galaxies.  The dark band of dust that obscures the mid-section of the Sombrero Galaxy in optical light actually glows brightly in infrared light.  The featured image, digitally sharpened, shows the infrared glow, recently recorded by the orbiting Spitzer Space Telescope, superposed in false-color on an existing image taken by NASA's Hubble Space Telescope in optical light. The Sombrero Galaxy, also known as M104, spans about 50,000 light years across and lies 28 million light years away.  M104 can be seen with a small telescope in the direction of the constellation Virgo.   News: New Horizons Spacecraft Passes Ultima Thule"
                },
                new ImageModel
                {
                    Date = "2019-03-15", Media_Type = "image", Title = "A View Toward M101",
                    Url = "https://apod.nasa.gov/apod/image/1903/M101n8_4tp_Kaltseis1024c.jpg",
                    Explanation =
                        "Big, beautiful spiral galaxy M101 is one of the last entries in Charles Messier's famous catalog, but definitely not one of the least. About 170,000 light-years across, this galaxy is enormous, almost twice the size of our own Milky Way galaxy. M101 was also one of the original spiral nebulae observed by Lord Rosse's large 19th century telescope, the Leviathan of Parsontown. M101 shares this modern telescopic field of view with more distant background galaxies, foreground stars within the Milky Way, and a companion dwarf galaxy NGC 5474 (lower right). The colors of the Milky Way stars can also be found in the starlight from the large island universe. Its core is dominated by light from cool yellowish stars. Along its grand design spiral arms are the blue colors of hotter, young stars mixed with obscuring dust lanes and pinkish star forming regions. Also known as the Pinwheel Galaxy, M101 lies within the boundaries of the northern constellation Ursa Major, about 23 million light-years away. Its companion NGC 5474 has likely been distorted by its past gravitational interactions with the dominant M101."
                }
            };
            
            
            //images.ForEach(s => context.ImageDbSet.Add(s));
            Console.WriteLine("Test Print");

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}