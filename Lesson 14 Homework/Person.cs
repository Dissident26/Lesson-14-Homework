using RegExpValidator;

namespace PersonClass
{
    public class Person
    {
        [RegExpValidator(@"^[a-z]{2,10}$")]
        public string Name { get; }
        [RegExpValidator(@"^[a-z]{2,10}$")]
        public string SecondName { get; }
        [RegExpValidator(@"\d")]
        public int Age { get; }

        public Person(string name, string secondName, int age)
        {
            Name = name; 
            SecondName = secondName; 
            Age = age;    
        }
    }

    public static class PersonValidator
    {
        public static bool Validate(Person person)
        {
            Type type = typeof(Person);
            List<bool> result = new();

            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is RegExpValidatorAttribute attr)
                    {
                        var value = property.GetValue(person)?.ToString();
                        var isPropValid = attr.IsValid(value);

                        result.Add(isPropValid);
                    }
                }
            }

            return result.All(x => x);
        }
    }
}
