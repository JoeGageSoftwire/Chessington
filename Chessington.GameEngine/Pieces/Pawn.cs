using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;
            
            if (!HasMoved)
            {
                if (Player == Player.White)
                {
                    moves.Add(Square.At(row - 1, col));
                    moves.Add(Square.At(row - 2, col));
                }
                else
                {
                    moves.Add(Square.At(row + 1, col));
                    moves.Add(Square.At(row + 2, col));
                }
            }
            else
            {
                if (Player == Player.White)
                {
                    if (row != 0)
                    {
                        moves.Add(Square.At(row - 1, col));
                    }
                }
                else
                {
                    if (row != 8)
                    {
                        moves.Add(Square.At(row + 1, col));
                    }
                }
            }

            return moves;
        }
    }
}