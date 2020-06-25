using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisk { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
