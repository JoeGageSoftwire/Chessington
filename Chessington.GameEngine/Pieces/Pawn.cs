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

            var blockedInFront = Square.IsOnBoard(squareInFront) && board.GetPiece(squareInFront) != null;
            var blockedTwoInFront = Square.IsOnBoard(squareTwoInFront) && board.GetPiece(squareTwoInFront) != null;

            if (!HasMoved && !blockedInFront && !blockedTwoInFront) moves = AddSquare(moves, board, Player, squareTwoInFront);
            if (!blockedInFront) moves = AddSquare(moves, board, Player, squareInFront);

            var squareInFrontAndLeft = Player == Player.White ? Square.At(row - 1, col - 1) : Square.At(row + 1, col + 1);
            var squareInFrontAndRight = Player == Player.White ? Square.At(row - 1, col + 1) : Square.At(row + 1, col - 1);

            if (Square.IsOpposingPiece(board, Player, squareInFrontAndLeft)) moves = AddSquare(moves, board, Player, squareInFrontAndLeft);
            if (Square.IsOpposingPiece(board, Player, squareInFrontAndRight)) moves = AddSquare(moves, board, Player, squareInFrontAndRight);

            return moves;
        }
    }
}