using DirectoryService.Domain.Position.ValueObjects;
using Xunit;
using System;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionTimeZoneTests
    {
        [Theory]
        [InlineData("UTC+3", "UTC+3")]
        [InlineData("  UTC+7  ", "UTC+7")] // Проверка Trim
        public void Create_WithValidTimeZone_ShouldSucceedAndTrim(string input, string expected)
        {
            PositionTimeZone vo = PositionTimeZone.Create(input);
            Assert.Equal(expected, vo.Value);
        }

        [Fact]
        public void Create_WithNull_ShouldReturnEmptyString()
        {
            PositionTimeZone vo = PositionTimeZone.Create(null!);
            Assert.Equal(string.Empty, vo.Value);
        }

        [Fact]
        public void Create_WithTooLongTimeZone_ShouldThrowArgumentException()
        {
            string longTz = new string('Z', 101);
            Assert.Throws<ArgumentException>(() => PositionTimeZone.Create(longTz));
        }
    }
}