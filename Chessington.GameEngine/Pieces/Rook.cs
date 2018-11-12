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
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            for (var i = 0; i <= 7; i++)
            {
                if (i != col)
                {
                    moves.Add(Square.At(row, i));
                }

                if (i != row)
                {
                    moves.Add(Square.At(i, col));
                }
            }

            return moves;
        }
    }
}