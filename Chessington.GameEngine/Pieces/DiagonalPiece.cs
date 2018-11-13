﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    internal class DiagonalPiece
    {
        public static IEnumerable<Square> GetDiagonalMoves(Board board, Player player, int row, int col)
        {
            var moves = new List<Square>();

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row + i, col + i) || board.GetPiece(Square.At(row + i, col + i)) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, Square.At(row + i, col + i));
                    break;
                }
                else
                {
                    moves.Add(Square.At(row + i, col + i));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row + i, col - i) || board.GetPiece(Square.At(row + i, col - i)) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, Square.At(row + i, col - i));
                    break;
                }
                else
                {
                    moves.Add(Square.At(row + i, col - i));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row - i, col + i) || board.GetPiece(Square.At(row - i, col + i)) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, Square.At(row - i, col + i));
                    break;
                }
                else
                {
                    moves.Add(Square.At(row - i, col + i));
                }
            }

            for (var i = 1; ; i++)
            {
                if (!Square.IsOnBoard(row - i, col - i) || board.GetPiece(Square.At(row - i, col - i)) != null)
                {
                    moves = Piece.AddSquare(moves, board, player, Square.At(row - i, col - i));
                    break;
                }
                else
                {
                    moves.Add(Square.At(row - i, col - i));
                }
            }

            return moves;
        }
    }
}