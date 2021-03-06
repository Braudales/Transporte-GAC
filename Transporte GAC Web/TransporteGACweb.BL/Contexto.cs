using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteGACweb.BL
{
  public class Contexto: DbContext
    {
        public Contexto(): base("TransporteGACwebDB")
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Colaborador> Colaborador { get; set; }
        public  DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Conductor> Conductor { get; set; }

        public DbSet<Viajes> Viajes { get; set; }
        public DbSet<ControlViajes> ControlViajes { get; set; }



    }
}
