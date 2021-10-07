using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();
        public Badge() { }
        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
