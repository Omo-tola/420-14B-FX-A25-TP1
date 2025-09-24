
using System.IO;
using System.Net;
using System.Windows.Navigation;


namespace _420_14B_FX_A25_TP1.classes
{

	/// <summary>
	/// Classe permettant la gestion des adoptions
	/// </summary>
	public class GestionAdoption
	{

		private Adoptant[] _adoptants;

		public Adoptant[] Adoptants
		{
			get { return _adoptants; }
			set { _adoptants = value; }
		}



		/// <summary>
		/// Constructeur de la classe. Charge les adoptants et les animaux à partir des fichiers CSV fournis.
		/// </summary>
		/// <param name="cheminFichierAdoptants">Chemin du fichier CSV contenant les adoptants.</param>
		/// <param name="cheminFichierAnimaux">Chemin du fichier CSV contenant les animaux.</param>

		public GestionAdoption(string cheminFichierAdoptants, string cheminFichierAnimaux)
		{
			//À compléter
			throw new NotImplementedException();

		}

		/// <summary>
		/// Charge les adoptants depuis un fichier CSV.
		/// </summary>
		private void ChargerAdoptants(string cheminFichier)
		{
			string[] donneesAdoptants = Utilitaire.ChargerDonnees(cheminFichier);

			Adoptants = new Adoptant[donneesAdoptants.Length - 1];

			for (int i = 1; i < donneesAdoptants.Length; i++)
			{
				string[] champs = donneesAdoptants[i].Split(";");

				uint id = uint.Parse(champs[0]);
				string nom = champs[1];
				string prenom = champs[2];
				string telephone = champs[3];
				string courriel = champs[4];


				Adoptants[i - 1] = new Adoptant(id, nom, prenom, telephone, courriel);

			}

		}

	}
}
