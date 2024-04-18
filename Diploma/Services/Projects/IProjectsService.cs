using Diploma.Models;
using RestSharp;

namespace Diploma.Services.Projects
{
    public interface IProjectsService
    {
        Task<NewProjectResponse> CreateNewProject(NewProjectRequest newProjectRequest);
        Task<ProjectResponse> GetProjectByCode(string code);
        Task<ProjectErrorResponse> GetProjectByNonExistingCodeCode(string nonExistingCode);
    }
}