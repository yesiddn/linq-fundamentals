namespace linq;

public class LinqQueries
{
  private List<Book> bookCollection = new List<Book>();
  public LinqQueries()
  {
    StreamReader reader = new StreamReader("books.json");

    string json = reader.ReadToEnd();

    var deserializedBooks = System.Text.Json.JsonSerializer
      .Deserialize<List<Book>>(
        json, new System.Text.Json.JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        }
      );

    bookCollection = deserializedBooks ?? new List<Book>();
  }

  // Retornar IEnumerable siempre que los datos no se vayan a modificar o se requiera un manejo de datos más específico
  public IEnumerable<Book> AllBooks()
  {
    return bookCollection;
  }

  public IEnumerable<Book> booksAfter2000()
  {
    // extension method
    // return bookCollection.Where(book => book.PublishedDate.Year > 2000);

    // query expression
    return
      from book in bookCollection
      where book.PublishedDate.Year > 2000
      select book; // select obtiene el objeto completo, si se usa select book.Title solo se obtendría el título
  }

  public IEnumerable<Book> booksWithMoreThan250PagesAndInActionWords()
  {
    // extension method
    // return bookCollection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));

    // query expression
    return
      from book in bookCollection
      where book.PageCount > 250 && book.Title.Contains("in Action")
      select book;
  }

  public bool allBooksHasStatus()
  {
    // extension method
    return bookCollection.All(book => book.Status != string.Empty);

    // query expression
    // return
    //   (from book in bookCollection
    //   where book.Status == string.Empty
    //   select book).Count() == 0;
  }

  public bool someBookWasPublishedIn2005()
  {
    // extension method
    return bookCollection.Any(book => book.PublishedDate.Year == 2005);

    // query expression
    // return
    //   (from book in bookCollection
    //   where book.PublishedDate.Year == 2005
    //   select book).Count() > 0;
  }
}