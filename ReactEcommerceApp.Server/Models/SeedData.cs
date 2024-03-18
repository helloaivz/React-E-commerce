using Microsoft.EntityFrameworkCore;

namespace ReactEcommerceApp.Server.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new WatchesDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<WatchesDBContext>>()))
            {

                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    var categories = new List<Category>
            {
            new Category{Id=1,Title="Womens"},
            new Category{Id=2,Title="Mens"},
            new Category{Id=3,Title="Kids"}
            };
                    categories.ForEach(s => context.Categories.Add(s));
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var products = new List<Product>
            {
            new Product{Id=1,Title="Karli Three-Hand Watch",Description="Rose Gold-Tone Stainless Steel Watch Quartz movement Buckle closure",CategoryId=1,Price="144.99",Qty=10,Image="MK-01.jpg"},
            new Product{Id=2,Title="Coach Libby Watch",Description="Gold tone case and Signature rubber strap Mineral crystal Quartz movement Buckle closure",CategoryId=1,Price="99.99",Qty=10,Image="coach-01.jpg"},
            new Product{Id=3,Title="Fossil Kerrigan Watch",Description="Three-Hand Rose Gold-Tone Stainless Steel Watch Quartz movement Buckle closure",CategoryId=1,Price="144.99",Qty=10,Image="fossil-01.jpg"},
            new Product{Id=4,Title="Guess 36MM Crystal Accented Watch",Description="Round polished rose gold-tone + crystal White silicone strap with buckle closuree",CategoryId=1,Price="104.99",Qty=10,Image="guess-01.jpg"},
            new Product{Id=5,Title="Michael Kors Slim Watch",Description="MK Oversized Slim Runway Black-Tone Watch Quartz movement Buckle closure",CategoryId=2,Price="109.99",Qty=10,Image="mk-mens.jpg"},
            new Product{Id=6,Title="Guess Men's Sports Watch",Description="Stainless Steel Bracelet Watch (Model: GW0390G1), Silver-Tone/Black",CategoryId=2,Price="129.99",Qty=10,Image="guess-mens.jpg"},
            new Product{Id=7,Title="Casio Men's GA-700UC-8ACR G Shock",Description="Analog-Digital Display Quartz Grey Watch, Dark Grey Quartz movement Buckle closure",CategoryId=2,Price="139.99",Qty=10,Image="g-shock-mens.jpg"},
            new Product{Id=8,Title="Fossil Men's Nate Watch",Description="Blacktone Bracelet and Dial Watch, Fossil Men's Nate",CategoryId=2,Price="167.99",Qty=10,Image="fossil-mens.jpg"},
            new Product{Id=9,Title="Accutime Kids Pokemon Pikachu Watch",Description="Analog Quartz Watch for Boys, Girls, Toddlers and Adults All Ages, Pikachu, Quartz Watch",CategoryId=3,Price="25.99",Qty=10,Image="picachu.jpg"},
            new Product{Id=10,Title="Disney Minnie Mouse Time",Description="Teacher Kids Watch, Pink, Disney Minnie Mouse Time",CategoryId=3,Price="149.99",Qty=10,Image="disney-minnie.jpg"},
            new Product{Id=11,Title="Spider-Man Smartwatch",Description="Touch-Screen Interactive Smartwatch Black Quartz movement Buckle closure",CategoryId=3,Price="39.99",Qty=10,Image="spider-man.jpg"},
            new Product{Id=12,Title="Kids Phone Smartwatch",Description="With Games & MP3 Player - 1.54 inch Touch Screen Quartz movement Buckle closure",CategoryId=3,Price="49.99",Qty=10,Image="smartwatch.jpg"}
            };
                    products.ForEach(s => context.Products.Add(s));
                    context.SaveChanges();
                }
            }
        }

    }
}
