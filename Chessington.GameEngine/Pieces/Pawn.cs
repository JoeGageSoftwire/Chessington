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
            var moves = new List<Square>();
            { };
            
            if (HasMoved)
            {
                if (Player == Player.White)
                {
                    moves.Add(Square.At(5, 2));
                }
                else
                {
                    moves.Add(Square.At(7, 2));
                }
            }
            else
            {
                moves.Add(Square.At(2, 0));
                moves.Add(Square.At(6, 0));
                moves.Add(Square.At(3, 3));
                moves.Add(Square.At(5, 5));
            }

            return moves;
        }
    }
}