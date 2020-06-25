using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class IdWyrobuCukierniczego
    {
        public IdWyrobuCukierniczego()
        {
            ZamowienieWyrobCukierniczy = new HashSet<ZamowienieWyrobCukierniczy>();
        }

        public int Nazwa { get; set; }
        public double CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public int IdWyrobuCukierniczego1 { get; set; }

        public virtual ICollection<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }
    }
}
