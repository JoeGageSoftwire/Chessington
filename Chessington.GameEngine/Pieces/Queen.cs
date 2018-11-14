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
            var movesHelper = new MovesHelper(board, Player, board.FindPiece(this));
            var movesLateral = movesHelper.GetLateralMoves();
            var movesDiagonal = movesHelper.GetDiagonalMoves();
            var moves = movesLateral.Concat(movesDiagonal);

            return moves;
        }
    }
}