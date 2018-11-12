using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square> {Square.At(2, 0), Square.At(6, 0)};
            return moves;
        }
    }
}