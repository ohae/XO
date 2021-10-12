using System;
using Xunit;

namespace XOXO.Test
{
    public class GameEngineTest
    {
        /* 
        Game rules
            - The game play with 3x3 table
            - The game is over when has winner or both draw.
            - The game in not over
                |o|x|o|
                |x|o|x|
                |o|x| |
            - The game input invalid state
                |Y|Z|o|
                |x|o|x|
                |o|x| |
            - The winner is who mark 3 in a row
                horizontal  vertical    diagonal
                |o|o|o|     |-|x|-|     |-|-|o|
                |-|-|-|     |-|x|-|     |-|o|-|
                |-|-|-|     |-|x|-|     |o|-|-|
            - The game will draw when no one can mark 3 in a row
                |o|x|o|
                |x|o|o|
                |x|o|x|
        
        Note
            Play first can mark 5 times
            Play later can mark 4 times
            
        Scenario
            1. The game is not over yet.
            2. The game is over and O is a winner.
            3. The game is over and X is a winner.
            4. The game is over and they both draw.
            5. The game input state is invalid.
        */

        [Fact]
        public void TheGameIsNotOver()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', 'x', 'o' },
                { 'x', 'o', 'x' },
                { 'x', 'x', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.VerifyTheGameHasEnded();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void OWin()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', 'o', ' ' },
                { 'x', 'o', 'x' },
                { 'x', 'x', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.WhosWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void XWin()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', ' ', 'x' },
                { 'o', 'o', 'x' },
                { 'x', 'o', 'x' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.WhosWin();

            // Assert
            Assert.Equal('x', actual);
        }
        [Fact]
        public void Draw()
        {
            // Arrange
            var input = new char[,]
            {
                { 'x', 'o', 'x' },
                { 'o', 'o', 'x' },
                { 'o', 'x', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.WhosWin();

            // Assert
            Assert.Equal(0, actual);
        }
        [Fact]
        public void OWinVertical1()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', 'o', ' ' },
                { 'o', 'x', 'x' },
                { 'o', 'x', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.VerticalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinVertical2()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', 'o', ' ' },
                { 'x', 'o', 'x' },
                { 'x', 'o', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.VerticalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinVertical3()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', ' ', 'o' },
                { 'x', 'x', 'o' },
                { 'x', ' ', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.VerticalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinHorizontal1()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', 'o', 'o' },
                { 'x', 'o', 'x' },
                { 'x', ' ', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.HorizontalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinHorizontal2()
        {
            // Arrange
            var input = new char[,]
            {
                { 'x', 'o', 'x' },
                { 'o', 'o', 'o' },
                { 'x', ' ', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.HorizontalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinHorizontal3()
        {
            // Arrange
            var input = new char[,]
            {
                { 'x', ' ', ' ' },
                { 'x', 'o', 'x' },
                { 'o', 'o', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.HorizontalWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinDiagonalLeftToRight()
        {
            // Arrange
            var input = new char[,]
            {
                { 'o', ' ', 'o' },
                { 'x', 'o', 'x' },
                { 'x', ' ', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.DiagonalL2RWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void OWinDiagonalRightToLeft()
        {
            // Arrange
            var input = new char[,]
            {
                { 'x', ' ', 'o' },
                { 'x', 'o', 'x' },
                { 'o', ' ', 'o' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.DiagonalR2LWin();

            // Assert
            Assert.Equal('o', actual);
        }
        [Fact]
        public void InvalidState()
        {
            // Arrange
            var input = new char[,]
            {
                { 'z', 'x', 'x' },
                { 'x', 'o', 'x' },
                { 'x', 'x', ' ' }
            };
            var engine = new GameEngine(input);

            // Act
            var actual = engine.VerifyTheGameState();

            // Assert
            Assert.False(actual);
        }
        [Fact]
        public void WhosWin()
        {
            //Arrange
            var input = new char[,]
            {
                { 'o', ' ', 'x' },
                { 'o', 'o', 'x' },
                { 'x', 'o', 'x' }
            };
            var engine = new GameEngine(input);

            //Act
            var actual = engine.WhosWin();

            //Assert
            Assert.NotEqual(0, actual);
        }
    }
}
