using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IProposalRepository
    {
        Proposal CreateProposal(Proposal proposal);

        Proposal UpdateProposal(Proposal proposal);

        Proposal GetProposalBy(int id);

        IEnumerable<Proposal> GetProposals();

    }
}
