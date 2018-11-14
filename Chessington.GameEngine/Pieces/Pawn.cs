using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved;

        public Pawn(Player player) 
            : base(player)
        {
           
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            hasMoved = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);

            VulnerableToEnPassant = newSquare == Square.At(currentSquare.Row + 2, currentSquare.Col) || newSquare == Square.At(currentSquare.Row - 2, currentSquare.Col);
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            var squareInFront = Player == Player.White ? Square.At(row - 1, col) : Square.At(row + 1, col);
            var squareTwoInFront = Player == Player.White ? Square.At(row - 2, col) : Square.At(row + 2, col);

            var blockedInFront = Square.IsOnBoard(squareInFront) && board.GetPiece(squareInFront) != null;
            var blockedTwoInFront = Square.IsOnBoard(squareTwoInFront) && board.GetPiece(squareTwoInFront) != null;

            if (!hasMoved && !blockedInFront && !blockedTwoInFront) moves = AddSquareIfValid(moves, board, Player, squareTwoInFront);
            if (!blockedInFront) moves = AddSquareIfValid(moves, board, Player, squareInFront);

            var squareInFrontAndLeft = Player == Player.White ? Square.At(row - 1, col - 1) : Square.At(row + 1, col + 1);
            var squareInFrontAndRight = Player == Player.White ? Square.At(row - 1, col + 1) : Square.At(row + 1, col - 1);

            if (Square.IsOpposingPiece(board, Player, squareInFrontAndLeft)) moves = AddSquareIfValid(moves, board, Player, squareInFrontAndLeft);
            if (Square.IsOpposingPiece(board, Player, squareInFrontAndRight)) moves = AddSquareIfValid(moves, board, Player, squareInFrontAndRight);

            var squareOnLeft = Player == Player.White ? Square.At(row, col - 1) : Square.At(row, col + 1);
            var squareOnRight = Player == Player.White ? Square.At(row, col + 1) : Square.At(row, col - 1);

            if (Square.IsOpposingPiece(board, Player, squareOnLeft) && board.GetPiece(squareOnLeft).VulnerableToEnPassant)
            {
                moves = AddSquareIfValid(moves, board, Player, squareInFrontAndLeft);
            }
            if (Square.IsOpposingPiece(board, Player, squareOnRight) && board.GetPiece(squareOnRight).VulnerableToEnPassant)
            {
                moves = AddSquareIfValid(moves, board, Player, squareInFrontAndRight);
            }

            return moves;
        }
    }
}