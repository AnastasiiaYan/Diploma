using Diploma.Models;

namespace Diploma.Services.Projects
{
    public interface IProjectsService
    {
        Task<NewProjectResponse> CreateNewProject(NewProjectRequest newProjectRequest);

        Task<ProjectResponse> GetProjectByCode(string code);

        Task<ErrorResponse> GetProjectByNonExistingCode(string nonExistingCode);
    }
}