using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thribe.ApplicationUser.AddressModel;
using Thribe.ApplicationUser.UserModel;
using Thribe.AppMessage.Infrastructure;
using Thribe.AppSupport.Infrastructure;
using Thribe.Category.Models;
using Thribe.MyOrder;

namespace Thribe.Data
{
    public class ThribeDbContext : DbContext
    {
        public ThribeDbContext(DbContextOptions<ThribeDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<Job> MyJobs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProcessing> Processings { get; set; }
        public virtual DbSet<PromoCode> PromoCodes { get; set; }
        public virtual DbSet<AppMessages> AppMessages { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<GetQuestion> Questions { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
        public virtual DbSet<UserSelection> UserSelections { get; set; }
        public virtual DbSet<SelectedSkill> SelectedSkills { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
    }
}
