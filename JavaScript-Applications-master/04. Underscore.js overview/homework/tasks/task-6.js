/* 
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
  return function (books) {
+        var last = _.chain(books)
+            .groupBy(function(book) {
+                return book.author.firstName + ' ' + book.author.lastName;
+            }).map(function(v, k) {
+                return {
+                    key: k,
+                    value: v
+                }
+            })
+            .groupBy(function (book) { return book.value.length; })
+            .map(function (v, k) {
+                return {
+                    key: k,
+                    value: v
+                }
+            })
+            .max(function(book) {
+                return book.key;
+            }).value();
+
+        _.chain(last.value).sortBy(function (book) {
+                return book.key;
+            })
+            .each(function(book) {
+                console.log(book.key);
+            });
+    };
}

module.exports = solve;
