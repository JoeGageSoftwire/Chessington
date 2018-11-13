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
                if (!Square.IsOnBoard(row, col + i) || board.GetPiece(Square.At(row, col + i)) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, Square.At(row, col + i));
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
                    moves = Piece.AddSquare(moves, board, player, Square.At(row, col + i));
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
                    moves = Piece.AddSquare(moves, board, player, Square.At(row, col + i));
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
                    moves = Piece.AddSquare(moves, board, player, Square.At(row, col + i));
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