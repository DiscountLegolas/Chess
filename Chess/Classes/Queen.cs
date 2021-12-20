using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.Classes
{
    internal class Queen : IPiece
    {
        public Queen(int rowstartingposition, int columnstartingposition, Color color)
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
            bool soldevam = true;
            bool sağdevam = true;
            bool altdevam = true;
            bool üstdevam = true;

            foreach (var grid in chesstable.Children.OfType<Grid>())
            {
                grid.Tag = false;
            }
            for (int i = RowPosition-1; i >= 1; i--)
            {
                var subgri = chesstable.GetSubGrid(i,ColumnPosition);
                if (subgri.CheckİfPlacable(PieceColor))
                {
                    if (üstdevam)
                    {
                        subgri.Tag = true;
                        if (last(subgri))
                        {
                            üstdevam = false;
                        }
                    }

                }
                else
                {
                    üstdevam = false;
                }
                for (int j = ColumnPosition - 1; j >= 1; j--)
                {
                    if (ColumnPosition - j == RowPosition - i)
                    {
                        var subgrid = chesstable.GetSubGrid(i,j);
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
                    if(i+1==RowPosition)
                    {
                        var subgrid = chesstable.GetSubGrid(i+1,j);
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
                }
                for (int j = ColumnPosition + 1; j <= 8; j++)
                {
                    if (j - ColumnPosition == RowPosition - i)
                    {
                        var subgrid =chesstable.GetSubGrid(i,j);
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
                    if (i+1 == RowPosition)
                    {
                        var subgrid = chesstable.GetSubGrid(i + 1, j);
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
            for (int i = RowPosition + 1; i <= 8; i++)
            {
                var subgri = chesstable.GetSubGrid(i,ColumnPosition);
                if (subgri.CheckİfPlacable(PieceColor))
                {
                    if (altdevam)
                    {
                        subgri.Tag = true;
                        if (last(subgri))
                        {
                            altdevam = false;
                        }
                    }

                }
                else
                {
                    altdevam = false;
                }
                for (int j = ColumnPosition - 1; j >= 1; j--)
                {
                    if (ColumnPosition - j == i - RowPosition)
                    {
                        var subgrid = chesstable.GetSubGrid(i,j);
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
