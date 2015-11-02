using System.Text;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace tictactoe_csharp
{
    public class Cell
    {
        public int Position;
        public char Value;
        public char EmptySpace = '-';
        public Cell(char value) {
            Value = value;
        }
        public bool HasPlayer() {
            return Value != EmptySpace;
        }
    }

    public class Board
    {
        public char EmptySpace = '-';
        public List<Cell> cells;

        public Board(string s)
        {
            cells = s.ToCharArray().Select(x => new Cell(x)).ToList();
            for (int i = 0; i < cells.Count(); i++) cells[i].Position = i;
        }

        public bool HasWinnerInRow(int rowNo)
        {
            return cells[rowNo].HasPlayer() && GetPlayer(rowNo) == GetPlayer(rowNo + 1) && GetPlayer(rowNo + 1) == GetPlayer(rowNo + 2);
        }

        public int FindDefaultPos(char player)
        {
            foreach(var cell in cells)
                if (!cell.HasPlayer())
                    return cell.Position;
            return -1;
        }

        public int FindWinnerPos(char player)
        {
            foreach(var cell in cells)
                if (!cell.HasPlayer())
                    if (NextMove(cell, player).Winner() == player)
                        return cell.Position;
            return -1;
        }

        public char GetPlayer(int pos)
        {
            return cells[pos].Value;
        }

        public Board Clone()
        {
            var cellString = string.Empty;
            foreach(var cell in cells) cellString += cell.Value;
            return new Board(cellString);
        }

        public Board NextMove(Cell cell, char player)
        {
            var newBoard = Clone();
            newBoard.cells[cell.Position] = new Cell(player);
            return newBoard;
        }

        public char Winner()
        {
            foreach (var position in new int[] { 0, 3, 6 })
            {
                if (HasWinnerInRow(position))
                    return GetPlayer(position);
            }

            return EmptySpace;
        }
    }

    public class Game
    {
        private Board boardObj;

        public Game(string s)
        {
            boardObj = new Board(s);
        }

        public int Move(char player)
        {
            int winnerPos = boardObj.FindWinnerPos(player);

            if (winnerPos != -1)
                return winnerPos;

            return boardObj.FindDefaultPos(player);
        }

        public char Winner() {

            return boardObj.Winner();
        }

    }
}
