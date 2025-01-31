﻿using linq;

LinqQueries queries = new();

// ShowBooks(queries.AllBooks());
// ShowBooks(queries.booksAfter2000());
// ShowBooks(queries.booksWithMoreThan250PagesAndInActionWords());
// Console.WriteLine($"All books have status: {queries.allBooksHasStatus()}");
// Console.WriteLine($"Some book was published in 2005: {queries.someBookWasPublishedIn2005()}");
// ShowBooks(queries.pythonBooks());
// ShowBooks(queries.javaBooksByNameAsc());
// ShowBooks(queries.booksWithMoreThan450PagesByDescending());
// ShowBooks(queries.threeFirstJavaBooksOrderedByDate());
// ShowBooks(queries.booksWithMoreThan450PagesByDescendingAndTakeThirdAndFourth());
// ShowBooks(queries.threeFirstBooks());
// Console.WriteLine($"There are {queries.countOfBooksBetween200and500Pages()} books between 200 and 500 pages");
// Console.WriteLine($"The latest publication date is: {queries.bookWithTheLatestPublishedDate()}");
// Console.WriteLine($"The earliest publication date is: {queries.bookWithTheEarliestPublishedDate()}");
// Console.WriteLine($"The largest number of pages is: {queries.bookWithTheMostPages()}");
// Book bookWithTheSmallestNumberOfPages = queries.bookWithTheFewestPages();
// Console.WriteLine($"The book with the smallest number of pages is: {bookWithTheSmallestNumberOfPages.Title} with {bookWithTheSmallestNumberOfPages.PageCount} pages");
// Book bookWithTheEarliestPublishedDate = queries.bookWithTheEarliestPublishedDate();
// Console.WriteLine($"The book with the earliest published date is: {bookWithTheEarliestPublishedDate.Title} published on {bookWithTheEarliestPublishedDate.PublishedDate.ToShortDateString()}");
// Console.WriteLine($"Sum of all pages: {queries.sumOfPagesBetween0and500()}");
// Console.WriteLine($"Book titles published after 2015: {queries.bookTitlesAfter2015()}");
// Console.WriteLine($"Average title characters: {queries.averageTitleCharacters()}");
// Console.WriteLine("Books after 2000 grouped by published year:");
// ShowGroup(queries.booksAfter2000GroupedByPublishedYear());
// Console.WriteLine("Books filtered by letter (a):");
// printDictionary(queries.booksDictionaryByFirstLetter(), 'a');
Console.WriteLine("Books after 2005 and more than 500 pages (Join):");
ShowBooks(queries.booksAfter2005AndMoreThan500Pages());


void ShowBooks(IEnumerable<Book> books)
{
  // {0, -70} -> 0: Title, -70: 70 espacios a la izquierda
  // {1, 7} -> 1: Pages, 7: 7 espacios a la derecha
  // {2, 15} -> 2: Status, 15: 15 espacios a la derecha
  // \n -> Salto de línea
  // entre cada columna se puede poner un caracter para separarlas -> Console.WriteLine("{0, -70} | {1, 7} | {2, 15}\n", "Title", "Pages", "Status");
  Console.WriteLine("{0, -70} {1, 7} {2, 15}\n", "Title", "Pages", "Published Date");

  foreach (var book in books)
  {
    // para fechas, si solo se quiere mostrar la fecha se puede usar book.PublishedDate.ToShortDateString()
    Console.WriteLine("{0, -70} {1, 7} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
  }
}

void ShowGroup(IEnumerable<IGrouping<int, Book>> booksGrouped)
{
  foreach (var group in booksGrouped)
  {
    Console.WriteLine("");
    Console.WriteLine($"Grupo: {group.Key}");
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var book in group)
    {
      Console.WriteLine("{0, -70} {1, 7} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
  }
}

void printDictionary(ILookup<char, Book> bookList, char letter)
{
  char letterUpper = Char.ToUpper(letter);
  if (bookList[letterUpper].Count() == 0)
  {
    Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
  }
  else
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
    foreach (var book in bookList[letterUpper])
    {
      Console.WriteLine("{0, -70} {1, 7} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
  }
}