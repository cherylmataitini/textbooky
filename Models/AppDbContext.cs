using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TextBooky.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser> // like DbContext but with added support for identity ; IdentityDbContext is the base class for Entity F to use Identity ; IdentityUser class represents user in Identity - comes w/ many properties
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<TextBook> TextBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // model creating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configure the entity to have seed data
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Life Sciences" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Computer Science" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Physical Sciences" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Mathematics" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Engineering" });

            // another modelbuilder entity to seed the TextBooks table
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id=1,
                Title= "Lehninger Principles of Biochemistry",
                Author= "David L. Nelson, Michael M. Cox",
                Description= "Lehninger Principles of Biochemistry is the #1 bestseller for the introductory biochemistry course because it brings clarity and coherence to an often unwieldy discipline, offering a thoroughly updated survey of biochemistry’s enduring principles, definitive discoveries, and groundbreaking new advances with each edition. This new Seventh Edition maintains the qualities that have distinguished the text since Albert Lehninger’s original edition—clear writing, careful explanations of difficult concepts, helpful problem-solving support, and insightful communication of contemporary biochemistry’s core ideas, new techniques, and pivotal discoveries. Again, David Nelson and Michael Cox introduce students to an extraordinary amount of exciting new findings without an overwhelming amount of extra discussion or detail.",
                ISBN= "978-0716743392",
                Price= 60.45M,
                InStock=true,
                CategoryId=1,
                ImageUrl="/img/Lehninger.jpg",
            });
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id = 2,
                Title = "C# 7.0 in a Nutshell",
                Author = "Joseph Albahari, Ben Albahari",
                Description = "When you have questions about C# 7.0 or the .NET CLR and its core Framework assemblies, this bestselling guide has the answers you need. Since its debut in 2000, C# has become a language of unusual flexibility and breadth, but its continual growth means there's always more to learn. Organized around concepts and use cases, this updated edition provides intermediate and advanced programmers with a concise map of C# and .NET knowledge.Get up to speed on the C# language, from the basics of syntax and variables to advanced topics such as pointers, operator overloading, and dynamic binding Dig deep into LINQ via three chapters dedicated to the topic Explore concurrency and asynchrony, advanced threading, and parallel programming. Work with .NET features, including XML, regular expressions, networking, serialization, reflection, application domains, and security Delve into Roslyn, the modular C# 7.0 compiler-as-a-service.",
                ISBN = "978-1491987650",
                Price = 40.55M,
                InStock = true,
                CategoryId = 2,
                ImageUrl = "/img/C7-in-a-nutshell.jpg",
            });
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id = 3,
                Title = "Foundations of Quantum Mechanics",
                Author = "Travis Norsen",
                Description = "Authored by an acclaimed teacher of quantum physics and philosophy, this textbook pays special attention to the aspects that many courses sweep under the carpet. Traditional courses in quantum mechanics teach students how to use the quantum formalism to make calculations. But even the best students - indeed, especially the best students - emerge rather confused about what, exactly, the theory says is going on, physically, in microscopic systems. This supplementary textbook is designed to help such students understand that they are not alone in their confusions (luminaries such as Albert Einstein, Erwin Schroedinger, and John Stewart Bell having shared them), to sharpen their understanding of the most important difficulties associated with interpreting quantum theory in a realistic manner, and to introduce them to the most promising attempts to formulate the theory in a way that is physically clear and coherent.",
                ISBN = "978-3319658667",
                Price = 30.00M,
                InStock = true,
                CategoryId = 3,
                ImageUrl = "/img/qm-norsen.jpg",
            });
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id = 4,
                Title = "Fundamentals of Aerospace Engineering",
                Author = "Manuel Soler Burillo",
                Description = "The book is divided into three parts, namely: Introduction, The Aircraft, and Air Transportation, Airports, and Air Navigation. The first part is divided in two chapters in which the student must achieve to understand the basic elements of atmospheric flight (ISA and planetary references) and the technology that apply to the aerospace sector, in particular with a specific comprehension of the elements of an aircraft. The second part focuses on the aircraft and it is divided in five chapters that introduce the student to aircraft aerodynamics (fluid mechanics, airfoils, wings, high-lift devices), aircraft materials and structures, aircraft propulsion, aircraft instruments and systems, and atmospheric flight mechanics (performances and stability and control). The third part is devoted to understand the global air transport system (covering both regulatory and economical frameworks), the airports, and the global air navigation system (its history, current status, and future development). The theoretical contents are illustrated with figures and complemented with some problems/exercises. The problems deal, fundamentally, with aerodynamics and flight mechanics, and were proposed in different exams. The course is complemented by a practical approach.",
                ISBN = "978-1493727759",
                Price = 16.99M,
                InStock = true,
                CategoryId = 5,
                ImageUrl = "/img/a-engineering.jpg",
            });
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id = 5,
                Title = "Proofs from THE BOOK",
                Author = "Martin Aigner, Gunter M. Ziegler",
                Description = "Sixth edition. The book is divided into three parts, namely: Introduction, The Aircraft, and Air Transportation, Airports, and Air Navigation. The first part is divided in two chapters in which the student must achieve to understand the basic elements of atmospheric flight (ISA and planetary references) and the technology that apply to the aerospace sector, in particular with a specific comprehension of the elements of an aircraft. The second part focuses on the aircraft and it is divided in five chapters that introduce the student to aircraft aerodynamics (fluid mechanics, airfoils, wings, high-lift devices), aircraft materials and structures, aircraft propulsion, aircraft instruments and systems, and atmospheric flight mechanics (performances and stability and control). The third part is devoted to understand the global air transport system (covering both regulatory and economical frameworks), the airports, and the global air navigation system (its history, current status, and future development). The theoretical contents are illustrated with figures and complemented with some problems/exercises. The problems deal, fundamentally, with aerodynamics and flight mechanics, and were proposed in different exams. The course is complemented by a practical approach.",
                ISBN = "978-3662572641",
                Price = 40.55M,
                InStock = true,
                CategoryId = 4,
                ImageUrl = "/img/proofs.jpg",
            });
            modelBuilder.Entity<TextBook>().HasData(new TextBook
            {
                Id = 6,
                Title = "C# in Depth",
                Author = "John Skeet",
                Description = "C# in Depth, Fourth Edition is your key to unlocking the powerful new features added to the language in C# 5, 6, and 7. Following the expert guidance of C# legend Jon Skeet, you'll master asynchronous functions, expression-bodied members, interpolated strings, tuples, and much more.",
                ISBN = "978-1617294532",
                Price = 19.00M,
                InStock = true,
                CategoryId = 2,
                ImageUrl = "/img/c-in-depth.png",
            });
        }
    }
}

//public int Id { get; set; }
//public string Title { get; set; }
//public string Author { get; set; }
//public string Description { get; set; }
//public string ISBN { get; set; }
//public string ImageUrl { get; set; }
//public decimal Price { get; set; }
//public bool InStock { get; set; }
//public Category Category { get; set; }
//public int CategoryId { get; set; }