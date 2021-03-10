using System;
using System.Collections.Generic;

namespace InAndOut11
{
    public class Verein
    {
        private string name;
        private int position;
        private List<string> ergebnisse;

        public Verein(string name, int position)
        {
            this.ergebnisse = new List<string>();
            this.name = name;
            this.position = position;
        }

        public string Name => name;

        public int Position
        {
            get => position;
            set => position = value;
        }

        public List<string> Ergebnisse => ergebnisse;

        public void addErgebnis(string erg)
        {
            this.ergebnisse.Add(erg);
        }

        public void addErgebnisse(string ergs)
        {
            string[] splitted = ergs.Split(' ');
            for (int i = 0; i < splitted.Length; i++)
            {
                addErgebnis(splitted[i]);
            }
        }

        private int calcPoints()
        {
            int punkte = 0;
            foreach (var erg in ergebnisse)
            {
                if (!erg.Equals("---"))
                {
                    string[] ergs = erg.Split(':');
                    if (int.Parse(ergs[0]) > int.Parse(ergs[1]))
                    {
                        punkte++;
                    }    
                }
            }
            return punkte;
        }
        
        private int calcTore()
        {
            int tore = 0;
            foreach (var erg in ergebnisse)
            {
                if (!erg.Equals("---"))
                {
                    string[] ergs = erg.Split(':');
                    tore += int.Parse(ergs[0]);
                }
            }
            return tore;
        }

        public override string ToString()
        {
            return $"Pos: {position,2:##} | {name} | {string.Join(",",ergebnisse)} | Tore: {calcTore()} | Points: {calcPoints()}";
        }
    }
}