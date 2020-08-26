using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

#nullable disable

namespace StunasMobile.Entities.Entitites
{
    public partial class Mobile
    {
        public Mobile()
        {
            Historiques = new Collection<Historique>();
        }
        public int Id { get; set; }
        public string Codeclient { get; set; }
        public string Societe { get; set; }
        public string Site { get; set; }
        public string Nom { get; set; }
        public decimal Numero { get; set; }
        public string Forfait { get; set; }
        public string Montant { get; set; }
        public string Data { get; set; }
        public string Handset { get; set; }
        public string Prixhandset { get; set; }

        public ICollection<Historique> Historiques { get; set; }
    }
}
