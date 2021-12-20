using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Classes
{
    internal class Knight : IPiece
    {
        public Knight(int rowstartingposition, int columnstartingposition, Color color)
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
            chesstable.MakeAllTilesUnClickable();
            void SetTag(int row,int column)
            {
                if (chesstable.Children.OfType<Grid>().Count(x=>Grid.GetRow(x)==row&& Grid.GetColumn(x) ==column)!=0)
                {
                    var gr = chesstable.GetSubGrid(row,column);
                    if (gr.CheckİfPlacable(PieceColor))
                    {
                        gr.Tag = true;
                    }
                }
            }
            SetTag(RowPosition+1,ColumnPosition+2);
            SetTag(RowPosition + 2, ColumnPosition + 1);
            SetTag(RowPosition + 1, ColumnPosition -2);
            SetTag(RowPosition + 2, ColumnPosition - 1);
            SetTag(RowPosition -1, ColumnPosition + 2);
            SetTag(RowPosition - 2, ColumnPosition - 1);
            SetTag(RowPosition -1, ColumnPosition -2);
            SetTag(RowPosition - 2, ColumnPosition + 1);
        }
    }
}
