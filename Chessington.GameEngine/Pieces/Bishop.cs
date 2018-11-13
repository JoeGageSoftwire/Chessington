﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            
            var row = board.FindPiece(this).Row;
            var col = board.FindPiece(this).Col;
            var moves = DiagonalPiece.GetDiagonalMoves(board, Player, row, col);

            return moves;
        }
    }
}