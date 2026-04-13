using DirectoryService.Domain.Position.ValueObjects;
using DirectoryService.Domain.Shared;
using Xunit;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionTests
    {
        [Fact]
        public void UpdateName_WhenArchived_ShouldThrowException()
        {
            // Arrange
            var pos = Domain.Position.Position.Create(PositionName.Create("Dev"), PositionAddress.Empty(), PositionTimeZone.Empty());
            var archivedPos = Domain.Position.Position.Create(pos.Id.Value, pos.Name, pos.Address, pos.TimeZone, pos.IsActive,
                EntityLifeTime.Create(DateTime.UtcNow, DateTime.UtcNow, true));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => archivedPos.UpdateName(PositionName.Create("New Name")));
        }
    }
}
