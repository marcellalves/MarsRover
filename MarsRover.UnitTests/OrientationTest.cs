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

        [Fact]
        public void North_Move_ReturnsNewPositionWithYAxisIncreased()
        {
            var north = new North();

            var result = north.Move(new Position(1, 1));

            Assert.Equal(1, result.X);
            Assert.Equal(2, result.Y);
        }

        [Fact]
        public void East_Move_ReturnsNewPositionWithXAxisIncreased()
        {
            var east = new East();

            var result = east.Move(new Position(1, 1));

            Assert.Equal(2, result.X);
            Assert.Equal(1, result.Y);
        }

        [Fact]
        public void South_Move_ReturnsNewPositionWithYAxisDecreased()
        {
            var south = new South();

            var result = south.Move(new Position(1, 1));

            Assert.Equal(1, result.X);
            Assert.Equal(0, result.Y);
        }

        [Fact]
        public void West_Move_ReturnsNewPositionWithXAxisDecreased()
        {
            var west = new West();

            var result = west.Move(new Position(1, 1));

            Assert.Equal(0, result.X);
            Assert.Equal(1, result.Y);
        }
    }

    public interface IOrientation
    {
        IOrientation ToLeft();
        IOrientation ToRight();
        Position Move(Position currentPosition);
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

        public Position Move(Position currentPosition)
        {
            return new Position(currentPosition.X, currentPosition.Y + 1);
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

        public Position Move(Position currentPosition)
        {
            return new Position(currentPosition.X + 1, currentPosition.Y);
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

        public Position Move(Position currentPosition)
        {
            return new Position(currentPosition.X, currentPosition.Y - 1);
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

        public Position Move(Position currentPosition)
        {
            return new Position(currentPosition.X - 1, currentPosition.Y);
        }

        public override string ToString()
        {
            return "W";
        }
    }

    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
