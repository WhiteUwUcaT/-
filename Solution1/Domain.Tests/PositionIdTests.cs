using DirectoryService.Domain.Position.ValueObjects;
using Xunit;
using System;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionIdTests
    {
        [Fact]
        public void Create_WithValidGuid_ShouldSucceed()
        {
            Guid guid = Guid.NewGuid();
            PositionId vo = PositionId.Create(guid);
            Assert.Equal(guid, vo.Value);
        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PositionId.Create(Guid.Empty));
        }

        [Fact]
        public void Create_New_ShouldHaveNonEmptyValue()
        {
            PositionId vo = PositionId.Create();
            Assert.NotEqual(Guid.Empty, vo.Value);
        }
    }
}