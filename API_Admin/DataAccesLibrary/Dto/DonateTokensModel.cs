using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.Dto
{
    public class DonateTokensModel
    {
        public long FanId { get; set; }
        public long CreatorId { get; set; }
        public int Amount { get; set; }
    }
}
