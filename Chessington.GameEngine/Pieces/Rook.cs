using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;
            var moves = LateralPiece.GetLateralMoves(row, col);

            return moves;
        }
    }
}