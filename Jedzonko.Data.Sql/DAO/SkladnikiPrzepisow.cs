using Jedzonko.Common.Enums;

namespace Jedzonko.Data.SQL.DAO
{
    public class SkladnikiPrzepisow
    {
        public int SkladnikiPrzepisowId { get; set; }
        public int PrzepisyId { get; set; }
        public int SkladnikiId { get; set; }
        public int Ilosc { get; set; }
        public Jednostka Jednostka { get; set; }
        public virtual Skladniki Skladniki { get; set; }
        public virtual Przepisy Przepisy { get; set; }

        
    }
}
