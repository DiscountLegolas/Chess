using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Classes
{
    internal class Bishop : IPiece
    {
        public Bishop(int rowstartingposition, int columnstartingposition, Color color)
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
            bool last(Grid subgrid)
            {
                return (subgrid.Children.Count != 0 && ((IPiece)subgrid.Children.OfType<Image>().First().Tag).PieceColor != PieceColor);
            }
            bool üstsağdevam = true;
            bool üstsoldevam = true;
            bool altsağdevam = true;
            bool altsoldevam = true;

            chesstable.MakeAllTilesUnClickable();
            for (int i = RowPosition; i >= 1; i--)
            {
                for (int j = ColumnPosition - 1; j >= 1; j--)
                {
                    if (ColumnPosition - j== RowPosition - i)
                    {
                        var subgrid = chesstable.GetSubGrid(i, j);
                        if (subgrid.CheckİfPlacable(PieceColor))
                        {
                            if (üstsoldevam)
                            {
                                subgrid.Tag = true;
                                if (last(subgrid))
                                {
                                    üstsoldevam = false;
                                }
                            }

                        }
                        else
                        {
                            üstsoldevam = false;
                        }
                    }
                }
                for (int j = ColumnPosition + 1; j <= 8; j++)
                {
                    if (j - ColumnPosition == RowPosition - i)
                    {
                        var subgrid = chesstable.GetSubGrid(i, j);
                        if (subgrid.CheckİfPlacable(PieceColor))
                        {
                            if (üstsağdevam)
                            {
                                subgrid.Tag = true;
                                if (last(subgrid))
                                {
                                    üstsağdevam = false;
                                }
                            }

                        }
                        else
                        {
                            üstsağdevam = false;
                        }
                    }
                }
            }
            for (int i = RowPosition + 1; i <= 8; i++)
            {
                for (int j = ColumnPosition - 1; j >= 1; j--)
                {
                    if (ColumnPosition - j == i - RowPosition)
                    {
                        var subgrid =chesstable.GetSubGrid(i,j);
                        if (subgrid.CheckİfPlacable(PieceColor))
                        {
                            if (altsoldevam)
                            {
                                subgrid.Tag = true;
                                if (last(subgrid))
                                {
                                    altsoldevam = false;
                                }
                            }

                        }
                        else
                        {
                            altsoldevam = false;
                        }
                    }
                }
                for (int j = ColumnPosition + 1; j <= 8; j++)
                {
                    if (j - ColumnPosition == i - RowPosition)
                    {
                        var subgrid = chesstable.GetSubGrid(i,j);
                        if (subgrid.CheckİfPlacable(PieceColor))
                        {
                            if (altsağdevam)
                            {
                                subgrid.Tag = true;
                                if (last(subgrid))
                                {
                                    altsağdevam = false;
                                }
                            }

                        }
                        else
                        {
                            altsağdevam = false;
                        }
                    }
                }
            }
        }
    }
}
