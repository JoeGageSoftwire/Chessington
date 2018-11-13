using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            var squareInFront = Player == Player.White ? Square.At(row - 1, col) : Square.At(row + 1, col);
            var squareTwoInFront = Player == Player.White ? Square.At(row - 2, col) : Square.At(row + 2, col);

            var blockedInFront = Square.IsOnBoard(squareInFront.Row, squareInFront.Col) && board.GetPiece(squareInFront) != null;
            var blockedTwoInFront = Square.IsOnBoard(squareTwoInFront.Row, squareTwoInFront.Col) && board.GetPiece(squareTwoInFront) != null;

            if (!HasMoved && !blockedInFront && !blockedTwoInFront) moves = AddSquare(moves, squareTwoInFront);
            if(!blockedInFront) moves = AddSquare(moves, squareInFront);

            return moves;
        }
    }
}