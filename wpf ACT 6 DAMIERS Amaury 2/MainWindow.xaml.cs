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

namespace wpf_ACT_6_DAMIERS_Amaury_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreerDamier();
        }

        private void CreerDamier()
        {
            int lignes = 10;
            int colonnes = 10;
            int tailleCase = 65;

            // Créer les lignes/colonnes
            for (int i = 0; i < lignes; i++)
                grdMain.RowDefinitions.Add(new RowDefinition { Height = new GridLength(tailleCase) });

            for (int j = 0; j < colonnes; j++)
                grdMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(tailleCase) });

            int numero = 1;

            // Générer les 100 cases
            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    Border caseCellule = new Border();
                    caseCellule.Width = tailleCase;
                    caseCellule.Height = tailleCase;

                    // Alternance des couleurs
                    if ((i + j) % 2 == 0)
                        caseCellule.Background = Brushes.White;
                    else
                        caseCellule.Background = Brushes.Black;

                    // Numéro rouge en gras
                    TextBlock txt = new TextBlock();
                    txt.Text = numero.ToString();
                    txt.FontWeight = FontWeights.Bold;
                    txt.Foreground = Brushes.Red;
                    txt.FontSize = 22;
                    txt.HorizontalAlignment = HorizontalAlignment.Center;
                    txt.VerticalAlignment = VerticalAlignment.Center;

                    caseCellule.Child = txt;

                    Grid.SetRow(caseCellule, i);
                    Grid.SetColumn(caseCellule, j);
                    grdMain.Children.Add(caseCellule);

                    numero++;
                }
            }
        }
    }

}

