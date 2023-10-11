class Book {
    constructor(title, author, format) {
        this.title = title;
        this.author = author;
        this.format = format;
    }

    static getTotalBooks() {
        let total = 0;
        Library.bookLists.forEach(bookList => {
            total += bookList.books.length;
        });
        return total;
    }
}

// Prototypes (getInfo method)
Book.prototype.getInfo = function () {
    return `${this.title} by ${this.author} (${this.format})`;
};

class EBook extends Book {
    constructor(title, author, format) {
        super(title, author, format);
    }

    getInfo() {
        return `EBook: ${super.getInfo()}`;
    }
}

class PaperBook extends Book {
    constructor(title, author, format) {
        super(title, author, format);
    }

    getInfo() {
        return `PaperBook: ${super.getInfo()}`;
    }
}

class BookList {
    constructor() {
        this.books = [];
    }

    addBook(book) {
        this.books.push(book);
    }

    updateBook(index, title, author, format) {
        this.books[index] = new EBook(title, author, format);
    }

    deleteBook(index) {
        this.books.splice(index, 1);
    }

    displayBooks() {
        const bookListDiv = document.getElementById('book-list');
        bookListDiv.innerHTML = '<h2>Books:</h2><ul>';
        this.books.forEach((book, index) => {
            bookListDiv.innerHTML += `<li>${book.getInfo()} <button onclick="updateBook(${index})">Update</button> <button onclick="deleteBook(${index})">Delete</button></li>`;
        });
        bookListDiv.innerHTML += '</ul>';
    }
}

class Library {
    static bookLists = [];

    addBookList(bookList) {
        Library.bookLists.push(bookList);
    }
}

export { Book, EBook, PaperBook, BookList, Library  };
