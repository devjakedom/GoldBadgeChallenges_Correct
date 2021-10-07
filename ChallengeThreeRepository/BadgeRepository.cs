using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void CreateNewBadge(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
        }

        public Dictionary<int, List<string>> ViewAllBadgesAndDoorAccess()
        {
            return _badgeDictionary;
        }

        public bool UpdateBadge(int badge, List<string> doors)
        {
            _badgeDictionary[badge] = doors;
            return true;
        }

        public bool RemoveBadge(int badge)
        {
            _badgeDictionary.Remove(badge);
            return true;
        }
    }
}
