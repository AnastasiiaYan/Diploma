using Bogus;
using Diploma.Models.APIModels;
using Diploma.Models.APIModels.Fakers;

namespace Diploma.Tests.APITests
{
    public class SuitesTests : BaseApiTest
    {
        private static Faker<NewProjectRequest> NewProjectRequestFaker => new NewProjectRequestFaker();
        private static Faker<NewSuiteRequest> NewSuiteRequestFaker => new NewSuiteRequestFaker();

        [Test]
        public void CreateTestSuiteTest()
        {
            NewProjectRequest newProjectRequest = NewProjectRequestFaker.Generate();
            NewSuiteRequest newSuiteRequest = NewSuiteRequestFaker.Generate();

            var newProjectResponse =
                ProjectsService!.CreateNewProject(newProjectRequest).Result;

            var actualResponse =
                SuitesService!.CreateNewTestSuite(newSuiteRequest, newProjectResponse.Result.Code).Result;

            var allSuitesResponse =
                SuitesService!.GetAllTestSuitesBy(newProjectResponse.Result.Code, newSuiteRequest.Title).Result;

            var expectedResponse = new NewSuiteResponse
            {
                Status = true,
                Result = new NewSuiteResultData
                {
                    Id = allSuitesResponse.Result.Entities[0].Id
                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.Result.Id, Is.EqualTo(expectedResponse.Result.Id));
            });
        }

        [Test]
        public void GetAllTestSuitesByTitleTest()
        {
            NewProjectRequest newProjectRequest = NewProjectRequestFaker.Generate();
            NewSuiteRequest newSuiteRequest = NewSuiteRequestFaker.Generate();

            var newProjectResponse =
                ProjectsService!.CreateNewProject(newProjectRequest).Result;

            var newSuiteResponse =
                SuitesService!.CreateNewTestSuite(newSuiteRequest, newProjectResponse.Result.Code).Result;

            List<SuiteEntity> suiteEntity = new List<SuiteEntity>
            {
                new()
                {
                    Id = newSuiteResponse.Result.Id,
                    Title = newSuiteRequest.Title,
                    Description = newSuiteRequest.Description,
                    Preconditions = newSuiteRequest.Preconditions,
                    Position = 1,
                    CasesCount = 0
                }
            };

            var expectedResponse = new AllSuitesResponse
            {
                Status = true,
                Result = new AllSuitesResultData
                {
                    Total = 1,
                    Filtered = 1,
                    Count = 1,
                    Entities = suiteEntity
                }
            };

            var actualResponse =
                SuitesService!.GetAllTestSuitesBy(newProjectResponse.Result.Code, newSuiteRequest.Title).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.Result.Total, Is.EqualTo(expectedResponse.Result.Total));
                Assert.That(actualResponse.Result.Filtered, Is.EqualTo(expectedResponse.Result.Filtered));
                Assert.That(actualResponse.Result.Count, Is.EqualTo(expectedResponse.Result.Count));
                Assert.That(actualResponse.Result.Entities[0].Id, Is.EqualTo(expectedResponse.Result.Entities[0].Id));
                Assert.That(actualResponse.Result.Entities[0].Title, Is.EqualTo(expectedResponse.Result.Entities[0].Title));
                Assert.That(actualResponse.Result.Entities[0].Description, Is.EqualTo(expectedResponse.Result.Entities[0].Description));
                Assert.That(actualResponse.Result.Entities[0].Preconditions, Is.EqualTo(expectedResponse.Result.Entities[0].Preconditions));
                Assert.That(actualResponse.Result.Entities[0].Position, Is.EqualTo(expectedResponse.Result.Entities[0].Position));
            });
        }

        [Test]
        public void GetSpecificTestSuiteTest()
        {
            NewProjectRequest newProjectRequest = NewProjectRequestFaker.Generate();
            NewSuiteRequest newSuiteRequest = NewSuiteRequestFaker.Generate();

            var newProjectResponse =
                ProjectsService!.CreateNewProject(newProjectRequest).Result;

            var newSuiteResponse =
                SuitesService!.CreateNewTestSuite(newSuiteRequest, newProjectResponse.Result.Code).Result;

            var searchSuitesResponse =
                SuitesService!.GetAllTestSuitesBy(newProjectResponse.Result.Code, newSuiteRequest.Title).Result;

            var expectedResponse = new SpecificSuiteResponse
            {
                Status = true,
                Result = new SpecificSuiteResultData
                {
                    Id = searchSuitesResponse.Result.Entities[0].Id,
                    Title = searchSuitesResponse.Result.Entities[0].Title,
                    Description = searchSuitesResponse.Result.Entities[0].Description,
                    Preconditions = searchSuitesResponse.Result.Entities[0].Preconditions,
                    Position = searchSuitesResponse.Result.Entities[0].Position,
                    CasesCount = searchSuitesResponse.Result.Entities[0].CasesCount
                }
            };

            var actualResponse =
                SuitesService!.GetSpecificTestSuite(newProjectResponse.Result.Code, newSuiteResponse.Result.Id).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.Result.Id, Is.EqualTo(expectedResponse.Result.Id));
                Assert.That(actualResponse.Result.Title, Is.EqualTo(expectedResponse.Result.Title));
                Assert.That(actualResponse.Result.Description, Is.EqualTo(expectedResponse.Result.Description));
                Assert.That(actualResponse.Result.Preconditions, Is.EqualTo(expectedResponse.Result.Preconditions));
                Assert.That(actualResponse.Result.Position, Is.EqualTo(expectedResponse.Result.Position));
                Assert.That(actualResponse.Result.CasesCount, Is.EqualTo(expectedResponse.Result.CasesCount));
            });
        }

        [Test]
        public void GetAllTestSuitesByNonExistingCodeTest()
        {
            var nonExistingCode = "++123//";

            ErrorResponse expectedResponse = new ErrorResponse
            {
                Status = false,
                ErrorMessage = "Project not found"
            };

            var actualResponse = SuitesService!.GetAllTestSuitesBy(nonExistingCode).Result;

            Assert.Multiple(() =>
            {
                Assert.That(actualResponse.Status, Is.EqualTo(expectedResponse.Status));
                Assert.That(actualResponse.ErrorMessage, Is.EqualTo(expectedResponse.ErrorMessage));
            });

        }
    }
}