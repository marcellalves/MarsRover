using Xunit;

namespace MarsRover.UnitTests
{
    public class OrientationTest
    {
        [Fact]
        public void North_ToLeft_ReturnsWest()
        {
            var north = new North();

            var result = north.ToLeft();

            Assert.Equal("W", result.ToString());
        }

        [Fact]
        public void North_ToRight_ReturnsEast()
        {
            var north = new North();

            var result = north.ToRight();

            Assert.Equal("E", result.ToString());
        }

        [Fact]
        public void East_ToLeft_ReturnsNorth()
        {
            var east = new East();

            var result = east.ToLeft();

            Assert.Equal("N", result.ToString());
        }

        [Fact]
        public void East_ToRight_ReturnsSouth()
        {
            var east = new East();

            var result = east.ToRight();

            Assert.Equal("S", result.ToString());
        }

        [Fact]
        public void South_ToLeft_ReturnsEast()
        {
            var south = new South();

            var result = south.ToLeft();

            Assert.Equal("E", result.ToString());
        }

        [Fact]
        public void South_ToRight_ReturnsWest()
        {
            var south = new South();

            var result = south.ToRight();

            Assert.Equal("W", result.ToString());
        }

        [Fact]
        public void West_ToLeft_ReturnsSouth()
        {
            var west = new West();

            var result = west.ToLeft();

            Assert.Equal("S", result.ToString());
        }

        [Fact]
        public void West_ToRight_ReturnsNorth()
        {
            var west = new West();

            var result = west.ToRight();

            Assert.Equal("N", result.ToString());
        }
    }

    public interface IOrientation
    {
        IOrientation ToLeft();
        IOrientation ToRight();
    }

    public class North : IOrientation
    {
        public IOrientation ToLeft()
        {
            return new West();
        }

        public IOrientation ToRight()
        {
            return new East();
        }

        public override string ToString()
        {
            return "N";
        }
    }

    public class East : IOrientation
    {
        public IOrientation ToLeft()
        {
            return new North();
        }
        public IOrientation ToRight()
        {
            return new South();
        }

        public override string ToString()
        {
            return "E";
        }
    }

    public class South : IOrientation
    {
        public IOrientation ToLeft()
        {
            return new East();
        }

        public IOrientation ToRight()
        {
            return new West();
        }

        public override string ToString()
        {
            return "S";
        }
    }

    public class West : IOrientation
    {
        public IOrientation ToLeft()
        {
            return new South();
        }

        public IOrientation ToRight()
        {
            return new North();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}
