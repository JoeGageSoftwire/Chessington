using System;
using System.Collections;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    internal class LateralPiece
    {
        public static IEnumerable<Square> GetLateralMoves(Board board, Player player, int row, int col)
        {
            var moves = new List<Square>();

            for (var i = 1; ; i++)
            {
                var trySquare = Square.At(row, col + i);

                if (!Square.IsOnBoard(trySquare) || board.GetPiece(trySquare) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, trySquare);
                    break;
                }
                else
                {
                    moves.Add(trySquare);
                }
            }
            
            for (var i = 1; ; i++)
            {
                var trySquare = Square.At(row, col - i);

                if (!Square.IsOnBoard(trySquare) || board.GetPiece(trySquare) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, trySquare);
                    break;
                }
                else
                {
                    moves.Add(trySquare);
                }
            }

            for (var i = 1; ; i++)
            {
                var trySquare = Square.At(row + i, col);

                if (!Square.IsOnBoard(trySquare) || board.GetPiece(trySquare) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, trySquare);
                    break;
                }
                else
                {
                    moves.Add(trySquare);
                }
            }

            for (var i = 1; ; i++)
            {
                var trySquare = Square.At(row - i, col);

                if (!Square.IsOnBoard(trySquare) || board.GetPiece(trySquare) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, trySquare);
                    break;
                }
                else
                {
                    moves.Add(trySquare);
                }
            }

            return moves;
        }
    }
}