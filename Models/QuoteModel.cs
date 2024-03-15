namespace JL_CW_App.Models
{
    public class QuoteModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public QuoteModel()
        {
        }

        public QuoteModel(string author, string content)
        {
            Author = author;
            Content = content;
        }
    }
}

