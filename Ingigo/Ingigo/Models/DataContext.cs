using Microsoft.EntityFrameworkCore;

namespace Ingigo.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Slider> Sliders { get; set; }

    
    }
}
