using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.UnitTests
{
    public class RoverTest
    {
        [Fact]
        public void RoverIsDeployed_InitialCoordinates_PrintsExpectedCurrentLocation()
        {
            var rover = new Rover(1, 2, 'N');

            Assert.Equal("1 2 N", rover.PrintCurrentPosition());
        }

        [Fact]
        public void RoverExecutesSingleInstruction_RotateLeft_PrintsExpectedCurrentLocation()
        {
            var rover = new Rover(1, 2, 'N');

            rover.ExecuteInstructions("L");

            Assert.Equal("1 2 W", rover.PrintCurrentPosition());
        }

        [Fact]
        public void RoverExecutesSingleInstruction_RotateRight_PrintsExpectedCurrentLocation()
        {
            var rover = new Rover(1, 2, 'N');

            rover.ExecuteInstructions("R");

            Assert.Equal("1 2 E", rover.PrintCurrentPosition());
        }

        [Fact]
        public void RoverExecutesSingleInstruction_Move_PrintsExpectedCurrentLocation()
        {
            var rover = new Rover(1, 2, 'N');

            rover.ExecuteInstructions("M");

            Assert.Equal("1 3 N", rover.PrintCurrentPosition());
        }

        [Fact]
        public void RoverExecutesMultipleInstructions_InstructionsString_PrintsExpectedCurrentLocation()
        {
            var rover = new Rover(1, 2, 'N');

            //rover.ExecuteInstructions("LMLMLMLMM");
            rover.ExecuteInstructions("LM");

            Assert.Equal("2 2 W", rover.PrintCurrentPosition());
        }
    }

    public class Rover
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private IOrientation _orientation;
        private readonly IDictionary<char, Action> _executableInstructions;

        public Rover(int x, int y, char orientation)
        {
            _xCoordinate = x;
            _yCoordinate = y;
            _executableInstructions = new Dictionary<char, Action>
            {
                ['L'] = RotateLeft,
                ['R'] = RotateRight,
                ['M'] = Move
            };
            
            _orientation = OrientationRepository.GetByIdentifier(orientation);
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (var instruction in instructions.ToCharArray())
            {
                ExecuteSingleInstruction(instruction);
            }
        }

        public string PrintCurrentPosition()
        {
            return $"{_xCoordinate} {_yCoordinate} {_orientation}";
        }

        private void ExecuteSingleInstruction(char instruction)
        {
            _executableInstructions[instruction].DynamicInvoke();
        }

        private void RotateLeft()
        {
            _orientation = _orientation.ToLeft();
        }

        private void RotateRight()
        {
            _orientation = _orientation.ToRight();
        }

        private void Move()
        {
            switch (_orientation.ToString())
            {
                case "N":
                    _yCoordinate++;
                    break;
                case "S":
                    _yCoordinate--;
                    break;
                case "L":
                    _xCoordinate--;
                    break;
                case "W":
                    _xCoordinate++;
                    break;
            }
        }
    }

    public static class OrientationRepository
    {
        private static readonly IDictionary<char, IOrientation> _orientations = new Dictionary<char, IOrientation>
        {
            { 'N', new North() },
            { 'E', new East() },
            { 'S', new South() },
            { 'W', new West() }
        };

        public static IOrientation GetByIdentifier(char identifier)
        {
            return _orientations[identifier];
        }
    }
}
