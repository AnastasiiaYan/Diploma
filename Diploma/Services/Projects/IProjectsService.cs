using Diploma.Models;
using RestSharp;

namespace Diploma.Services.Projects
{
    public interface IProjectsService
    {
        Task<NewProjectResponse> CreateNewProject(NewProjectRequest newProjectRequest);
    }
}