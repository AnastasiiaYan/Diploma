﻿using Diploma.Models;
using Diploma.Services.Projects;
using NLog;

namespace Diploma.Tests.APITests
{
    public class ProjectTests : BaseApiTest
    {

        [Test]
        [Order(1)]
        public void CreateNewProjectTest()
        {
            NewProjectRequest requestBody = new NewProjectRequest
            {
                Title = "Заголовок тестового проекта",
                Code = "Test",
                Description = "Описание тестового проекта",
                Access = "all"
            };

            NewProjectResponse expectedResponse = new NewProjectResponse
            {
                Status = true,
                Result = new NewProjectResultData { Code = requestBody.Code }
            };

            var actualResponse = ProjectsService!.CreateNewProject(requestBody).Result;
            //assert
        }
    }
}
