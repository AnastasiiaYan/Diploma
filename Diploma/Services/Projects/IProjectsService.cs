using Diploma.Models;
using Diploma.Models.APIModels;

namespace Diploma.Services.Projects
{
    public interface IProjectsService
    {
        Task<NewProjectResponse> CreateNewProject(NewProjectRequest newProjectRequest);

        Task<ProjectResponse> GetProjectByCode(string code);

        Task<ErrorResponse> GetProjectByNonExistingCode(string nonExistingCode);

        Task<AllProjectsResponse> GetAllProjects();

        Task<DeleteProjectResponse> DeleteProjectByCode(string projectCode);
    }
}