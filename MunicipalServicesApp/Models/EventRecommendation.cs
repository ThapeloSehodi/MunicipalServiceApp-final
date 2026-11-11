using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    // Holds one recommended event, how strongly it matches the user's
    // search behaviour, and a short explanation shown to the user.
    public class EventRecommendation
    {
        public LocalEvent Event { get; set; }

        public int Score { get; set; }

        public string Reason { get; set; }
    }
}
