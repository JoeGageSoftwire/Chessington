using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;

            if (Square.IsOnBoard(Square.At(row, col + 1))) moves.Add(Square.At(row, col + 1));
            if (Square.IsOnBoard(Square.At(row + 1, col + 1))) moves.Add(Square.At(row + 1, col + 1));
            if (Square.IsOnBoard(Square.At(row + 1, col))) moves.Add(Square.At(row + 1, col));
            if (Square.IsOnBoard(Square.At(row + 1, col - 1))) moves.Add(Square.At(row + 1, col - 1));
            if (Square.IsOnBoard(Square.At(row, col - 1))) moves.Add(Square.At(row, col - 1));
            if (Square.IsOnBoard(Square.At(row - 1, col - 1))) moves.Add(Square.At(row - 1, col - 1));
            if (Square.IsOnBoard(Square.At(row - 1, col))) moves.Add(Square.At(row - 1, col));
            if (Square.IsOnBoard(Square.At(row - 1, col + 1))) moves.Add(Square.At(row - 1, col + 1));

            return moves;
        }
    }
}