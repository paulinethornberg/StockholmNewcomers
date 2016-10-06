using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockholmNewcomers.Models.Entities
{
    public partial class StockholmForNewcomersContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=StockholmForNewcomers;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Localactivities>(entity =>
            {
                entity.ToTable("localactivities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddDate)
                    .HasColumnName("add_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Approve)
                    .HasColumnName("approve")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Info)
                    .HasColumnName("info")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ord).HasColumnName("ord");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<LocalactivitiesTags>(entity =>
            {
                entity.ToTable("localactivities_tags");

                entity.Property(e => e.LocalactivityId).HasColumnName("localactivityID");

                entity.Property(e => e.TagsId).HasColumnName("tagsId");

                entity.HasOne(d => d.Localactivity)
                    .WithMany(p => p.LocalactivitiesTags)
                    .HasForeignKey(d => d.LocalactivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__localacti__local__40F9A68C");

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.LocalactivitiesTags)
                    .HasForeignKey(d => d.TagsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__localacti__tagsI__41EDCAC5");
            });

            modelBuilder.Entity<Organisations>(entity =>
            {
                entity.Property(e => e.DateAdded)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email).HasColumnType("nchar(50)");

                entity.Property(e => e.Info).IsRequired();

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(32)");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Website).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.ToTable("organizations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddDate)
                    .HasColumnName("add_date")
                    .HasColumnType("datetime2(3)");

                entity.Property(e => e.Approve)
                    .HasColumnName("approve")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Info)
                    .HasColumnName("info")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ord).HasColumnName("ord");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<OrganizationsTags>(entity =>
            {
                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationsTags)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Organizat__Organ__160F4887");

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.OrganizationsTags)
                    .HasForeignKey(d => d.TagsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Organizat__TagsI__17036CC0");
            });

            modelBuilder.Entity<Socials>(entity =>
            {
                entity.ToTable("socials");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approve)
                    .HasColumnName("approve")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Google)
                    .HasColumnName("google")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ord).HasColumnName("ord");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Vimo)
                    .HasColumnName("vimo")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Youtube)
                    .HasColumnName("youtube")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddDate)
                    .HasColumnName("add_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Approve)
                    .HasColumnName("approve")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cat)
                    .HasColumnName("cat")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Ord).HasColumnName("ord");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<TagsCategory>(entity =>
            {
                entity.ToTable("tags_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddDate)
                    .HasColumnName("add_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Approve)
                    .HasColumnName("approve")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Ord)
                    .HasColumnName("ord")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<TagsCategoryTags>(entity =>
            {
                entity.ToTable("tags_categoryTags");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TagsCategoryTags)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tags_cate__Organ__29221CFB");

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.TagsCategoryTags)
                    .HasForeignKey(d => d.TagsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tags_cate__TagsI__2A164134");
            });
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Localactivities> Localactivities { get; set; }
        public virtual DbSet<LocalactivitiesTags> LocalactivitiesTags { get; set; }
        public virtual DbSet<Organisations> Organisations { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<OrganizationsTags> OrganizationsTags { get; set; }
        public virtual DbSet<Socials> Socials { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TagsCategory> TagsCategory { get; set; }
        public virtual DbSet<TagsCategoryTags> TagsCategoryTags { get; set; }
    }
}