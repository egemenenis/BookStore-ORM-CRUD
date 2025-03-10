using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (context.Books.Any() || context.Authors.Any())
            {
                return;
            }

            var author1 = new Author { Name = "J.K. Rowling" };
            var author2 = new Author { Name = "George R.R. Martin" };

            context.Authors.AddRange(author1, author2);

            await context.SaveChangesAsync();

            // Kitaplar ekleniyor
            var book1 = new Book { Title = "Harry Potter and the Philosopher's Stone", ISBN = "978-0747532699", Price = 29.99m, AuthorId = author1.Id };
            var book2 = new Book { Title = "Harry Potter and the Chamber of Secrets", ISBN = "978-0747538493", Price = 29.99m, AuthorId = author1.Id };
            var book3 = new Book { Title = "A Game of Thrones", ISBN = "978-0553103540", Price = 19.99m, AuthorId = author2.Id };
            var book4 = new Book { Title = "A Clash of Kings", ISBN = "978-0553108033", Price = 21.99m, AuthorId = author2.Id };

            context.Books.AddRange(book1, book2, book3, book4);

            await context.SaveChangesAsync();
        }
    }
}
