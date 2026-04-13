using Xunit;
using DirectoryService.Domain.Position;
using DirectoryService.Domain.Position.ValueObjects;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionNameTests
    {
        [Theory]
        [InlineData("HR")]
        [InlineData("Software Developer")]
        public void Create_WithValidName_ShouldSucceed(string name)
        {
            PositionName vo = PositionName.Create(name);
            Assert.Equal(name, vo.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_WithInvalidName_ShouldThrowArgumentException(string? invalidName)
        {
            Assert.Throws<ArgumentException>(() => PositionName.Create(invalidName!));
        }
    }
}