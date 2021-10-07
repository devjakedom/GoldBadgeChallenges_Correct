using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepository
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueues = new Queue<Claim>();
       
        public void CreateNewClaim(Claim claim)
        {
            _claimQueues.Enqueue(claim);
        }
       
        public Queue<Claim> ViewAllClaims()
        {
            return _claimQueues;
        }
        
        public Claim DequeueClaim()
        {
            Claim dequeueClaim = _claimQueues.Dequeue();
            return dequeueClaim;
        }
        
        public Claim ViewFirstItem()
        {
            return _claimQueues.Peek();
        }
    }
}
