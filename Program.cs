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
ShowBooks(queries.threeFirstBooks());

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