using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GroupWebApplication.Data;
using System;
using System.Linq;

namespace GroupWebApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
         {
             using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<ApplicationDbContext>>()))
             {
                 // Look for any movies.
                 if (context.ImageModel.Any())
                 {
                     return;   // DB has been seeded
                 }

                 context.ImageModel.AddRange(
                     new ImageModel
                     {
                 
                         Title = "first",
                         Explanation = "the thing fthing",
                         Date = "2010-01-01",
                         Url = "https://cdn.spacetelescope.org/archives/images/wallpaper2/heic1608a.jpg",
                        
                     },

                     new ImageModel
                     {
                        
                         Title = "second",
                         Explanation = "the thing fthing",
                         Date = "2010-02-01",
                         Url = "https://cdn.spacetelescope.org/archives/images/wallpaper2/heic0715a.jpg",
                        
                     },

                     new ImageModel
                     {
                         
                         Title = "Third",
                         Explanation = "the thing fthing",
                         Date = "2010-03-01",
                         Url = "https://cdn.spacetelescope.org/archives/images/wallpaper2/heic1107a.jpg",
                         
                     },

                     new ImageModel
                     {
                         
                         Title = "fourth",
                         Explanation = "the thing fthing",
                         Date = "2010-04-01",
                         Url = "https://cdn.spacetelescope.org/archives/images/wallpaper2/heic1501a.jpg",
                         
                     },
                     new ImageModel
                     {
                        
                         Title = "fith",
                         Explanation = "the thing fthing",
                         Date = "2010-05-01",
                         Url = "https://cdn.spacetelescope.org/archives/images/wallpaper2/heic1509a.jpg",
                         
                     }
                 );
                 context.SaveChanges();
             }
         }
    }
}