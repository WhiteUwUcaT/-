using Xunit;
using DirectoryService.Domain.Position;
using DirectoryService.Domain.Position.ValueObjects;
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
    public void Create_WithInvalidName_ShouldThrowArgumentException(string? invalidName) // Добавь ?
    {
        // Передавай invalidName в метод Create, чтобы xUnit видел, что параметр используется
        Assert.Throws<ArgumentException>(() => PositionName.Create(invalidName!));
    }
}