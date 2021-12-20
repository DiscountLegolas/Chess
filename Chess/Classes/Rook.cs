using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Classes
{
    internal class Rook:IPiece
    {
        public Rook(int rowstartingposition, int columnstartingposition, Color color)
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
            bool üstdevam = true;
            bool altdevam = true;
            bool soldevam = true;
            bool sağdevam = true;
            bool last(Grid subgrid)
            {
                return (subgrid.Children.Count != 0 && ((IPiece)subgrid.Children.OfType<Image>().First().Tag).PieceColor != PieceColor);
            }
            chesstable.MakeAllTilesUnClickable();
            for (int i = RowPosition-1; i >= 1; i--)
            {
                var subgrid = chesstable.GetSubGrid(i, ColumnPosition);
                if (subgrid.CheckİfPlacable(PieceColor))
                {
                    if (üstdevam)
                    {
                        subgrid.Tag = true;
                        if (last(subgrid))
                        {
                            üstdevam = false;
                        }
                    }
                }
                else
                {
                    üstdevam = false;
                }
            }
            for (int i = RowPosition+1; i <= 8; i++)
            {
                var subgrid = chesstable.GetSubGrid(i, ColumnPosition);
                if (subgrid.CheckİfPlacable(PieceColor))
                {
                    if (altdevam)
                    {
                        subgrid.Tag = true;
                        if (last(subgrid))
                        {
                            altdevam = false;
                        }
                    }
                }
                else
                {
                    altdevam = false;
                }
            }
            for (int i = ColumnPosition-1; i >=1; i--)
            {
                var subgrid = chesstable.GetSubGrid(RowPosition, i);
                if (subgrid.CheckİfPlacable(PieceColor))
                {
                    if (soldevam)
                    {
                        subgrid.Tag = true;
                        if (last(subgrid))
                        {
                            soldevam = false;
                        }
                    }
                }
                else
                {
                    soldevam = false;
                }
            }
            for (int i = ColumnPosition+1; i <=8; i++)
            {
                var subgrid = chesstable.GetSubGrid(RowPosition, i);
                if (subgrid.CheckİfPlacable(PieceColor))
                {
                    if (sağdevam)
                    {
                        subgrid.Tag = true;
                        if (last(subgrid))
                        {
                            sağdevam = false;
                        }
                    }
                }
                else
                {
                    sağdevam = false;
                }
            }
        }
    }
}
