namespace N5ChallengeWebApiUnitTest
{
    using Xunit;
    using Moq;
    using Microsoft.Extensions.Logging;
    using MediatR;
    using N5ChallengeWebApi.Controllers;
    using N5ChallengeWebApiApplication.DTOs;
    using N5ChallengeWebApiApplication.Features.Commands;
    using N5ChallengeWebApiApplication.Features.Queries;
    using System.Threading;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    namespace WebApplication1.Tests
    {
        public class PermissionTesting
        {
            private readonly Mock<IMediator> _mediatorMock;
            private readonly Mock<ILogger<PermissionController>> _loggerMock;
            private readonly PermissionController _controller;

            public PermissionTesting()
            {
                _mediatorMock = new Mock<IMediator>();
                _loggerMock = new Mock<ILogger<PermissionController>>();
                _controller = new PermissionController(_mediatorMock.Object, _loggerMock.Object);
            }

            [Fact]
            public async void GetAllPermissions_ReturnsOkResult()
            {
                // Arrange
                _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPermissionsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllPermissionsQuery.Response());

                // Act
                var result = await _controller.GetAllPermissions();

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }

            [Fact]
            public async void RequestPermission_ReturnsCreatedResult()
            {
                // Arrange
                var permission = new RequestPermission() { EmployeeForename = "Andrés", EmployeeSurname = "León Doylet", PermissionTypeId = 1};
                _mediatorMock.Setup(m => m.Send(It.IsAny<RequestPermissionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new RequestPermissionCommand.Response());

                // Act
                var result = await _controller.RequestPermission(permission);

                // Assert
                Assert.IsType<StatusCodeResult>(result);
                Assert.Equal((int)HttpStatusCode.Created, ((StatusCodeResult)result).StatusCode);
            }

            [Fact]
            public async void ModifyPermission_ReturnsNoContentResult()
            {
                // Arrange
                var permission = new ModifyPermission() { EmployeeForename = "", EmployeeSurname = "", Id = 1, PermissionTypeId = 1};
                _mediatorMock.Setup(m => m.Send(It.IsAny<ModifyPermissionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

                // Act
                var result = await _controller.ModifyPermission(permission);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }
    }

}