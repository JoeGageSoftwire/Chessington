using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            var movesLateral = LateralPiece.GetLateralMoves(board, Player, row, col);
            var movesDiagonal = DiagonalPiece.GetDiagonalMoves(board, Player, row, col);

            var moves = movesLateral.Concat(movesDiagonal);

            return moves;
        }
    }
}