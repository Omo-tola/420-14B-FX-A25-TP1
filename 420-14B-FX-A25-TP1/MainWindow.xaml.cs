using _420_14B_FX_A25_TP1.classes;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _420_14B_FX_A25_TP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string CHEMIN_FICHIER_ADOPTANTS = "data\adoptants.csv";
        public const string CHEMIN_FICHIER_ANIMAUX = "data\animaux.csv";


        private GestionAdoption _gestionAdoption;

        public MainWindow ()
        {
            InitializeComponent();

            string cheminFichierAdoptants = AppContext.BaseDirectory + "data\\adoptants.csv";
            string cheminFichierAnimaux = AppContext.BaseDirectory + "data\\animaux.csv";

            //instancier le gestionnaire d'adoption ici
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void ChargerEspeceAnimal ()
        {
            string[] especeAnimal = Enum.GetNames(typeof(EspeceAnimal));
            for (int i = 0; i < especeAnimal.Length; i++)
            {
                cboFiltreEspeceAnimal.Items.Add(especeAnimal[i]);
            }
        }

    }
        
}