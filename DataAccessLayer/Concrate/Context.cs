using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G2007Q5;Initial Catalog=CoreBlogDemoDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("server = DESKTOP-G2007Q5\\MSSQLSERVER01;database=CoreBlogDB;integrated security=true;");

            // Scaffold - Context "Data Source=DESKTOP-G2007Q5; Initial Catalog =CoreBlogDb;integrated security=true; " Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bir tabloda iki ilişki kurmak için bu metod oluşturuldu.

            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>()
                 .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);//Identity ile ilgili

            //HomeMatches- ->WriterSender
            //AwayMatches- ->WriterReceiver


            //HomeTeam- ->SenderUser
            //GuestTeam- ->ReciverUser

            modelBuilder.Entity<Message2>()
               .HasOne(x => x.SenderUser)
               .WithMany(y => y.WriterSender)
               .HasForeignKey(z => z.SenderID)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                 .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
