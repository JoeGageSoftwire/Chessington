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

            moves = AddSquare(moves, board, Player, Square.At(row + 2, col + 1));
            moves = AddSquare(moves, board, Player, Square.At(row + 2, col - 1));
            moves = AddSquare(moves, board, Player, Square.At(row - 2, col + 1));
            moves = AddSquare(moves, board, Player, Square.At(row - 2, col - 1));
            moves = AddSquare(moves, board, Player, Square.At(row + 1, col + 2));
            moves = AddSquare(moves, board, Player, Square.At(row + 1, col - 2));
            moves = AddSquare(moves, board, Player, Square.At(row - 1, col + 2));
            moves = AddSquare(moves, board, Player, Square.At(row - 1, col - 2));

            return moves;
        }
    }
}