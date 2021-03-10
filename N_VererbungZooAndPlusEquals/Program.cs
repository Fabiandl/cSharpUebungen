using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace N_VererbungZoo
{
    public abstract class Tier
    {
        private string name;
        private string rasse;
        private string futter;

        public override string ToString()
        {
            return $"{name}, {rasse}, {futter}";
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Rasse
        {
            get => rasse;
            set => rasse = value;
        }

        public string Futter
        {
            get => futter;
            set => futter = value;
        }
    }

    public class Vogel : Tier
    {
        public string pfeifen;

        public string Pfeifen
        {
            get => pfeifen;
            set => pfeifen = value;
        }

        public override string ToString()
        {
            return base.ToString() + this.pfeifen;
        }
    }

    public class Zoo : List<Tier>
    {
        public static void Main(string[] args)
        {
            Tier v1 = new Vogel{Name =  "Hund", Rasse = "Wufwuf", Futter = "Leckeres"};
            machwas();
        }

        private static void machwas()
        {
            var zoo = new Zoo();
            zoo += new Vogel{Name =  "Hund", Rasse = "Wufwuf", Futter = "Leckeres"};
            zoo -= "Hund";
        }

        public static Zoo operator +(Zoo zoo, Tier a)
        {
            zoo.Add(a);
            return zoo;
        }

        public static Zoo operator -(Zoo zoo, string name)
        {
            zoo.Remove(zoo.Find(t => t.Name == name));
            return zoo;
        }
    }
}