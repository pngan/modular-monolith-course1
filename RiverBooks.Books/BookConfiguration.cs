using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
  internal static readonly Guid Book1Guid = new Guid("7ff39bbd-ac8d-4339-bcd0-f04fbe082c2b");
  internal static readonly Guid Book2Guid = new Guid("21ee3db6-a03d-4937-abd4-43eff9883932");
  internal static readonly Guid Book3Guid = new Guid("67e864bf-28f6-4fb2-97cc-4cfda9c57511");
  
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(p=>p.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(p=>p.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleBookData());
  }

  private IEnumerable<Book> GetSampleBookData()
  {
      var tolkein="J.R.R. Tolkein";
      yield return new Book(Book1Guid, "The fellowship of the Ring", tolkein, 10.99m);
      yield return new Book(Book2Guid, "The Two Towers", tolkein, 11.99m);
      yield return new Book(Book3Guid, "The return of the King", tolkein, 12.99m);
  }
}
