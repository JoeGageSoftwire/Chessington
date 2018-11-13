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

            if (Square.IsOnBoard(Square.At(row + 2, col + 1))) moves.Add(Square.At(row + 2, col + 1));
            if (Square.IsOnBoard(Square.At(row + 2, col - 1))) moves.Add(Square.At(row + 2, col - 1));
            if (Square.IsOnBoard(Square.At(row - 2, col + 1))) moves.Add(Square.At(row - 2, col + 1));
            if (Square.IsOnBoard(Square.At(row - 2, col - 1))) moves.Add(Square.At(row - 2, col - 1));
            if (Square.IsOnBoard(Square.At(row + 1, col + 2))) moves.Add(Square.At(row + 1, col + 2));
            if (Square.IsOnBoard(Square.At(row + 1, col - 2))) moves.Add(Square.At(row + 1, col - 2));
            if (Square.IsOnBoard(Square.At(row - 1, col + 2))) moves.Add(Square.At(row - 1, col + 2));
            if (Square.IsOnBoard(Square.At(row - 1, col - 2))) moves.Add(Square.At(row - 1, col - 2));

            return moves;
        }
    }
}