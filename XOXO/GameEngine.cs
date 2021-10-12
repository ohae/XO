using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XOXO
{
    public class GameEngine
    {
        private readonly char[,] _input;
        private readonly int xInARow = 3; //3x3 table

        public GameEngine(char[,] input)
        {
            this._input = input;
        }

        public char WhosWin()
        {
            var verWin = VerticalWin();
            var horWin = HorizontalWin();
            var dia1Win = DiagonalL2RWin();
            var dia2Win = DiagonalR2LWin();

            var c = new char[] { verWin, horWin, dia1Win, dia2Win };

            //if no winner return 0
            var winner = c.Where(x => x != ' ').FirstOrDefault();

            return winner;
        }

        public char VerticalWin()
        {
            int consecutiveCount = 1;
            char previousMark = ' ';
            for (int vertical = 0; vertical < _input.GetLength(1); vertical++)
            {
                for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
                {
                    if (previousMark == ' ')
                    { previousMark = _input[horizontal, vertical]; }
                    else if (previousMark == _input[horizontal, vertical])
                    {
                        consecutiveCount++;
                    }
                    else
                    {
                        break;
                    };
                }

                if (consecutiveCount == xInARow)
                {
                    return previousMark;
                }
                previousMark = ' ';
                consecutiveCount = 1;
            }
            return ' ';
        }
        public char HorizontalWin()
        {
            int consecutiveCount = 1;
            char previousMark = ' ';
            for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
            {
                for (int vertical = 0; vertical < _input.GetLength(1); vertical++)
                {
                    if (previousMark == ' ')
                    { previousMark = _input[horizontal, vertical]; }
                    else if (previousMark == _input[horizontal, vertical])
                    {
                        consecutiveCount++;
                    }
                    else
                    {
                        break;
                    };
                }

                if (consecutiveCount == xInARow)
                {
                    return previousMark;
                }
                previousMark = ' ';
                consecutiveCount = 1;
            }
            return ' ';
        }
        public char DiagonalL2RWin()
        {
            int consecutiveCount = 1;
            char previousMark = ' ';
            int vertical = 0;
            for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
            {
                if (previousMark == ' ')
                { previousMark = _input[horizontal, vertical]; }
                else if (previousMark == _input[horizontal, vertical])
                {
                    consecutiveCount++;
                }

                if (consecutiveCount == xInARow)
                {
                    return previousMark;
                }
                vertical++;
            }
            return ' ';
        }
        public char DiagonalR2LWin()
        {
            int consecutiveCount = 1;
            char previousMark = ' ';
            int vertical = _input.GetLength(1) - 1;
            for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
            {
                if (previousMark == ' ')
                { previousMark = _input[horizontal, vertical]; }
                else if (previousMark == _input[horizontal, vertical])
                {
                    consecutiveCount++;
                }

                if (consecutiveCount == xInARow)
                {
                    return previousMark;
                }
                vertical--;
            }
            return ' ';
        }

        public bool VerifyTheGameHasEnded()
        {
            if (WhosWin() != 0)
            {
                return true;
            }

            //find ' ' charactor
            for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
            {
                for (int vertical = 0; vertical < _input.GetLength(1); vertical++)
                {
                    if (_input[horizontal, vertical] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool VerifyTheGameState()
        {
            for (int horizontal = 0; horizontal < _input.GetLength(0); horizontal++)
            {
                for (int vertical = 0; vertical < _input.GetLength(1); vertical++)
                {
                    if (_input[horizontal, vertical] != 'x' && _input[horizontal, vertical] != 'o' && _input[horizontal, vertical] != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
