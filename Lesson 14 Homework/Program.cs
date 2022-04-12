using PersonClass;

var person1 = new Person("John", "Doe", 34);
ValidateData(person1);

void ValidateData(Person person)
{
    var isDataValid = PersonValidator.Validate(person);
    if (!isDataValid)
    {
        Console.WriteLine("invalid data!");
        return;
    }

    Console.WriteLine("Validation Successfull!");
    Console.WriteLine("Name: {0} {1}, age: {2}", person.Name, person.SecondName, person.Age);
}