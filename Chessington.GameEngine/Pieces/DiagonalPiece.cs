using System;
using System.Collections;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    internal class DiagonalPiece
    {
        public static IEnumerable<Square> GetDiagonalMoves(int row, int col)
        {
            var moves = new List<Square>();

            for (int i = 0; i <= 7; i++)
            {
                var diff = Math.Abs(row - i);
                if (diff == 0) continue;

                moves = Piece.AddSquare(moves, Square.At(i, col + diff));
                moves = Piece.AddSquare(moves, Square.At(i, col - diff));
            }
            return moves;
        }
    }
}