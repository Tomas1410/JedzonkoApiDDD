namespace Jedzonko.Data.SQL.DAO
{
    public class Zdjecia
    {
        public int ZdjeciaId { get; set; }
        public string Imglink { get; set; }
        public int PrzepisyId { get; set; }

        public virtual Przepisy Przepisy { get; set; }
    }
}
