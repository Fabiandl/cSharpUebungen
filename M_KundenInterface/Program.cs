using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace M_KundenInterface
{
    public abstract class Kontakt : IReport
    {
        private string name;
        private List<String> emails;

        public Kontakt()
        {
            emails = new List<string>();
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public List<string> Emails
        {
            get => emails;
        }

        public abstract void monatsReport();
    }

    public interface IReport
    {
        void monatsReport();
    }

    public class Kunde : Kontakt
    {
        private decimal kontostand;

        public decimal Kontostand
        {
            get => kontostand;
            set => kontostand = value;
        }

        public  override void monatsReport()
        {
            Console.WriteLine($"  Kunde: {this.Name}, Kontostand {Kontostand}");
        }
    }

    public class Lieferant : Kontakt
    {
        private string bankverbindung;

        public string Bankverbindung
        {
            get => bankverbindung;
            set => bankverbindung = value;
        }

        public override void monatsReport()
        {
            Console.WriteLine($"  Lieferant: {this.Name}, Kontonr. {Bankverbindung}");
        }
    }

    public class Steuerung
    {
        public static void Main(string[] args)
        {
            List<Kontakt> kontakte = new List<Kontakt>();
            
            Kunde kunde = new Kunde();
            kunde.Name = "Fabian";
            kunde.Emails.Add("Fabian@web.de");
            kunde.Kontostand = 187.41m;

            Lieferant lieferant = new Lieferant();
            lieferant.Name = "Mindafactory";
            lieferant.Emails.Add("HS@web.de");
            lieferant.Bankverbindung = "DE187542598754598455688";
            
            kontakte.Add(kunde);
            kontakte.Add(lieferant);

            foreach (var kontakt in kontakte)
            {
                kontakt.monatsReport();
            }
        }
    }
}