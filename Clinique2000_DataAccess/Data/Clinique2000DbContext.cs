using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinique2000_DataAccess.Data
{
    public class Clinique2000DbContext : IdentityDbContext<User>
    {
        public Clinique2000DbContext(DbContextOptions<Clinique2000DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlageHoraire>()
                .HasOne(p => p.Medecin)
                .WithMany(m => m.Consultations)
                .HasForeignKey(p => p.MedecinId)
                .HasPrincipalKey(u => u.Id);

            builder.Entity<PlageHoraire>()
                .HasOne(p => p.Patient)
                .WithMany(m => m.PlagesHoraires)
                .HasForeignKey(p => p.PatientId)
                .HasPrincipalKey(u => u.Id);

        //    builder.Entity<PlageHoraire>()
        //.HasOne(p => p.PlageHoraireAnnule)
        //.WithOne()
        //.HasForeignKey<PlageHoraireAnnule>(p => p.PlageHoraireId);



            builder.GenerateData();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clinique> Cliniques { get; set; }
        public DbSet<FileDAttente> FilesDAttente { get; set; }
        public DbSet<PlageHoraire> PlagesHoraires { get; set; }
        public DbSet<PlageHoraireAnnule> PlagesHorairesAnnules { get; set; }
    }    

}
