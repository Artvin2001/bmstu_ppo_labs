using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore;

using TurHelper.DataAccesss.EntityStructures;

namespace TurHelper.DataAccesss
{
    public partial class PSQLContext : DbContext
    {
        private System.String ConString;
        public PSQLContext()
        {
            this.ConString = "Host=localhost;Port=5432;Database=ppo;Username=postgres;Password=Artvin2001";
        }

        public PSQLContext(string con)
        {
            this.ConString = con;
        }

        public PSQLContext(DbContextOptions<PSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Climate> Climate { get; set; }
        public virtual DbSet<Countries> Countires { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ppo;Username=postgres;Password=Artvin2001");
               optionsBuilder.UseNpgsql(this.ConString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Climate>(entity =>
            {
                entity.ToTable("climate");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

                //here исправила название 

                entity.Property(e => e.IdCountry).HasColumnName("idcountry");

                entity.Property(e => e.TurMonth)
                   .HasColumnName("turmonth")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);

                entity.Property(e => e.Temp)
                    .HasColumnName("daytemp")
                    .HasColumnType("int");

                entity.Property(e => e.TempNight)
                    .HasColumnName("nighttemp")
                    .HasColumnType("int");

                entity.Property(e => e.TempWater)
                    .HasColumnName("watertemp")
                    .HasColumnType("int");

                entity.HasOne(d => d.IdCountryNavigation)
                   .WithMany(p => p.Climates)
                   .HasForeignKey(d => d.IdCountry);
                   //.HasConstraintName("climate_id_country_fk");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedNever();

                entity.Property(e => e.IdCountry).HasColumnName("idcountry");

                entity.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar");

                entity.Property(e => e.Population)
                   .HasColumnName("population")
                   .HasColumnType("int");

                entity.HasOne(d => d.IdCityNavigation)
                   .WithMany(p => p.CityList)
                   .HasForeignKey(d => d.IdCountry);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.ToTable("rooms");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

                entity.Property(e => e.IdHotel).HasColumnName("idhotel");

                entity.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar");

                entity.Property(e => e.Capacity)
                   .HasColumnName("capacity")
                   .HasColumnType("int");

                entity.Property(e => e.Floor)
                    .HasColumnName("floor")
                    .HasColumnType("int");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int");

                entity.HasOne(d => d.IdHotelNavigation)
                   .WithMany(p => p.RoomList)
                   .HasForeignKey(d => d.IdHotel);
                   //.HasConstraintName("room_id_hotel_fk");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

                entity.Property(e => e.Login)
                   .HasColumnName("login")
                   .HasColumnType("varchar");

                entity.Property(e => e.Password)
                   .HasColumnName("password")
                   .HasColumnType("varchar");

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.ToTable("hotels");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

                entity.Property(e => e.IdCountry).HasColumnName("idcountry");

                entity.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar");

                entity.Property(e => e.Stars)
                    .HasColumnName("stars")
                    .HasColumnType("int");

                entity.Property(e => e.Beach)
                   .HasColumnName("beach")
                   .HasColumnType("bool");

                entity.Property(e => e.AllInc)
                   .HasColumnName("allinc")
                   .HasColumnType("bool");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.HotelList)
                    .HasForeignKey(d => d.IdCountry);
                    //.HasConstraintName("hotel_id_country_fk");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever();

                entity.Property(e => e.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar");

                entity.Property(e => e.Continent)
                   .HasColumnName("continent")
                   .HasColumnType("varchar");

                entity.Property(e => e.Capital)
                   .HasColumnName("capital")
                   .HasColumnType("varchar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
