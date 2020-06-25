using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class ZamowienieWyrobCukierniczy
    {
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public int ZamowienieIdZamowienia { get; set; }
        public int IdWyrobuCukierniczegoIdWyrobuCukierniczego { get; set; }

        public virtual IdWyrobuCukierniczego IdWyrobuCukierniczegoIdWyrobuCukierniczegoNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowieniaNavigation { get; set; }
    }
}
