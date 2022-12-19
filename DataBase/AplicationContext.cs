using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TypeOfPokemon> TypeOfPokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<TypeOfPokemon>().ToTable("TypeOfPokemons");
            #endregion

            #region <"Primary Keys">
            modelBuilder.Entity<Pokemon>().HasKey(Pokemon =>/*<- Eso es lamba*/ Pokemon.Id);
            modelBuilder.Entity<Region>().HasKey(Region => Region.Id);
            modelBuilder.Entity<TypeOfPokemon>().HasKey(TypeP => TypeP.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(Region => Region.Pokemons)
                .WithOne(Pokemon => Pokemon.Region)
                .HasForeignKey(Pokemon => Pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
            //------------------------------------------------------
            modelBuilder.Entity<TypeOfPokemon>()
                .HasMany<Pokemon>(TypeOfPokemon => TypeOfPokemon.PokemonsType)
                .WithOne(Pokemon => Pokemon.TypeOfPokemon)
                .HasForeignKey(Pokemon => Pokemon.TypeOfPokemonId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"

            #region "Pokemons"
            modelBuilder.Entity<Pokemon>().Property(p=>p.Name).IsRequired();
                    #endregion

                    #region "Regions"
                        modelBuilder.Entity<Region>().Property(r => r.Name).IsRequired();
                    #endregion

                    #region "Type"
                        modelBuilder.Entity<TypeOfPokemon>().Property(t => t.Name).IsRequired();
                    #endregion


            #endregion
        }
    }
}
