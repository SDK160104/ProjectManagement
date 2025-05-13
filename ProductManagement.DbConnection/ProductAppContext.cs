using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductMangement.Domain;

namespace ProductManagement.DbConnection
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext(DbContextOptions<ProductAppContext>options) : base(options) 
        {

        }
        public DbSet<ProductModel> productModels { get; set; }


    }
}
