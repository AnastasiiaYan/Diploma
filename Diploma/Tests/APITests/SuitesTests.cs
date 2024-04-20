using Diploma.Models;

namespace Diploma.Tests.APITests
{
    public class SuitesTests : BaseApiTest
    {
        NewProjectRequest newProjectRequest = new NewProjectRequest
        {
            Title = "Заголовок тестового проекта2",
            Code = "TEST12345",
            Description = "Описание тестового проекта2",
            Access = "all"
        };

        private NewSuiteRequest newSuiteRequest = new NewSuiteRequest
        {
            Title = "Заголовок сьюта",
            Description = "Описание сьюта",
            Preconditions = "Предусловие сьюта",
        };

        [Test]
        public void CreateTestSuiteTest()
        {
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
            var newProjectResponse =
                ProjectsService!.CreateNewProject(newProjectRequest).Result;

            var newSuiteResponse =
                SuitesService!.CreateNewTestSuite(newSuiteRequest, newProjectResponse.Result.Code).Result;

            List<SuiteEntity> suiteEntity = new List<SuiteEntity>
            {
                new SuiteEntity
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