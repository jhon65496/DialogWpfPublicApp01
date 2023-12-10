using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogWpfPublicApp01.Models;

namespace DialogWpfPublicApp01
{
    public class DbContextApp : DbContext
    {
        public DbContextApp() : base("DefaultConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
