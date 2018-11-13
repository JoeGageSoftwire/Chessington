using System;
using System.Collections;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    internal class LateralPiece
    {
        public static IEnumerable<Square> GetLateralMoves(Board board, int row, int col)
        {
            var moves = new List<Square>();

            /*for (var i = 0; i <= 7; i++)
            {
                if (i != col)
                {
                    moves.Add(Square.At(row, i));
                }

                if (i != row)
                {
                    moves.Add(Square.At(i, col));
                }
            }*/

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row, col + i) || board.GetPiece(Square.At(row, col + i)) != null)
                {
                    break;
                }
                else
                {
                    moves.Add(Square.At(row, col + i));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row, col - i) || board.GetPiece(Square.At(row, col - i)) != null)
                {
                    break;
                }
                else
                {
                    moves.Add(Square.At(row, col - i));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row + i, col) || board.GetPiece(Square.At(row + i, col)) != null)
                {
                    break;
                }
                else
                {
                    moves.Add(Square.At(row + i, col));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row - i, col) || board.GetPiece(Square.At(row - i, col)) != null)
                {
                    break;
                }
                else
                {
                    moves.Add(Square.At(row - i, col));
                }
            }

            return moves;
        }
    }
}