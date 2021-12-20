using Chess.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    public static class Extensionmethods
    {
        public static Grid GetSubGrid(this Grid chesstable, int row, int column)
        {
            return chesstable.Children.OfType<Grid>().Single(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == column);
        }
        public static bool CheckİfPlacable(this Grid grid,Color piececolor)
        {
            return (grid.Children.Count == 0 || ((IPiece)grid.Children.OfType<Image>().First().Tag).PieceColor != piececolor);
        }
        public static void MakeAllTilesUnClickable(this Grid chesstable)
        {
            foreach (var grid in chesstable.Children.OfType<Grid>())
            {
                grid.Tag = false;
            }
        }
    }
}
