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

  public IEnumerable<Book> pythonBooks()
  {
    // extension method
    return bookCollection.Where(book => book.Categories.Contains("Python"));

    // query expression
    // return
    //   from book in bookCollection
    //   where book.Categories.Contains("Python")
    //   select book;
  }

  public IEnumerable<Book> javaBooksByNameAsc()
  {
    // extension method
    return bookCollection.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.Title);

    // query expression
    // return
    //   from book in bookCollection
    //   where book.Categories.Contains("Java")
    //   orderby book.Title
    //   select book;
  }

  public IEnumerable<Book> booksWithMoreThan450PagesByDescending()
  {
    // extension method
    return bookCollection.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);

    // query expression
    // return
    //   from book in bookCollection
    //   where book.PageCount > 450
    //   orderby book.PageCount descending
    //   select book;
  }

  public IEnumerable<Book> threeFirstJavaBooksOrderedByDate()
  {
    // extension method
    return bookCollection
    .Where(book => book.Categories.Contains("Java"))
    .OrderByDescending(book => book.PublishedDate)
    // .TakeLast(3) // es lo contrario a Take, toma los últimos 3 elementos
    // .TakeWhile(book => book.PublishedDate.Year > 2000) // toma elementos mientras se cumpla la condición
    .Take(3);
  }

  public IEnumerable<Book> booksWithMoreThan450PagesByDescendingAndTakeThirdAndFourth() {
    // extension method
    return bookCollection
    .Where(book => book.PageCount > 450)
    .OrderByDescending(book => book.PageCount)
    .Take(4)
    .Skip(2);
    // .SkipLast(2) // es lo contrario a Skip, salta los últimos 2 elementos
    // .SkipWhile(book => book.PageCount > 500) // salta elementos mientras se cumpla la condición
  }

  public IEnumerable<Book> threeFirstBooks() {
    return bookCollection.Take(3)
    // .Select(book => new { book.Title, PCount = book.PageCount }); // con esto se crea un objeto anónimo con los campos seleccionados -> se comporta como los objetos de JavaScript, cuando no se especifica el nombre de la propiedad se toma el nombre de la variable
    .Select(book => new Book() { Title = book.Title, PageCount = book.PageCount });
  }

  public int countOfBooksBetween200and500Pages() {
    return bookCollection.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
    // return bookCollection
    // .Where(book => book.PageCount >= 200 && book.PageCount <= 500) 
    // .Count();
    // .LongCount(); // retorna un long en lugar de un int
    // esto es una mala practica, ya que se estan haciendo dos operaciones sobre la colección, lo ideal es usar Count (o LongCount) directamente ya que permite recibir una expresión lambda como parámetro
  }

  public DateTime latestPublishedDate() {
    return bookCollection.Min(book => book.PublishedDate);
  }

  public DateTime earliestPublishedDate() {
    return bookCollection.Max(book => book.PublishedDate);
  }

  public int bookWithTheMostPages() {
    return bookCollection.Max(book => book.PageCount);
  }

  public Book bookWithTheFewestPages() {
    return bookCollection.Where(book => book.PageCount > 0).MinBy(book => book.PageCount) ?? new Book();
  }

  public Book bookWithTheEarliestPublishedDate() {
    return bookCollection.Where(book => book.PublishedDate != DateTime.MinValue).MaxBy(book => book.PublishedDate) ?? new Book();
  }
}