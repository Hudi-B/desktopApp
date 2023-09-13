using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace asdasd
{
    internal class Dolgozo
    {
        private int fizetes;
        public string nev;
        public string szakma;
        private int szuletesiEv;

        public int Fizetes { get => fizetes; set => fizetes = value > 0 ? value : 0; }
        public int SzuletesiEv { get => szuletesiEv; set => szuletesiEv = value; }

        public Dolgozo(int fizetes, string nev, string szakma, int szuletesiEv) 
        {
            this.fizetes = fizetes;
            this.nev = nev;
            this.szakma = szakma;
            this.szuletesiEv = szuletesiEv;
        }

        public string GetSzakma()
        {
            return this.szakma;
        }
        public string SetSzakma(string szakma)
        {
            return this.szakma = szakma;
        }
        public string Kiir()
        {
            return($"Név: {this.nev},Születési év: {this.szuletesiEv},Fizetés: {this.fizetes}Ft,Szakmája: {this.szakma}");
        }
    }
}
