using DirectoryService.Domain.Position.ValueObjects;
using Xunit;
using System;

namespace DirectoryService.Domain.Tests.Position.ValueObjects
{
    public class PositionRankTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void Create_WithValidRank_ShouldSucceed(int value)
        {
            PositionRank vo = PositionRank.Create(value);
            Assert.Equal(value, vo.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidRank_ShouldThrowArgumentException(int invalidValue)
        {
            Assert.Throws<ArgumentException>(() => PositionRank.Create(invalidValue));
        }
    }
}