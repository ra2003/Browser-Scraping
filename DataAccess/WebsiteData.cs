namespace DataAccess
{
    using Configurations;
    using Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebsiteDataContext : DbContext, IDbContext
    {
        public WebsiteDataContext()
            : base("WebsiteData")
        {
        }

        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Website> Website { get; set; }
        public virtual DbSet<IgnoreList> IgnoreList { get; set; }
        public virtual DbSet<RelatedKeywords> RelatedKeywords { get; set; }
        public virtual DbSet<SubDomain> SubDomain { get; set; }
        public virtual DbSet<Webpage> Webpage { get; set; }
        public virtual DbSet<WordCount> WordCount { get; set; }
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<WebpageKeywords> WebpageKeywords { get; set; } 
        public virtual DbSet<WebsiteKeywords> WebsiteKeywords { get; set; }
        public virtual DbSet<JobList> JobList { get; set; }
        public virtual DbSet<JobTracking> JobTracking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            modelBuilder.Entity<RelatedKeywords>()
                .HasRequired<Keyword>(k => k.PrimaryKeyword)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Configurations.Add(new WebsiteConfiguration());
            modelBuilder.Configurations.Add(new SubDomainConfiguration());
            modelBuilder.Configurations.Add(new WebpageConfiguration());

        }
    }
}