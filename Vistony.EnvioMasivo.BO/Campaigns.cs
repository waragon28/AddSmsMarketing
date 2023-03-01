using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.EnvioMasivo.BO
{
    public class Campaigns
    {
        public string CampaignName { get; set; }
        public string CampaignType { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string Remarks { get; set; }
        public string TargetGroupType { get; set; }
        public List<CampaignBusinessPartners> CampaignBusinessPartners { get; set; }
    }
}
