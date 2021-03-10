namespace Kontakt9
{
    public class Kontakt
    {
        private string name;
        private int alter;

        public Kontakt()
        {
            
        }

        public Kontakt(string name, int alter)
        {
            this.name = name;
            this.alter = alter;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Alter
        {
            get => alter;
            set => alter = value;
        }

        public override string ToString()
        {
            return $"Name: {name}, Alter {alter}";
        }
    }
    
}