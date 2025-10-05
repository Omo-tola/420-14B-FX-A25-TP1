using _420_14B_FX_A25_TP1.classes;
using _420_14B_FX_A25_TP1.enums;
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

        public MainWindow()
        {
            InitializeComponent();

            string cheminFichierAdoptants = AppContext.BaseDirectory + "data\\adoptants.csv";
            string cheminFichierAnimaux = AppContext.BaseDirectory + "data\\animaux.csv";

            //instancier le gestionnaire d'adoption ici
            _gestionAdoption = new GestionAdoption(cheminFichierAdoptants, cheminFichierAnimaux);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChargerEspeceAnimal();
            AfficherLstAdoptant();
        }
        public void ChargerEspeceAnimal()
        {
            string[] especeAnimal = Enum.GetNames(typeof(EspeceAnimal));
            for (int i = 0; i < especeAnimal.Length; i++)
            {
                cboFiltreEspeceAnimal.Items.Add(especeAnimal[i]);
                cboEspece.Items.Add(especeAnimal[i]);
            }
        }
        public void AfficherLstAdoptant()
        {
            lstAnimaux.Items.Clear();
            for (int i = 0; i < _gestionAdoption.Animaux.Length; i++)
            {
                lstAnimaux.Items.Add(_gestionAdoption.Animaux[i]);
            }
        }


        private void btnSauvegarder_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ValiderFormulaire()
        {

        }

        private void lstAnimaux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)lstAnimaux.SelectedItem;
            if(animal != null)
            {
                txtNom.Text = animal.Nom;
                if (animal.Nom != null)
                {
                    cboEspece.SelectedItem = animal.Espece;

                }
                dpDateNaissance.Text = animal.DateNaissance.ToString();
                txtPoids.Text = animal.Poids.ToString();
                txtPrix.Text = animal.Prix.ToString();
                if(animal.Adoptant==null)
                {
                    cboStatut.SelectedIndex = 0;
                    
                }
                else
                {
                    cboStatut.SelectedIndex = 1;

                }

                if (animal.Adoptant!= null)
                {
                    txtNomAdoptant.Text = animal.Adoptant.Nom;
                    txtPrenomAdoptant.Text = animal.Adoptant.Prenom;
                    txtTelephoneAdoptant.Text = animal.Adoptant.Telephone;
                    txtCourrielAdoptant.Text = animal.Adoptant.Courriel;
                    txtDateAdoption.Text = animal.DateAdoption.ToString();
                }
                if(animal != null)
                {
                    btnAdopter.IsEnabled = (animal.Adoptant == null);

                }
                else
                {
                    btnAdopter.IsEnabled = false;
                }

            }
        }

        private void btnAdopter_Click(object sender, RoutedEventArgs e)
        {
            Animal animalAdopter = (Animal)lstAnimaux.SelectedItem;
            Adoptant nouvelAdoptant = new Adoptant(1, txtNomAdoptant.Text, txtPrenomAdoptant.Text, txtTelephoneAdoptant.Text, txtCourrielAdoptant.Text);
            bool adoptionReussi = _gestionAdoption.AdopterAnimal(animalAdopter.Id, 1);
            if(adoptionReussi)
            {
                MessageBox.Show($"{animalAdopter.Nom} a été adopté");
            }
        }
    }    
}