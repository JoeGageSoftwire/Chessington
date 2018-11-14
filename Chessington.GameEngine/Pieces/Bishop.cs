using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesHelper = new MovesHelper(board, Player, board.FindPiece(this));
            var moves = movesHelper.GetDiagonalMoves();

            return moves;
        }
    }
}