﻿namespace Chessington.GameEngine
{
    public struct Square
    {
        public readonly int Row;
        public readonly int Col;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Square At(int row, int col)
        {
            return new Square(row, col);
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }

        public static bool IsOnBoard(Square square)
        {
            return square.Row >= 0 && square.Row <= 7 && square.Col >= 0 && square.Col <= 7;
        }

        public static bool IsFriendlyPiece(Board board, Player player, Square square)
        {
            if (IsOnBoard(square) && board.GetPiece(square) != null)
            {
                return board.GetPiece(square).Player == player;
            }
            else
            {
                return false;
            }
        }

        public static bool IsOpposingPiece(Board board, Player player, Square square)
        {
            if (IsOnBoard(square) && board.GetPiece(square) != null)
            {
                return board.GetPiece(square).Player != player;
            }
            else
            {
                return false;
            }
        }
    }
}