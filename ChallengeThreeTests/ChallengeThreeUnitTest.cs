using ChallengeThreeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTests
{
    [TestClass]
    public class ChallengeThreeUnitTest
    {
        [TestMethod]
        public void CreateNewBadge_ShouldNotGetNull()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            Badge addedBadge = new Badge(1111, new List<string>() { "A1" });
           
            badgeRepo.CreateNewBadge(addedBadge);
            Dictionary<int, List<string>> badgeDictionary = badgeRepo.ViewAllBadgesAndDoorAccess();
            
            Assert.IsNotNull(badgeDictionary);
        }
        [TestMethod]
        public void ViewAllBadgesAndDoorAccess_IsNotNull()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            
            Dictionary<int, List<string>> badgeDictionary = badgeRepo.ViewAllBadgesAndDoorAccess();
            
            Assert.IsNotNull(badgeDictionary);
        }
        [TestMethod]
        public void UpdateBadge()
        {
            BadgeRepository _badgeRepo = new BadgeRepository();
            Badge oldBadge = new Badge(1111, new List<string>() { "A1" });
            Badge newBadge = new Badge(1234, new List<string>() { "A2" });
           
            _badgeRepo.CreateNewBadge(oldBadge);
            bool updateBadge = _badgeRepo.UpdateBadge(newBadge.BadgeID, newBadge.DoorNames);
            
            Assert.IsTrue(updateBadge);
        }
        [TestMethod]
        public void RemoveBadge()
        {
            Badge addedBadge = new Badge(1111, new List<string>() { "A1" });
            BadgeRepository badgeRepo = new BadgeRepository();
            
            badgeRepo.CreateNewBadge(addedBadge);
            bool deleteBadge = badgeRepo.RemoveBadge(addedBadge.BadgeID);
            
            Assert.IsTrue(deleteBadge);
        }
    }
}
