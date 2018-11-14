using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            moves = AddSquareIfValid(moves, board, Player, Square.At(row + 2, col + 1));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row + 2, col - 1));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row - 2, col + 1));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row - 2, col - 1));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row + 1, col + 2));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row + 1, col - 2));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row - 1, col + 2));
            moves = AddSquareIfValid(moves, board, Player, Square.At(row - 1, col - 2));

            return moves;
        }
    }
}