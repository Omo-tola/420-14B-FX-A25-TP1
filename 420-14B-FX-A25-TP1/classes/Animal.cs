using _420_14B_FX_A25_TP1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420_14B_FX_A25_TP1.classes
{
    public class Animal
    {
        public const string VALEUR_CHAMP_VIDE = "Inconnu";
        private Adoptant _adoptant;
        private DateOnly? _dateAdoption;
        private DateOnly _dateArrivee;
        private DateOnly _dateNaissance;
        private string _description;
        private EspeceAnimal _espece;
        private uint _id;
        private string _nom;
        private float _poids;
        private decimal _prix;
         
        public Adoptant Adoptant
        {
            get { return _adoptant; }
            set
            {
                _adoptant = value;
            }
        }
        public DateOnly? DateAdoption
        {
            get { return _dateAdoption; }
            set
            {
                _dateAdoption = value;
            }
        }
        public DateOnly DateArrivee
        {
            get { return _dateArrivee; }
            set
            {
                DateOnly aujoudhui = DateOnly.FromDateTime(DateTime.Now);
                if(value < aujoudhui)
                {
                    aujoudhui = value;

                }
            }
        }
        public DateOnly DateNaissance
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
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        public EspeceAnimal Espece
        {
            get { return _espece; }
            set
            {
                _espece = value;
            }
        }
        public uint Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = VALEUR_CHAMP_VIDE;

                }
                _nom = value;

            }
        }
        public float Poids
        {
            get { return _poids; }
            set
            {
                if(value<0)
                {
                    value = 1;
                }

                _poids = value;
            }
        }
        public decimal Prix
        {
            get { return _prix; }
            set
            {
                if(value <0)
                {
                    value = 1;
                }
                _prix = value;
            }
        }
        public byte Age
        {
            get
            {
                DateOnly aujourdhui = DateOnly.FromDateTime(DateTime.Now);
              
                int age = aujourdhui.Year - DateNaissance.Year;
                byte ageByte = (byte)age;

                return ageByte;
            }
        }
        public Animal (uint id, string nom, EspeceAnimal espece, DateOnly dateNaissance, float poids, decimal prix, string description, DateOnly dateArrivee, Adoptant adoptant, DateOnly? dateAdoption)
        {
            Id = id;
            Nom = nom;
            Espece = espece;
            DateNaissance = dateNaissance;
            Poids = poids;
            Prix = prix;
            Adoptant = adoptant;
            DateAdoption = dateAdoption;
            DateArrivee = dateArrivee;
            Description = description;
        }
        public override string ToString()
        {
            string adoptantInfo  ;
            string statut;

            if (Adoptant != null)
            {
                adoptantInfo=$"{Adoptant.Nom} {Adoptant.Prenom}" ;
                statut = "Adopté";
            }
            else
            {
                adoptantInfo = "";
                statut = "Disponible";

            }



            return $"{Nom,-20}{Espece,-15}{Age + "(s)",-10} {Poids + "kg",-10} {statut,-15} {adoptantInfo,-30} ";



        }
        
    }
}