using _420_14B_FX_A25_TP1.enums;


namespace _420_14B_FX_A25_TP1.classes
{

	/// <summary>
	/// Classe permettant la gestion des adoptions
	/// </summary>
	public class GestionAdoption
	{

		private Adoptant[] _adoptants;
		private Animal[] _animaux;

		public Adoptant[] Adoptants
		{
			get { return _adoptants; }
			set { _adoptants = value; }
		}
		public Animal[] Animaux
		{
			get { return _animaux; }
			set { _animaux = value; }
		}

	
			
		/// <summary>
		/// Constructeur de la classe. Charge les adoptants et les animaux à partir des fichiers CSV fournis.
		/// </summary>
		/// <param name="cheminFichierAdoptants">Chemin du fichier CSV contenant les adoptants.</param>
		/// <param name="cheminFichierAnimaux">Chemin du fichier CSV contenant les animaux.</param>

		public GestionAdoption(string cheminFichierAdoptants, string cheminFichierAnimaux)
		{
			//À compléter
			ChargerAdoptants(cheminFichierAdoptants);
			ChargerAnimaux(cheminFichierAnimaux);

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
		private Adoptant TrouverAdoptantParId(uint idAdoptant)
		{
			
			for(int i = 0;i < Adoptants.Length;i++)
			{
				if (Adoptants[i].Id == idAdoptant)
					return Adoptants[i];
			}
			return null;
		}



        private void ChargerAnimaux(string cheminFichier) 
		{
            string[] donneesAnimaux = Utilitaire.ChargerDonnees(cheminFichier);

            Animaux = new Animal[donneesAnimaux.Length - 1];

            for (int i = 1; i < donneesAnimaux.Length; i++)
            {
                string[] champs = donneesAnimaux[i].Split(";");

                uint id = uint.Parse(champs[0]);
				string nom = champs[1];
				EspeceAnimal espece = (EspeceAnimal)Enum.Parse(typeof(EspeceAnimal),champs[2]) ;
                DateOnly dateNaissance = DateOnly.Parse(champs[3]);
				float poids = float.Parse(champs[4]);
				decimal prix = decimal.Parse(champs[5]);
				string description = champs[6];
                DateOnly dateArrivee =DateOnly.Parse (champs[7]);
				Adoptant a = null;
				if (champs[8]!="" )
				{
                    uint idAdoptant = uint.Parse(champs[8]);

					a =TrouverAdoptantParId(idAdoptant);
					
				}

				DateOnly? dateAdoption = null ;
				if(champs[9]!="" )
				{
                    dateAdoption = DateOnly.Parse(champs[9]);

                }


                Animaux[i - 1] = new Animal(id, nom, espece, dateNaissance, poids, prix, description, dateArrivee, a, dateAdoption);

            }


        }
        private Animal[] AjouterAnimal(Animal animal, Animal[] animaux)
        {
			Animal[] anim = new Animal[animaux.Length + 1];

            for (int i = 0; i < anim.Length; i++)
            {
				anim[i] = animaux[i];
            }
            anim[anim.Length-1] = animal;

            return anim;
        }
		public Animal [] RechercherAnimaux(string nom = null ,EspeceAnimal? espece =null, bool? disponible = null)
		{
			Animal[] animaux = new Animal[0];

			for(int i = 0;i< Animaux.Length;i++)
			{
                bool contient = false;

                if (Animaux[i].Nom.Contains(nom) )
				{
					contient = true;
				}
				if( Animaux[i].Espece == espece )
				{
                    contient = true;

                }
                if (Animaux[i].Adoptant == null)
				{
                    contient = true;

                }
                AjouterAnimal(Animaux[i], animaux);

            }
            return animaux;
        }

        public void AjouterAdoptant(Adoptant adoptant)
		{
			Adoptant[] adop = new Adoptant[Adoptants.Length + 1];
			for(int i =0; i< adop.Length;i++)
			{
				adop[i] = Adoptants[i];
			}
			adop[Adoptants.Length - 1] = adoptant;
			
		}
		private Animal TrouverAnimalParId(uint idAnimal)
		{
			for(int i = 0; i<Animaux.Length;i++)
			{
				if (Animaux[i].Id==idAnimal)
				{
					return Animaux[i];
				}
			}
			return null;
		}
        public bool AdopterAnimal(uint idAnimal, uint idAdoptant)
		{
			Adoptant adoptant= TrouverAdoptantParId(idAdoptant);
			Animal animal= TrouverAnimalParId(idAnimal); ;
			if (adoptant != null && animal != null)
			{
				if (animal.Adoptant == null)
				{
                    DateOnly aujoudhui = DateOnly.FromDateTime(DateTime.Now);

                    animal.Adoptant = adoptant;
					animal.DateAdoption = aujoudhui;
				}
			}   	
			return false;
		}
        private uint CompterAnimauxParStatut(bool adoptes)
		{
			uint total = 0;
			if(adoptes==true)
			{

                for (int i=0;i<Animaux.Length;i++)
			    {
					if (Animaux[i].Adoptant != null)
					{
						total++;
					}
				}
			}

			if(adoptes == false)
			{

                for (int i = 0; i < Animaux.Length; i++)
                {
                    if (Animaux[i].Adoptant == null)
                    {
						total++;
                    }
                }
            }
			
			return total;
		}
        public int CompterAnimauxDisponiblesParEspece(EspeceAnimal espece)
		{
			int total = 0;
			for(int i=0;i<Animaux.Length;i++)
			{
				if (Animaux[i].Espece == espece)
					total++;
			}
			return total;
		}
        public decimal CalculerPrixMoyenAdoption()
		{
			decimal prixTotal = 0;

			for(int i =0;i<Animaux.Length;i++)
			{
				if(Animaux[i].Adoptant!=null)
				{
					prixTotal += Animaux[i].Prix;
				}
			}
			uint nb = CompterAnimauxParStatut(true);
			return prixTotal / nb;
		}
    }
}
