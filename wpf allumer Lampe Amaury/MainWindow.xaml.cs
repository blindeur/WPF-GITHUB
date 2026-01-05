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

namespace allumer_Lampe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    using System;
    using System.Collections.Generic;
    using System.Windows;

  
        public partial class MainWindow : Window
        {
            List<Lampe> lampes = new List<Lampe>();
            List<Interrupteur> interrupteurs = new List<Interrupteur>();

            public MainWindow()
            {
                InitializeComponent();

                // Création de lampes
                lampes.Add(new Lampe("L1", "Rouge"));
                lampes.Add(new Lampe("L2", "Bleu"));
                lampes.Add(new Lampe("L3", "Vert"));

                // Création des interrupteurs
                foreach (var lampe in lampes)
                {
                    interrupteurs.Add(new Interrupteur("I_" + lampe.Code, lampe));
                }

                AfficherEtats();
            }

            private void BtnActionner_Click(object sender, RoutedEventArgs e)
            {
                string code = txtCodeLampe.Text;
                var interrupteur = interrupteurs.Find(i => i.Lampe.Code == code);
                if (interrupteur != null)
                {
                    interrupteur.Actionner();
                    AfficherEtats();
                }
                else
                {
                    MessageBox.Show("Lampe non trouvée !");
                }
            }

            private void BtnAllumerToutes_Click(object sender, RoutedEventArgs e)
            {
                foreach (var lampe in lampes)
                {
                    lampe.Allumer();
                }
                AfficherEtats();
            }

            private void AfficherEtats()
            {
                txtEtatLampes.Text = "";
                foreach (var lampe in lampes)
                {
                    txtEtatLampes.Text += lampe.AfficherEtat() + "\n";
                }
            }
        }

        public class Lampe
        {
            public string Code { get; set; }
            public string Couleur { get; set; }
            public bool EstAllumee { get; set; }

            public Lampe(string code, string couleur)
            {
                Code = code;
                Couleur = couleur;
                EstAllumee = false;
            }

            public void Allumer() => EstAllumee = true;
            public void Eteindre() => EstAllumee = false;

            public string AfficherEtat()
            {
                return $"Lampe {Code} ({Couleur}) : {(EstAllumee ? "Allumée" : "Éteinte")}";
            }
        }

        public class Interrupteur
        {
            public string Code { get; set; }
            public Lampe Lampe { get; set; }

            public Interrupteur(string code, Lampe lampe)
            {
                Code = code;
                Lampe = lampe;
            }

            public void Actionner()
            {
                if (Lampe.EstAllumee)
                    Lampe.Eteindre();
                else
                    Lampe.Allumer();
            }
        }
    }
