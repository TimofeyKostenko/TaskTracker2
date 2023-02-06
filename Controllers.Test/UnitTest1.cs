using TaskTracker.Controllers;
using FakeItEasy;
using Business.Interfaces;
using Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Test
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async Task Test1Async()
        {
            //Arange
            var projectId = 1;
            var fakeProject = A.Dummy<ProjectDTO>();
            var dataStore = A.Fake<IProjectService>();
            A.CallTo(() => dataStore.GetProjectAsync(projectId)).Returns(Task.FromResult(fakeProject));
            var controller = new ProjectsController(dataStore);

            //Act
            var actionResult = await controller.GetAsync(projectId);
            //Assert
            var result = actionResult  as OkObjectResult;
            var a = result.Value as ProjectDTO;
            Assert.NotNull(a); // ?
        }
    }
}