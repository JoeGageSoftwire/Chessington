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
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            for (int i = 0; i <= 7; i++)
            {
                var diff = Math.Abs(row - i);
                if (diff != 0)
                {
                    if (col + diff <= 7)
                    {
                        moves.Add(Square.At(i, col + diff));
                    }

                    if (col - diff >= 0)
                    {
                        moves.Add(Square.At(i, col - diff));
                    }
                }
            }

            return moves;
        }
    }
}