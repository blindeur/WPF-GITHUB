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

namespace Amaury_ACT_EX_WPF_OBJET__EVENTS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
             // Gestionnaires d’événements
            texteBox0.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            texteBox1.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            texteBox2.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);

            BtnCalculer.MouseEnter += new MouseEventHandler(SurvolBouton);
            BtnCalculer.MouseLeave += new MouseEventHandler(QuitteBouton);
            BtnCalculer.Click += new RoutedEventHandler(BtnCalculer_Click);
        }

        // Vérifie si le texte est un entier
        private bool EstEntier(string texteUser)
        {
            return int.TryParse(texteUser, out _);
        }

        // Empêche la saisie autre que chiffre ou virgule
        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "," && ((TextBox)sender).Text.IndexOf(e.Text) > -1)
            {
                e.Handled = true; // déjà une virgule
            }

            if (e.Text != "," && !EstEntier(e.Text))
            {
                e.Handled = true; // pas un chiffre
            }
        }

        // Survol du bouton principal
        private void SurvolBouton(object sender, MouseEventArgs e)
        {
            BtnV.Visibility = Visibility.Visible;
            BtnV.Background = Brushes.Red;
        }

        // Quitte le survol
        private void QuitteBouton(object sender, MouseEventArgs e)
        {
            BtnV.Visibility = Visibility.Hidden;
        }

        // Click sur CALCULER
        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(texteBox0.Text.Replace(',', '.'), out double a) &&
                double.TryParse(texteBox1.Text.Replace(',', '.'), out double b) &&
                double.TryParse(texteBox2.Text.Replace(',', '.'), out double c))
            {
                MethodesDuProjet mesOutils = new MethodesDuProjet();
                string message;
                mesOutils.ResoudreTrinome(a, b, c, out message);

                // Affiche la seconde fenêtre
                PageResultat fenetre = new PageResultat();
                fenetre.LblResultat.Text = message;
                fenetre.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veuillez entrer uniquement des nombres valides.", "Erreur de saisie",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
