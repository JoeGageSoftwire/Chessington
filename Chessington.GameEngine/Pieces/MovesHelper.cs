using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    internal class MovesHelper
    {
        private Board board;
        private Player player;
        private Square square;

        public MovesHelper(Board board, Player player, Square square)
        {
            this.board = board;
            this.player = player;
            this.square = square;
        }

        public IEnumerable<Square> GetLateralMoves()
        {
            return GetMovesRight().Concat(GetMovesLeft()).Concat(GetMovesUp()).Concat(GetMovesDown());
        }

        public IEnumerable<Square> GetMovesRight()
        {
            return GetMovesInDirection(0, 1);
        }

        public IEnumerable<Square> GetMovesLeft()
        {
            return GetMovesInDirection(0, -1);
        }

        public IEnumerable<Square> GetMovesUp()
        {
            return GetMovesInDirection(-1, 0);
        }

        public IEnumerable<Square> GetMovesDown()
        {
            return GetMovesInDirection(1, 0);
        }

        public IEnumerable<Square> GetDiagonalMoves()
        {
            return GetMovesUpRight().Concat(GetMovesUpLeft()).Concat(GetMovesDownRight()).Concat(GetMovesDownLeft());
        }

        public IEnumerable<Square> GetMovesUpRight()
        {
            return GetMovesInDirection(-1, 1);
        }

        public IEnumerable<Square> GetMovesUpLeft()
        {
            return GetMovesInDirection(-1, -1);
        }

        public IEnumerable<Square> GetMovesDownRight()
        {
            return GetMovesInDirection(1, 1);
        }

        public IEnumerable<Square> GetMovesDownLeft()
        {
            return GetMovesInDirection(1, -1);
        }

        public IEnumerable<Square> GetMovesInDirection(int rowDirection, int colDirection)
        {
            var moves = new List<Square>();

            for (var i = 1; ; i++)
            {
                var trySquare = Square.At(square.Row + i*rowDirection, square.Col + i*colDirection);

                if (!Square.IsOnBoard(trySquare) || board.GetPiece(trySquare) != null)
                {
                    moves = Piece.AddSquareIfValid(moves, board, player, trySquare);
                    return moves;
                }

                moves.Add(trySquare);
            }
        }
    }
}