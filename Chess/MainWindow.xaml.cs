using Chess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Drawing.Color CurrentColorMoving;
        private Image ClickedPiece;
        private List<IPiece> pieces;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 9; i++)
            {
                ChessTable.RowDefinitions.Add(new RowDefinition());
                ChessTable.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    Grid subgrid = new Grid();
                    if ((i+j)%2==0)
                    {
                        subgrid.Background = Brushes.DarkGreen;
                    }
                    else
                    {
                        subgrid.Background = Brushes.Gray;
                    }
                    ChessTable.Children.Add(subgrid);
                    Grid.SetColumn(subgrid, i);
                    Grid.SetRow(subgrid, j);
                }
            }
            pieces = new List<IPiece>();
            //Getting Images
            BitmapImage whitebishopımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\WhiteBishop.png"));
            BitmapImage blackbishopimagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackBishop.png"));
            BitmapImage blackKnightımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackKnight.png"));
            BitmapImage whiteknightımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\WhiteKnight.png"));
            BitmapImage blackRookımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackRook.png"));
            BitmapImage whiteRookımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\WhiteRook.png"));
            BitmapImage blackqueenımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackQueen.png"));
            BitmapImage whitequeenımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\WhiteQueen.png"));
            BitmapImage blackkingımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackKing.png"));
            BitmapImage whitekingımagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\WhiteKing.png"));
            BitmapImage blackpawnimagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\BlackPawn.png"));
            BitmapImage whitePawnImagesrc = new BitmapImage(new Uri(@"C:\Users\VESTEL\source\repos\Chess\Chess\Images\White Pawn.png"));
            for (int i = 1; i <= 8; i++)
            {
                Pawn blackpawn = new Pawn(2, i, System.Drawing.Color.Black);
                AddPieceToTable(blackpawnimagesrc, blackpawn, 2, i);
                Pawn whitepawn = new Pawn(7, i, System.Drawing.Color.White);
                AddPieceToTable(whitePawnImagesrc, whitepawn, 7, i);
            }
            //Adding pieces to table
            Bishop firstblackbishop = new Bishop(1, 3, System.Drawing.Color.Black);
            Bishop secondblackbishop = new Bishop(1, 6, System.Drawing.Color.Black);
            AddPieceToTable(blackbishopimagesrc, firstblackbishop, 1, 3);
            AddPieceToTable(blackbishopimagesrc, secondblackbishop, 1, 6);
            Bishop firstwhitebishop = new Bishop(8, 3, System.Drawing.Color.White);
            Bishop secondwhitebishop = new Bishop(8, 6, System.Drawing.Color.White);
            AddPieceToTable(whitebishopımagesrc, firstwhitebishop, 8, 3);
            AddPieceToTable(whitebishopımagesrc, secondwhitebishop, 8, 6);
            Knight firstblackknight = new Knight(1, 2, System.Drawing.Color.Black);
            Knight secondblackknight = new Knight(1, 7, System.Drawing.Color.Black);
            AddPieceToTable(blackKnightımagesrc, firstblackknight, 1, 2);
            AddPieceToTable(blackKnightımagesrc, secondblackknight, 1, 7);
            Knight firstwhiteknight = new Knight(8, 2, System.Drawing.Color.White);
            Knight secondwhiteknight = new Knight(8, 7, System.Drawing.Color.White);
            AddPieceToTable(whiteknightımagesrc, firstwhiteknight, 8, 2);
            AddPieceToTable(whiteknightımagesrc, secondwhiteknight, 8, 7);
            Queen whitequeen = new Queen(8, 4, System.Drawing.Color.White);
            AddPieceToTable(whitequeenımagesrc, whitequeen, 8, 4);
            Queen blackqueen = new Queen(1, 4, System.Drawing.Color.Black);
            AddPieceToTable(blackqueenımagesrc, blackqueen, 1, 4);
            Rook firstblackrook = new Rook(1, 1, System.Drawing.Color.Black);
            Rook secondblackrook = new Rook(1, 8, System.Drawing.Color.Black);
            AddPieceToTable(blackRookımagesrc, firstblackrook, 1, 1);
            AddPieceToTable(blackRookımagesrc, secondblackrook, 1, 8);
            Rook firstwhiterook = new Rook(8, 1, System.Drawing.Color.White);
            Rook secondwhiterook = new Rook(8, 8, System.Drawing.Color.White);
            AddPieceToTable(whiteRookımagesrc, firstwhiterook, 8, 1);
            AddPieceToTable(whiteRookımagesrc, secondwhiterook, 8, 8);
            King blackking = new King(1, 5, System.Drawing.Color.Black);
            AddPieceToTable(blackkingımagesrc, blackking, 1, 5);
            King whiteking = new King(8, 5, System.Drawing.Color.White);
            AddPieceToTable(whitekingımagesrc, whiteking, 8, 5);
        }

        private void ClickPiece(object sender, MouseButtonEventArgs e)
        {
            ReColorTable();
            ResetEvents();
            Image sendingimage = sender as Image;
            ClickedPiece = sendingimage;
            IPiece piece = sendingimage.Tag as IPiece;
            piece.MovableTiles(ChessTable);
            foreach (var item in ChessTable.Children.OfType<Grid>().Where(X =>(bool)X.Tag == true))
            {
                item.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(MovePiece);
                item.Background = Brushes.GreenYellow;
            }
        }
        private void ResetEvents()
        {
            foreach (var item in ChessTable.Children.OfType<Grid>())
            {
                item.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(MovePiece);
            }
        }
        private void ReColorTable()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    Grid subgrid = ChessTable.GetSubGrid(i,j);
                    if ((i + j) % 2 == 0)
                    {
                        subgrid.Background = Brushes.DarkGreen;
                    }
                    else { subgrid.Background = Brushes.Gray; }
                }
            }
        }
        private void MovePiece(object sender,MouseButtonEventArgs e)
        {
            ReColorTable();
            Grid gridtoplacepiece = sender as Grid;
            IPiece piece = ClickedPiece.Tag as IPiece;
            Grid currentcridwithpiece = ChessTable.GetSubGrid(piece.RowPosition,piece.ColumnPosition);
            piece.RowPosition = Grid.GetRow(gridtoplacepiece);
            piece.ColumnPosition = Grid.GetColumn(gridtoplacepiece);
            currentcridwithpiece.Children.Remove(ClickedPiece);
            //Checking if grid has piece with opposite color if so removing it from table
            if (gridtoplacepiece.Children.OfType<Image>().Any())
            {
                IPiece piecetoremove=((IPiece)gridtoplacepiece.Children.OfType<Image>().First().Tag);
                if (piecetoremove.GetType().Name == "King")
                {
                    foreach (var gridwithimage in ChessTable.Children.OfType<Grid>().Where(x=>x.Children.Count!=0))
                    {
                        gridwithimage.Children.OfType<Image>().First().PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(ClickPiece);
                    }
                    TextBox textBox = new TextBox() { Text = piece.PieceColor.Name + " Side Won" };
                    ChessTable.Children.Remove(ChessTable.GetSubGrid(4, 4));
                    ChessTable.Children.Remove(ChessTable.GetSubGrid(4, 5));
                    ChessTable.Children.Remove(ChessTable.GetSubGrid(5, 4));
                    ChessTable.Children.Remove(ChessTable.GetSubGrid(5, 5));
                    ChessTable.Children.Add(textBox);
                    Grid.SetColumn(textBox, 4);
                    Grid.SetRow(textBox, 4);
                    Grid.SetColumnSpan(textBox, 2);
                    Grid.SetRowSpan(textBox, 2);
                }
                gridtoplacepiece.Children.Remove(gridtoplacepiece.Children.OfType<Image>().First());
            }
            gridtoplacepiece.Children.Add(ClickedPiece);
            ResetEvents();
        }
        private void AddPieceToTable(BitmapImage imagesrc,IPiece piece,int rowtoput,int columntoput)
        {
            Image ımage = new Image()
            {
                Source = imagesrc,
            };
            pieces.Add(piece);
            ımage.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ClickPiece);
            ımage.Tag = piece;
            var grid = ChessTable.GetSubGrid(rowtoput, columntoput);
            grid.Children.Add(ımage);
        }
    }
}
