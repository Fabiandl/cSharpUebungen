namespace Buch10
{
    public class Buch
    {
        private string isbn;
        private string titel;
        private string autor;
        
        public Buch(string isbn, string titel, string autor)
        {
            this.isbn = isbn;
            this.titel = titel;
            this.autor = autor;
        }

        public string Isbn
        {
            get => isbn;
            set => isbn = value;
        }

        public string Titel
        {
            get => titel;
            set => titel = value;
        }

        public string Autor
        {
            get => autor;
            set => autor = value;
        }

        public override string ToString()
        {
            return $"ISBN: {isbn}, Titel: {titel}, Autor: {autor}";
        }
    }
}