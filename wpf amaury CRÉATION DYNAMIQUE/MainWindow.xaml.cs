using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_amaury_CRÉATION_DYNAMIQUE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PrepareInterface();

        }
        public void PrepareInterface() 
        {
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            for (int i = 0; i < 3; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);

            }
            RowDefinition[] rowDef = new RowDefinition[3];
            for (int j = 0; j < 3; j++)
            {
                rowDef[j] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[j]);
            }
            // premier ligne 
            TextBlock txtBMonTexte = new TextBlock();
            grdMain.Children.Add(txtBMonTexte);
            txtBMonTexte.Text = "Texte bloc créé dynamiquemment";
            Grid.SetColumnSpan(txtBMonTexte, 3);
            Grid.SetRow(txtBMonTexte, 0);
            txtBMonTexte.Height = 50;
            txtBMonTexte.Width = 800;
            txtBMonTexte.Background = Brushes.Yellow;
            txtBMonTexte.Foreground = Brushes.Red;
            txtBMonTexte.FontFamily = new FontFamily("Impact");
            txtBMonTexte.FontSize = 16;
            // deuxieme ligne
            Button[] btnB = new Button[3];
            for (int i = 0; i < 3; i++)
            {
                btnB[i] = new Button();
                grdMain.Children.Add(btnB[i]);
                Grid.SetColumn(btnB[i], i);
                Grid.SetRow(btnB[i], 1);
                btnB[i].Content = "bouton " + i;
                btnB[i].Height = 150;
                btnB[i].Width = 150;

            }
            //troisieme ligne
            StackPanel stkBloc1 = new StackPanel();
            TextBlock txtB = new TextBlock();
            txtB.Text = "infos :";
            txtB.Background = Brushes.Yellow;
            txtB.Height = 50;
            txtB.Width = 800;
            TextBox txtB1 = new TextBox();
            txtB1.Text = "attend Info:";
            Grid.SetColumnSpan(stkBloc1, 2);
            Grid.SetRow(stkBloc1, 2);
            stkBloc1.Children.Add(txtB);
            stkBloc1.Children.Add(txtB1);
            grdMain.Children.Add(stkBloc1);
            
            // troisieme ligne a droite
            ComboBox cboNoms = new ComboBox();
            grdMain.Children.Add(cboNoms);
            Grid.SetColumn(cboNoms, 3);
            Grid.SetRow(cboNoms, 2);
            cboNoms.Height = 150;
            cboNoms.Width = 150;
            Thickness myThickness = new Thickness();
            myThickness.Bottom = 20;
            myThickness.Left = 20;
            myThickness.Right = 20;
            myThickness.Top = 20;
            cboNoms.Margin = myThickness;



        }
    }
}