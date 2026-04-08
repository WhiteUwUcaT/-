using DirectoryService.Domain.PositionsContext.ValueObjects;
using DirectoryService.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DirectoryService.Domain.Position.ValueObjects.Tests
{
    public class PositionTests
    {
        [Fact]
        public void UpdateName_WhenArchived_ShouldThrowException()
        {
            // Arrange
            var pos = Position.Create(PositionName.Create("Dev"), PositionAddress.Empty(), PositionTimeZone.Empty());
            // Допустим, у нас есть способ сделать его архивным (через LifeTime)
            var archivedPos = Position.Create(pos.Id.Value, pos.Name, pos.Address, pos.TimeZone, pos.IsActive,
                EntityLifeTime.Create(DateTime.UtcNow, DateTime.UtcNow, true));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => archivedPos.UpdateName(PositionName.Create("New Name")));
        }
    }
}
