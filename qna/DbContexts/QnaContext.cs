using Microsoft.EntityFrameworkCore;
using qna.Entities;

namespace qna.DbContexts;

public class QnaContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Question> Questions { get; set; } = null!;

    public DbSet<Answer> Answers { get; set; } = null!;

    public DbSet<Vote> Votes { get; set; } = null!;

    public QnaContext(DbContextOptions<QnaContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User("charles_darwin", "origin_of_species", "536fa4c1-bd09-4d71-9621-ea73d4e86bf3")
            {
                Id = 1
            },
            new User("richard_stallman" , "free_software", "e95b5712-1904-48c7-8658-3e76af36b280")
            {
                Id = 2
            },
            new User("alexander_fleming", "penicillin", "65dc1da2-6124-4b80-9bcf-c5941bbf7406")
            {
                Id = 3
            },
            new User("ken_thompson", "unix", "2596c58b-591c-4422-a1da-82f3d4130c51")
            {
                Id = 4
            },
            new User("alice", "wonderland", "64b3ebc6-1cd5-4c27-9332-813bff01e936")
            {
                Id = 5
            }
        );

        // Seed Questions
        modelBuilder.Entity<Question>().HasData(
            new Question("Who is the president of the USA?")
            {
                Id = 1,
                UserId = 1
            },
            new Question("What is the captial of Egypt?")
            {
                Id = 2,
                UserId = 2
            }
        );

        // Seed Questions
        modelBuilder.Entity<Answer>().HasData(
            new Answer("Joe Biden")
            {
                Id = 1,
                QuestionId = 1,
                UserId = 3
            },
            new Answer("Cairo")
            {
                Id = 2,
                QuestionId = 2,
                UserId = 4
            }
        );

        // Seed Votes
        modelBuilder.Entity<Vote>().HasData(
            new Vote(1)
            {
                Id = 1,
                AnswerId = 1,
                UserId = 1
            },
            new Vote(-1)
            {
                Id = 2,
                AnswerId = 2,
                UserId = 2
            }
        );
        base.OnModelCreating(modelBuilder);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite("connectionstring");
    //     base.OnConfiguring(optionsBuilder);
    // }
}
