using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVTester.Models;

namespace CVTester.DAL
{
    public class ImageContext : DbContext
    {
        public ImageContext() : base("ImageContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public DbSet<ImageData> Image { get; set; }


    }
}
