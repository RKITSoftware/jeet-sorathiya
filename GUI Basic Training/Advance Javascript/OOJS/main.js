import {Book, EBook, PaperBook, BookList, Library } from './book.js';

const library = new Library();

const bookList = new BookList();

const book1 = new PaperBook("C#", "Jeet", "Hardcover");
const book2 = new EBook("JavaScript", "Jeet-Sorathiya", "PDF");


bookList.addBook(book1);
bookList.addBook(book2);

library.addBookList(bookList);

bookList.displayBooks();

// Get button
const addButton = document.getElementById('add-button');
const countBooksButton = document.getElementById('count-books-button');

// Add New Book
addButton.addEventListener('click', () => {
    const title = prompt("Enter book title:");
    const author = prompt("Enter author name:");
    const format = prompt("Enter book format (e.g., PDF, Hardcover):");
    const newBook = new EBook(title, author, format);
    bookList.addBook(newBook);
    bookList.displayBooks();
});

// Get Total No. of Book in Alert
countBooksButton.addEventListener('click', () => {
    const totalBooks = Book.getTotalBooks();
    alert(`Total books in the library: ${totalBooks}`);
});

// update Book info
window.updateBook = (index) => {
    const title = prompt("Enter updated book title:");
    const author = prompt("Enter updated author name:");
    const format = prompt("Enter updated book format (e.g., PDF, Hardcover):");
    bookList.updateBook(index, title, author, format);
    bookList.displayBooks();
};

// delete Book info
window.deleteBook = (index) => {
    bookList.deleteBook(index);
    bookList.displayBooks();
};
