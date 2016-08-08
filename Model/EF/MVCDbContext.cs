using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Model.EF
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<CW_Category> CW_Category { get; set; }
        public DbSet<CW_Article> CW_Article { get; set; }
        public DbSet<CW_News> CW_News { get; set; }
        public DbSet<CW_Adv> CW_Adv { get; set; }
        public DbSet<CW_Contact> CW_Contact { get; set; }
        public DbSet<CW_Menu> CW_Menu { get; set; }
        public DbSet<CW_Support> CW_Support { get; set; }
        public DbSet<CW_Setting> CW_Setting { get; set; }
        public DbSet<CW_NewsComment> CW_NewsComment { get; set; }
        public DbSet<CW_Language> CW_Language { get; set; }
        public DbSet<CW_Menu_Category> CW_Menu_Category { get; set; }
        public DbSet<CW_Email> CW_Email { get; set; }
       
        //user model
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CW_Customers> CW_Customers { get; set; }
        public DbSet<CW_CustomerGroups> CW_CustomerGroups { get; set; }
        public DbSet<WebRole> WebRoles { get; set; }
        public DbSet<webpages_Membership> webpages_Memberships { get; set; }

    }
}
