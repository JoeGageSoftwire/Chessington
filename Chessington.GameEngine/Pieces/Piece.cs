using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public bool VulnerableToEnPassant;

        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);

            VulnerableToEnPassant = false;
        }

        public static List<Square> AddSquareIfValid(List<Square> moves, Board board, Player player, Square square)
        {
            if (IsSquareValid(square, board, player)) moves.Add(square);
            return moves;
        }

        public static bool IsSquareValid(Square square, Board board, Player player)
        {
            return Square.IsOnBoard(square) && !Square.IsFriendlyPiece(board, player, square);
        }
    }
}