using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(
        this IServiceCollection services,
        ConfigurationManager config)
    {
        string? connectionString = config.GetConnectionString("BooksConnectionString");
        services.AddDbContext<BookDbContext>(options =>
            options.UseSqlServer(connectionString)
        );
        services.AddScoped<IBookRepository, EfBookRepository>();
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}

internal class EfBookRepository : IBookRepository
{
    private readonly BookDbContext _dbContext;
    public EfBookRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
  public Task AddAsync(Book book)
  {
    _dbContext.Add(book);
    return Task.CompletedTask;
  }

  public Task DeleteAsync(Book book)
  {
    _dbContext.Remove(book);
    return Task.CompletedTask;
  }

  public async Task<Book?> GetByIdAsync(Guid id)
  {
    return await _dbContext!.Books.FindAsync(id);
  }

  public async Task<List<Book>> ListAsync()
  {
    return await _dbContext.Books.ToListAsync();
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}

// public static class BookRepositoryExtensions
// {
//     public static IServiceCollection AddBookRepositoryServices(this IServiceCollection services)
//     {
//         services.AddSingleton<IBookService, BookService>();
//         return services;
//     }
// }


