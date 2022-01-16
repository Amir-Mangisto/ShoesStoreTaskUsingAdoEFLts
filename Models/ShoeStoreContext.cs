using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShoesStoreTaskUsingAdoEFLts.Models
{
    public partial class ShoeStoreContext : DbContext
    {
        public ShoeStoreContext()
            : base("name=ShoeStoreContext")
        {
        }

       public virtual DbSet<ExitShoes> ExitShoes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
