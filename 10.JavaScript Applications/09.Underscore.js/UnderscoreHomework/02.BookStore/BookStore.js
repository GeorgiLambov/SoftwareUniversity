(function () {
    //check if running on Node.js
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('./underscore.js');
    }
    
    String.prototype.repeat = function (num) {
        return new Array(num + 1).join(this);
    };
    
    var books = [
        { "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "34.24", "language": "French" },
        { "book": "The Great Gatsby", "author": "F. Scott Fitzgerald", "price": "39.26", "language": "English" },
        { "book": "Nineteen Eighty-Four", "author": "George Orwell", "price": "15.39", "language": "English" },
        { "book": "Ulysses", "author": "James Joyce", "price": "23.26", "language": "German" },
        { "book": "Lolita", "author": "Vladimir Nabokov", "price": "14.19", "language": "German" },
        { "book": "Catch-22", "author": "Joseph Heller", "price": "47.89", "language": "German" },
        { "book": "The Catcher in the Rye", "author": "J. D. Salinger", "price": "25.16", "language": "English" },
        { "book": "Beloved", "author": "Toni Morrison", "price": "48.61", "language": "French" },
        { "book": "Of Mice and Men", "author": "John Steinbeck", "price": "29.81", "language": "Bulgarian" },
        { "book": "Animal Farm", "author": "George Orwell", "price": "38.42", "language": "English" },
        { "book": "Finnegans Wake", "author": "James Joyce", "price": "29.59", "language": "English" },
        { "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "42.94", "language": "English" }
    ];
    
    (function () {
        console.log('*'.repeat(50));
        console.log("Group all books by language and sort them by author (if two books have the same author, sort by price)");
        console.log('*'.repeat(50));
        
        var groupByLanguage = _.groupBy(books, "language");
        
        for (var group in groupByLanguage) {
            var curruntLangugeGroup = groupByLanguage[group];
            
            curruntLangugeGroup.sort(function (a, b) {
                var result = a.author.localeCompare(b.author);
                if (result === 0) {
                    result = (Number)(a.price) - (Number)(b.price);
                }
                return result;
            });
            console.log(group);
            console.log('-'.repeat(50));
            curruntLangugeGroup.forEach(function (book) {
                printBook(book);
            });
        }
    }());
    
    (function () {
        console.log('*'.repeat(50));
        console.log("Get the average book price for each author");
        console.log('*'.repeat(50));
        
        var groupByAuthor = _.groupBy(books, "author");
        
        for (var author in groupByAuthor) {
            var curruntAuthorGroup = groupByAuthor[author];
            var averageSum = 0;
            
            curruntAuthorGroup.forEach(function (book) {
                averageSum += (Number)(book.price);
            });
            averageSum = averageSum / curruntAuthorGroup.length;
            console.log(author + " average book price: " + averageSum);
        }
    }());
    
    (function () {
        console.log('*'.repeat(50));
        console.log("Get all books in English or German, with price below 30.00, and group them by author");
        console.log('*'.repeat(50));
        
        var filteredByEnglandGerman = _.filter(books, function (book) {
            return (book.language === "English" || book.language === "German") 
            && (Number)(book.price) < 30;
        });
        
        var groupByAuthor = _.groupBy(filteredByEnglandGerman, "author");
        
        for (var author in groupByAuthor) {
            var curruntAuthorGroup = groupByAuthor[author];
            console.log(author);
            curruntAuthorGroup.forEach(function (book) {
                printBook(book);
            });
        }
    }());
    
    function printBook(book) {
        console.log(book.book + ' author:' + book.author + ', price:' 
         + book.price + ', language: ' + book.language);
    }
}());