using Diploma.Core.Clients;
using Diploma.Services.Projects;
using NLog;

namespace Diploma.Tests.APITests
{
    public class BaseApiTest
    {
        protected ProjectsService? ProjectsService;
        protected SuitesService? SuitesService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void SetUpApi()
        {
            var restClient = new ApiRestClient();
            ProjectsService = new ProjectsService(restClient);
            SuitesService = new SuitesService(restClient);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var allProjectEntity = ProjectsService.GetAllProjects().Result.Result.ProjectEntities;
            if (allProjectEntity.Count > 0)
            {
                foreach (var entity in allProjectEntity)
                {
                    ProjectsService.DeleteProjectByCode(entity.Code);
                    Thread.Sleep(1000);
                    _logger.Debug($"Выполнено удаление проекта {entity.Code}");
                }
            }
            ProjectsService.Dispose();
            SuitesService.Dispose();
        }
    }
}