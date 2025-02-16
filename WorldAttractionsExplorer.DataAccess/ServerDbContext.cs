using System;
using Microsoft.EntityFrameworkCore;
using WorldAttractionsExplorer.DataAccess.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WorldAttractionsExplorer.DataAccess;

public class ServerDbContext:DbContext
{
    public ServerDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attractions>()
            .HasKey(a => a.AttractionId);

        modelBuilder.Entity<Attractions>()
            .Property(a => a.AttractionId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Tags>()
            .HasKey(t => t.TagId);

        modelBuilder.Entity<Tags>()
            .Property(t => t.TagId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Country>()
            .HasKey(t => t.CountryId);

        modelBuilder.Entity<Country>()
            .Property(c => c.CountryId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Images>()
            .HasKey(i => i.ImageId);

        modelBuilder.Entity<Images>()
            .Property(i => i.ImageId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Users>()
            .HasKey(t => t.UserId);

        modelBuilder.Entity<Users>()
            .Property(i => i.UserId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Reviews>()
            .HasKey(t => t.ReviewId);

        modelBuilder.Entity<Reviews>()
            .Property (i => i.ReviewId)
            .ValueGeneratedOnAdd();




        modelBuilder.Entity<AttractionTags>()
            .HasKey(at => new { at.AttractionId, at.TagId });

        modelBuilder.Entity<AttractionTags>()
            .HasOne(at => at.Attraction)
            .WithMany(a => a.AttractionTags)
            .HasForeignKey(at => at.AttractionId);

        modelBuilder.Entity<AttractionTags>()
            .HasOne(at => at.Tag)
            .WithMany(t => t.AttractionTags)
            .HasForeignKey(at => at.TagId);

        modelBuilder.Entity<Attractions>()
            .HasOne(a => a.Author)
            .WithMany() 
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attractions>()
            .HasOne(a => a.Editor)
            .WithMany()
            .HasForeignKey(a => a.EditorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attractions>()
            .HasOne(a => a.Country)       
            .WithMany(c => c.Attractions) 
            .HasForeignKey(a => a.CountryId) 
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Attractions>()
            .Property(a => a.PublishedDate)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Attractions>()
            .Property(a => a.LastModifiedOn)
            .ValueGeneratedOnAddOrUpdate();

        modelBuilder.Entity<Attractions>()
            .HasOne(a => a.PrimaryImage)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attractions>()
            .HasMany(a => a.OptionalImages)
            .WithOne(i => i.Attraction)
            .HasForeignKey(i => i.AttractionId);

        modelBuilder.Entity<Attractions>()
            .HasMany(a => a.Reviews)
            .WithOne(r => r.Attraction)
            .HasForeignKey(r => r.AttractionId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Images>()
            .HasOne(i => i.Owner)
            .WithMany()
            .IsRequired()
            .HasForeignKey(i => i.OwnerId);

        modelBuilder.Entity<Images>()
            .HasOne(i => i.Attraction)
            .WithMany()
            .IsRequired()
            .HasForeignKey(i => i.AttractionId);

        modelBuilder.Entity<Reviews>()
            .HasOne(r => r.Attraction)
            .WithMany(a => a.Reviews)
            .HasForeignKey(r => r.AttractionId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }



    public DbSet<Attractions> Attractions {get; set;}
    public DbSet<Tags> Tags {get;set;}
    public DbSet<AttractionTags> AttractionTags {get; set;}
    public DbSet<Country> Countries {get;set;}
    public DbSet<Images> Images {get;set;}
    public DbSet<Reviews> Reviews {get;set;}
    public DbSet<Users> Users {get;set;}

}
