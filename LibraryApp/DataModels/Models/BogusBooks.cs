using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class BogusBooks
    {
        private static readonly List<string> BookTitles = new List<string>
        {
        "The Great Gatsby",
        "To Kill a Mockingbird",
        "1984",
        "The Catcher in the Rye",
        "Pride and Prejudice",
        "The Lord of the Rings:Fellowship of the Ring",
        "Harry Potter and the Sorcerer's Stone",
        "The Hobbit",
        "Fahrenheit 451",
        "Do Electric Sheep,Dream Electirc Dreams",
        "Foundation",
        "IRobot",
        "Wind-up Bird",
        "No longer human",
        "Artemis Foul",
        "Without a Family",
        "Three Body Problem",
        "Guns,Germs and Steel",
        "Freakonomics",
        "Paradise Lost",
        "The Witcher",
        "Death Parade",
        "Brave new World",
        "Altered Carbon",
        "The Shock Doctrine",
        "Murphy's Law",
        "Sherlock Holmes Anthology"

    };

        public List<Book> GenerateBooks(int count)
        {
            var faker = new Faker<Book>()
                .RuleFor(b => b.Id, f => f.IndexFaker)
                .RuleFor(b => b.Title, f => f.PickRandom(BookTitles))
                .RuleFor(b => b.Author, f => f.Person.FullName)
                .RuleFor(b => b.Isbn, f => string.Concat(f.Lorem.Random.Digits(10))) // previous random digits generation caused issues!
                .RuleFor(b => b.PublishedDate, f => f.Date.Past(10))
                .RuleFor(b => b.Price, f => f.Random.Decimal(6.00M,76.00M))
                .RuleFor(b => b.Quantity, f => f.Random.Int(1, 100));
            
            return faker.Generate(count);
        }

    }
}
