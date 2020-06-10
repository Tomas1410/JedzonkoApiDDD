namespace Jedzonko.Data.SQL.DAO
{
    public class RodzajePrzepisow
    {
        public int RodzajePrzepisowId { get; set; }
        public int PrzepisyId { get; set; }
        public int RodzajeId { get; set; }

        public virtual Rodzaje Rodzaje { get; set; }
        public virtual Przepisy Przepisy { get; set; }
    }
}
