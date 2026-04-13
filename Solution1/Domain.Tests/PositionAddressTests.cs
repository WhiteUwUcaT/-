using DirectoryService.Domain.Position.ValueObjects;
using Xunit;
using System;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionAddressTests
    {
        [Theory]
        [InlineData("г. Красноярск, пр. Мира, 82")]
        [InlineData("")]
        public void Create_WithValidAddress_ShouldSucceed(string value)
        {
            PositionAddress vo = PositionAddress.Create(value);
            Assert.Equal(value, vo.Value);
        }

        [Fact]
        public void Create_WithNull_ShouldReturnEmptyAddress()
        {
            PositionAddress vo = PositionAddress.Create(null!);
            Assert.Equal(string.Empty, vo.Value);
        }

        [Fact]
        public void Create_WithTooLongAddress_ShouldThrowArgumentException()
        {
            string longAddress = new string('A', 501);
            Assert.Throws<ArgumentException>(() => PositionAddress.Create(longAddress));
        }
    }
}