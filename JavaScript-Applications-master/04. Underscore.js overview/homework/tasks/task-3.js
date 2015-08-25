/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
    return function (students) {
        _.chain(students).sortBy(function(student) {
            var marks = student.marks;
            var sum = 0;
            var index

            for (index in marks) {
                sum += marks[index];
            }

            return (sum / marks.length);
        }).last(1).each(function (student) {
            var marks = student.marks;
            var sum = 0;
            var index;

            for (index in marks) {
                sum += marks[index];
            }

            var averange = sum / marks.length;
            var fullName = student.firstName + ' ' + student.lastName;

            console.log(fullName + ' has an average score of ' + averange);
        })
  };
}

module.exports = solve;
