using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420_14B_FX_A25_TP1.classes
{
    public class Adoptant
    {
        public const string VALEUR_CHAMP_VIDE = "Inconnu";
        public const byte NO_TELEPHONE_NB_CARACTERES_MIN = 12;
        public const char NO_TELEPHONE_CARACT_SEPARATION = '-';
        public const char COURRIEL_CARACT_REQUIS = '@';



        private uint _id;
        private string _nom;
        private string _prenom;
        private string _telephone;
        private string _courriel;


        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'adoptant
        /// </summary>
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Obtient ou définit le nom de l'adoptant 
        /// </summary>
        /// <remarks>Le nom ne doit pas être vide null ou ne contenir que des espaces. 
        /// Si tel est le cas, alors la valeur est : "Inconnu"</remarks>
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = VALEUR_CHAMP_VIDE;
                }
            }
        }

        /// <summary>
        /// Obtient ou définit le prénom de l'adoptant 
        /// </summary>
        /// <remarks>Le prénom ne doit pas être vide null ou ne contenir que des espaces. 
        /// Si tel est le cas, alors la valeur est : "Inconnu"</remarks>
        public string Prenom
        {
            get { return _prenom; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = VALEUR_CHAMP_VIDE;
                }
            }
        }

        /// <summary>
        /// Obtient ou définit le téléphone de l'adoptant 
        /// </summary>
        /// <remarks>Le télépone ne doit pas être vide null ou ne contenir que des espaces. 
        /// Il doit également être au format suivant 123-145-789 et ne contenir que des chiffres: 
        /// Si le format n'est pas respecté, alors la valeur est : "Non fourni"</remarks>
        public string Telephone
        {
            get { return _telephone; }
            set {
                _telephone = value;

            }
        }


        /// <summary>
        /// Obtient ou définit le courriel de l'adoptant 
        /// </summary>
        /// <remarks>Le courrile ne doit pas être vide null ou ne contenir que des espaces.
        /// Il doit également contenir le caractère @
        /// Si le format n'est pas respecté, alors la valeur est : "invalide@email.com"</remarks>

        public string Courriel
        {
            get { return _courriel; }
            set
            {
                while(value.Contains(COURRIEL_CARACT_REQUIS))
                {
                    _courriel = value;

                }
            }
        }


     /// <summary>
     /// Constructeur paramètré de la classe
     /// </summary>
     /// <param name="id">Identifiant unique </param>
     /// <param name="nom">Nom de l'adoptant</param>
     /// <param name="prenom">Prénom de l'adoptant</param>
     /// <param name="telephone">Téléphone de l'adoptant</param>
     /// <param name="courriel">Courriel de l'adoptant</param>
        public Adoptant(uint id, string nom, string prenom, string telephone, string courriel)
        {
            nom = Nom;
            prenom = Prenom;
            telephone = Telephone;
            courriel = Courriel;
        }

  
        /// <summary>
        /// Retourne une chaîne de caractère représentant l'objet.
        /// </summary>
        /// <returns>Chaîne de caractère représentant l'objet</returns>
        public override string ToString()
        {
            return $"{Id},{Nom},{Prenom},{Telephone},{Courriel}";
        }
    }

}
