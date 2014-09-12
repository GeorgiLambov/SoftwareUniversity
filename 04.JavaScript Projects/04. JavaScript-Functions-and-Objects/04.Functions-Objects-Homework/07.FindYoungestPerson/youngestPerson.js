function findYoungestPerson(persons) {
    var minAge = Number.POSITIVE_INFINITY;
    var person;
    for (var index in persons) {
        if (persons[index].age) {
            var age = persons[index].age;
            if (age < minAge) {
                minAge = age;
                person = persons[index];
            }
        }
    }
    console.log("The youngest person is %s %s", person.firstname, person.lastname);

}
var persons = [
  { firstname: 'George', lastname: 'Kolev', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'Baba', lastname: 'Ginka', age: 40 }]

findYoungestPerson(persons);
