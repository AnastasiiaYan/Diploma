using Bogus;

namespace Diploma.Models.Fakers
{
    public sealed class NewSuiteRequestFaker : Faker<NewSuiteRequest>
    {
        public NewSuiteRequestFaker()
        {
            RuleFor(b => b.Title, f => f.Random.Words(1));
            RuleFor(b => b.Description, f => f.Random.Words(2));
            RuleFor(b => b.Preconditions, f => f.Random.Words(2));
        }
    }
}