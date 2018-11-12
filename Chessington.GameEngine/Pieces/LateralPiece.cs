using System;
using System.Collections;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    internal class LateralPiece
    {
        public static IEnumerable<Square> GetLateralMoves(int row, int col)
        {
            var moves = new List<Square>();

            for (var i = 0; i <= 7; i++)
            {
                if (i != col)
                {
                    moves.Add(Square.At(row, i));
                }

                if (i != row)
                {
                    moves.Add(Square.At(i, col));
                }
            }

            return moves;
        }
    }
}