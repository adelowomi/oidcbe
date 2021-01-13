using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IProposalAppService
    {
        ResponseViewModel GetAllProposals();

        ResponseViewModel GetProposalBy(int id);

        ResponseViewModel CreateProposalJob(ProposalInputModel proposal);

        ResponseViewModel UpdateProposal(ProposalInputModel proposal);

        ResponseViewModel GetProposalStatuses();

        ResponseViewModel ApproveOrDisapprove(int statusId, int proposalId);
    }
}
