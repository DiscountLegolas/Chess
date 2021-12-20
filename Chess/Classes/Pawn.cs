using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess.Classes
{
    internal class Pawn:IPiece
    {
        public Pawn(int rowstartingposition,int columnstartingposition, Color color)
        {
            RowPosition = rowstartingposition;
            ColumnPosition = columnstartingposition;
            PieceColor = color;
        }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public Color PieceColor { get; set; }
        public void MovableTiles(Grid chesstable)
        {
            int a = 0;
            if (PieceColor==Color.White)
            {
                a = -1;
            }
            else if(PieceColor == Color.Black)
            {
                a = +1;
            }
            chesstable.MakeAllTilesUnClickable();
            foreach (var grid in chesstable.Children.OfType<Grid>().Where(x=>!(x.Children.OfType<Image>().Any())||((IPiece)x.Children.OfType<Image>().First().Tag).PieceColor!=PieceColor))
            {
                if (Grid.GetRow(grid)==RowPosition+a&&Grid.GetColumn(grid)==ColumnPosition)
                {
                    grid.Tag = true;
                }
            }
        }
    }
}
