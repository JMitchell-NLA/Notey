using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Notey
{
    public class TaggingContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Notey.db");
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public List<Note> Notes { get; } = new List<Note>();
    }

    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; } = new List<Tag>();

    }
}