using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Application.Features.Alerts.Commands.CreateAlert;
using CryptoTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CryptoTracker.Application.Tests
{
    [TestFixture]
    public class CreateAlertCommandHandlerTests
    {
        private Mock<IApplicationDbContext> _contextMock;
        private CreateAlertCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IApplicationDbContext>();
            _handler = new CreateAlertCommandHandler(_contextMock.Object);
        }

        [Test]
        public async Task Handle_ShouldCreateAlert_AndReturnGuid()
        {
            var mockSet = new Mock<DbSet<Alert>>();
            _contextMock.Setup(x => x.Alerts).Returns(mockSet.Object);

            _contextMock
                .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            CreateAlertCommand command = new CreateAlertCommand()
            {
                UserId = Guid.Parse("2C6B67B9-B751-4102-BD80-D39DC8DC93E8"),
                AssetId = Guid.Parse("9EF730F7-E684-4BD0-B1A5-05DC92B853D6"),
                TargetPrice = 51000M,
                Direction = 0
            };

            var result = await _handler.Handle(command, CancellationToken.None);
            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public async Task Handle_ShouldCallSaveChanges_Once()
        {
            var mockSet = new Mock<DbSet<Alert>>();
            _contextMock.Setup(x => x.Alerts).Returns(mockSet.Object);

            _contextMock
                .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            CreateAlertCommand command = new CreateAlertCommand()
            {
                UserId = Guid.Parse("2C6B67B9-B751-4102-BD80-D39DC8DC93E8"),
                AssetId = Guid.Parse("9EF730F7-E684-4BD0-B1A5-05DC92B853D6"),
                TargetPrice = 51000M,
                Direction = 0
            };

            var result = await _handler.Handle(command, CancellationToken.None);
            _contextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }

}