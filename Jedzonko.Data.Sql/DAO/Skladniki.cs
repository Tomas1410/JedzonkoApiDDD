using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Skladniki
    {
        public Skladniki()
        {
            SkladnikiPrzepisow = new List<SkladnikiPrzepisow>();
        }
        public int SkladnikiId { get; set; }
        public string Nazwa { get; set; }


        public virtual ICollection<SkladnikiPrzepisow> SkladnikiPrzepisow { get; set; }
    }
}
