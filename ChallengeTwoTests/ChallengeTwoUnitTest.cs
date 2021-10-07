using ChallengeTwoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ChallengeTwoUnitTest
    {
        [TestMethod]
        public void CreateNewClaim_ShouldNotGetNull()
        {            
            ClaimRepository claimRepo = new ClaimRepository();
            DateTime claimIncidentDate = new DateTime(1987, 06, 21);
            Claim createdClaim = new Claim("666", ClaimType.Car, "t-bone", "$7000", claimIncidentDate, claimIncidentDate, true);
            
            claimRepo.CreateNewClaim(createdClaim);
            Queue<Claim> claimsFromQueue = claimRepo.ViewAllClaims();
            
            Assert.IsNotNull(claimsFromQueue);
        }
        [TestMethod]
        public void ViewAllClaims_IsNotNull()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            
            Queue<Claim> claimsQueue = claimRepo.ViewAllClaims();
            
            Assert.IsNotNull(claimsQueue);
        }
        [TestMethod]
        public void ViewFirstItem()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            DateTime claimIncidentDate = new DateTime(2020, 12, 10);
            Claim addedClaim = new Claim("666", ClaimType.Car, "t-bone", "$7000", claimIncidentDate, claimIncidentDate, true);
            claimRepo.CreateNewClaim(addedClaim);
            
            Claim viewFirstItem = claimRepo.ViewFirstItem();
            
            Assert.AreEqual(addedClaim, viewFirstItem);
        }
    }
}
