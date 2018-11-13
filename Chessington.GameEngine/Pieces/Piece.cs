using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public bool HasMoved;

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            HasMoved = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public static List<Square> AddSquare(List<Square> moves, Board board, Player player, Square square)
        {
            if (!Square.IsOnBoard(square.Row, square.Col)) return moves;
            if (Square.IsFriendlyPiece(board, player, square)) return moves;
            moves.Add(square);
            return moves;
        }
    }
}