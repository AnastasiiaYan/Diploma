namespace Diploma.Models.UIModels
{
    public class Project
    {
        public string Name { get; }
        public string Code { get; }
        public string? Description { get; }

        private Project(string name, string code, string? description)
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public class Builder()
        {
            public string Name { get; set; } = "";
            public string Code { get; set; } = "";
            public string? Description { get; set; } = "";

            public Builder SetName(string name)
            {
                Name = name;
                return this;
            }

            public Builder SetCode(string code)
            {
                Code = code;
                return this;
            }

            public Builder SetDescription(string description)
            {
                Description = description;
                return this;
            }

            public Project Build()
            {
                return new Project(Name, Code, Description);
            }
        }
    }
}