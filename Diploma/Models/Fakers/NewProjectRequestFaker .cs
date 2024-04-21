using Bogus;

namespace Diploma.Models.Fakers
{
    public sealed class NewProjectRequestFaker : Faker<NewProjectRequest>
    {
        public NewProjectRequestFaker()
        {
            RuleFor(b => b.Title, f => f.Random.Words(1));
            RuleFor(b => b.Code, f => f.Random.String(5, 'a', 'z').ToUpper());
            RuleFor(b => b.Description, f => f.Random.Words(2));
        }
    }
}