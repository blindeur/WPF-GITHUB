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
        Button[,] btnB = new Button[8, 8];

        public MainWindow()
        {
            InitializeComponent();
            prepaGrille();
        }

        public void prepaGrille()
        {
            // Colonnes
            for (int i = 0; i < 8; i++)
                grdMain.ColumnDefinitions.Add(new ColumnDefinition());

            // Lignes
            for (int j = 0; j < 8; j++)
                grdMain.RowDefinitions.Add(new RowDefinition());

            // Création du damier
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    btnB[i, k] = new Button();
                    btnB[i, k].Height = 67;
                    btnB[i, k].Width = 67;

                    Grid.SetColumn(btnB[i, k], k);
                    Grid.SetRow(btnB[i, k], i);
                    grdMain.Children.Add(btnB[i, k]);

                    // Alternance des couleurs
                    if ((i + k) % 2 == 0)
                        btnB[i, k].Background = Brushes.White;
                    else
                        btnB[i, k].Background = Brushes.Black;
                }
            }

            // --- Placement des pièces ---
            placePieces();
        }

        private void placePieces()
        {
            // Rangée des pions
            for (int k = 0; k < 8; k++)
            {
                
                AddImageToButton(btnB[1, k], "/Images/pion.png"); // camp 1
                AddImageToButton(btnB[6, k], "/Images/pion.png"); // camp 2
            }

            // Rangée des pièces majeures
            string[] pieces = {
                "tour.png", "cavalier.png", "fou.png", "reine.png",
                "roi.png", "fou.png", "cavalier.png", "tour.png"
            };

            for (int k = 0; k < 8; k++)
            {
                AddImageToButton(btnB[0, k], "/Images/" + pieces[k]); // camp 1
                AddImageToButton(btnB[7, k], "/Images/" + pieces[k]); // camp 2
            }
        }

        //Ajouter une image dans un bouton
        //je n'y arrive pas même avec l'aide de ChatGPT j'ai beau faire des recherches je n'y arrive pas
        // je ne comprends pas pourquoi ça ne fonctionne pas
        // et pourtant j'ai teter des trucs de fou mais rien n'y fait
        public void AddImageToButton(Button btn, string imagePath)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            img.Stretch = Stretch.Uniform;
            btn.Content = img;
        }
     
    }
}

