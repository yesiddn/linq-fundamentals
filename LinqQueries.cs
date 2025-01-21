namespace linq;

public class LinqQueries {
  private List<Book> librosCollection = new List<Book>();
  public LinqQueries() {
    StreamReader reader = new StreamReader("books.json");

    string json = reader.ReadToEnd();

    var deserializedBooks = System.Text.Json.JsonSerializer
      .Deserialize<List<Book>>(
        json, new System.Text.Json.JsonSerializerOptions() 
        {
          PropertyNameCaseInsensitive = true
        }
      );

    librosCollection = deserializedBooks ?? new List<Book>();
  }

  // Retornar IEnumerable siempre que los datos no se vayan a modificar o se requiera un manejo de datos más específico
  public IEnumerable<Book> AllBooks() {
    return librosCollection;
  }
}