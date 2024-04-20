using System.Reflection;
using Bogus;
using Diploma.Models;
using Diploma.Models.Fakers;

namespace Diploma.Tests.APITests
{
    public class ProjectTests : BaseApiTest
    {
        private static Faker<NewProjectRequest> NewProjectRequestFaker => new NewProjectRequestFaker();

        [Test]
        public void CreateNewProjectTest()
        {
            NewProjectRequest newProjectRequest = NewProjectRequestFaker.Generate();

            NewProjectResponse expectedResponse = new NewProjectResponse
            {
                Status = true,
                Result = new NewProjectResultData
                {
                    Code = newProjectRequest.Code
                }
            };

            var actualResponse = ProjectsService!.CreateNewProject(newProjectRequest).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.Result.Code, Is.EqualTo(expectedResponse.Result.Code));
            });
        }

        [Test]
        public void GetProjectByCodeTest()
        {
            NewProjectRequest newProjectRequest = NewProjectRequestFaker.Generate();

            ProjectResultData expectedResultData = new ProjectResultData
            {
                Title = newProjectRequest.Title,
                Code = newProjectRequest.Code,
                Counts = new Counts
                {
                    Cases = 0,
                    Suites = 0,
                    Milestones = 0,
                    Runs = new Runs
                    {
                        Total = 0,
                        Active = 0
                    },
                    Defects = new Defects
                    {
                        Total = 0,
                        Open = 0
                    }
                }
            };

            ProjectResponse expectedResponse = new ProjectResponse
            {
                Status = true,
                Result = expectedResultData
            };

            ProjectsService!.CreateNewProject(newProjectRequest);

            var actualResponse = ProjectsService!.GetProjectByCode(newProjectRequest.Code).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.Result.Title, Is.EqualTo(expectedResponse.Result.Title));
                Assert.That(actualResponse.Result.Code, Is.EqualTo(expectedResponse.Result.Code));
                foreach (PropertyInfo property in typeof(Counts).GetProperties()) // возможно проще перечислить
                {
                    var value = property.GetValue(actualResponse.Result.Counts);
                    if (value is int numericValue)
                    {
                        Assert.That(numericValue, Is.EqualTo(0));
                    }
                }
            });
        }

        [Test]
        public void GetProjectByNonExistingCodeTest()
        {
            var nonExistingCode = "///+++";

            ErrorResponse expectedResponse = new ErrorResponse
            {
                Status = false,
                ErrorMessage = "Project not found"
            };

            var actualResponse = ProjectsService!.GetProjectByNonExistingCode(nonExistingCode).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.ErrorMessage, Is.EqualTo(expectedResponse.ErrorMessage));
            });
        }
    }
}