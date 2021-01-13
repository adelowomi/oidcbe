using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
    {
        protected readonly AppDbContext context;

        public ProposalRepository(AppDbContext context) : base(context)
        {

        }

        public Proposal ApproveDisApprove(int statusId, int proposalId)
        {
            var proposal = GetProposalBy(proposalId);

            proposal.ProposalStatusId = statusId;

            Save();

            return proposal;

        }

        public Proposal CreateProposal(Proposal proposal)
        {
            var result = CreateAndReturn(proposal);

            return GetProposalBy(result.Id);
        }

        public Proposal GetProposalBy(int id)
        {
            return GetProposals().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Proposal> GetProposals()
        {
            var results = _context.Proposals.
                Include(x => x.AppUser)
                .Include(x => x.Job)
                .Include(x => x.ProposalStatus)

                ;

            return results;
        }

        public IEnumerable<ProposalStatus> GetProposalStatuses()
        {
            return _context.ProposalStatuses.ToList();
        }

        public Proposal UpdateProposal(Proposal proposal)
        {
            var result = Update(proposal);

            return GetById(result.Id);
        }
    }
}
