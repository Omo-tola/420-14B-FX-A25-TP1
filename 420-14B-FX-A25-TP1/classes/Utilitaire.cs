
using System.IO;

namespace _420_14B_FX_A25_TP1.classes
{

    /// <summary>
    /// Classe utilitaire
    /// </summary>
    public static class Utilitaire
    {

        /// <summary>   
        /// Permet charger les données dans un vecteur de chaînes de caractères.
        /// </summary>
        /// <param name="pCheminFichier">Chemin d'accès au fichier</param>
        /// <returns>Un vecteur contenant les lignes du fichier. Null si aucune donnée dans le fichier.</returns>
        public static String[] ChargerDonnees(String pCheminFichier)
        {
           
            // Création du flux en lecture du fichier dont le chemin d'accès est "cheminFichier".
            string fichierTexte = "";
            using (StreamReader fluxLecture = new StreamReader(pCheminFichier))
            {
                // Lecture du fichier en une seule instruction.
                fichierTexte = fluxLecture.ReadToEnd();
            }

            // Retrait des "carriage return" ('\r'), s'il y en a.
            fichierTexte = fichierTexte.Replace("\r", "");

            // Création d'un vecteur de chaînes de caractères contenant chaque ligne individuellement.
            String[] vectLignes = fichierTexte.Split('\n');

            // Nombre de lignes non vides dans le fichier.
            int nbLignes;

            if (vectLignes[vectLignes.Length - 1] == "")
                nbLignes = vectLignes.Length - 1; // On ne considère pas la dernière ligne si elle est vide.
            else
                nbLignes = vectLignes.Length;

            // Création du vecteur contenant les données du fichier; la taille est déterminée par le nombre de lignes (non vides) du fichier.
            String[] vectDonnees = new String[nbLignes];

            for (int i = 0; i < vectDonnees.Length; i++)
            {
                vectDonnees[i] = vectLignes[i];
            }

            // On retourne le vecteur contenant les données créé.
            return vectDonnees;
           
        }

        /// <summary>
        /// Permet d'enregister des données sérialisées dans un fichier. Remplace le contenu au complet du fichier
        /// à partir de la chaîne de caractères fournie en entrée.
        /// </summary>
        /// <param name="cheminFichier">Chemin d'accès au fichier</param>
        /// <param name="donneesSerialises">Données à enregistrer dans le fichier</param>
        public static void EnregistrerDonnees(String cheminFichier, string donneesSerialises)
        {

            // Écriture de tous les membres.
            using (StreamWriter fluxEcriture = new StreamWriter(cheminFichier, false))
            {
                fluxEcriture.Write(donneesSerialises);
            }

        }
    }
 
 }  

