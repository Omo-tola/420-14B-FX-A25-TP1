using _420_14B_FX_A25_TP1.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420_14B_FX_A25_TP1
{
    public class Animal
    {
        public const string VALEUR_CHAMP_VIDE = "Inconnu";
        private Adoptant _adoptant;
        private DateOnly _dateAdoption;
        private DateOnly _dateArrivee;
        private DateOnly _dateNaissance;
        private string _description;
        private EspeceAnimal _espece;
        private uint _id;
        private string _nom;
        private float _poids;
        private decimal _prix;
         
        private Adoptant Adoptant
        {
            get { return _adoptant; }
            set
            {
                _adoptant = value;
            }
        }
        private DateOnly DateAdoption
        {
            get { return _dateAdoption; }
            set
            {
                _dateAdoption = value;
            }
        }
        private DateOnly DateArrivee
        {
            get { return _dateArrivee; }
            set
            {
                _dateArrivee = value;
            }
        }
        private DateOnly DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);
                if (value < aujourdhui)
                {
                    value = aujourdhui;
                }
            }
        }
        private string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        private uint Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        private string Nom
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
        private float Poids
        {
            get { return _poids; }
            set
            {
                if(value<0)
                {
                    value = 1;
                }
            }
        }
        private decimal Prix
        {
            get { return _prix; }
            set
            {
                _prix = value;
            }
        }
        private byte Age
        {
            get
            {
                DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);
                return (aujourdhui-DateNaissance);
            }
        }
    }
}