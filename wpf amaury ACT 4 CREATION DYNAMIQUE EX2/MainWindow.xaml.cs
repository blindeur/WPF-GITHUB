using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_amaury_ACT_4_CREATION_DYNAMIQUE_EX2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

        public partial class MainWindow : Window
        {
        // Change ces valeurs pour modifier la taille de la matrice
            //Grille[,] text = new Grille[4, 4];
            private readonly int rows = 4;
            private readonly int cols = 4;

        public MainWindow()
            {
                InitializeComponent();
                prepaGrille();
            }

            private void prepaGrille()
            {
            // Clear au cas où
            grdMain.RowDefinitions.Clear();
            grdMain.ColumnDefinitions.Clear();
            grdMain.Children.Clear();

                // Créer lignes et colonnes
                for (int r = 0; r < rows; r++)
                {
                    var rd = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                    grdMain.RowDefinitions.Add(rd);
                }

                for (int c = 0; c < cols; c++)
                {
                    var cd = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                    grdMain.ColumnDefinitions.Add(cd);
                }

                // Remplir la grille avec des TextBlocks
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        var tb = new TextBlock
                        {
                            Text = "?",
                            FontSize = 48,
                            FontWeight = FontWeights.SemiBold,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                            Foreground = Brushes.White,
                            Cursor = Cursors.Hand
                        };

                        
                        var cellBorder = new Border
                        {
                            BorderThickness = new Thickness(0),
                            Child = tb,
                            Background = Brushes.Transparent
                        };

                        //  événement de clique
                        tb.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;

                        
                        tb.Tag = new { Row = r, Col = c };

                        Grid.SetRow(cellBorder, r);
                        Grid.SetColumn(cellBorder, c);
                        grdMain.Children.Add(cellBorder);
                    }
                }
            }

            private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (sender is TextBlock tb)
                {
                    // Remplace le "?" par "X" 
                    if (tb.Text == "?")
                    {
                        tb.Text = "X";
                        // pour pas faire d'autre click
                        tb.MouseLeftButtonDown -= TextBlock_MouseLeftButtonDown;
                    }
                }
            }
        }
   
}