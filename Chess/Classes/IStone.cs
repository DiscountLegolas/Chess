using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Classes
{
    internal interface IPiece
    {
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public Color PieceColor { get; set; }
        public void MovableTiles(Grid grid);
    }
}
