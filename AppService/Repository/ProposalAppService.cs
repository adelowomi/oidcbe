using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace AppService.Repository
{
    public class ProposalAppService : ResponseViewModel, IProposalAppService
    {
        protected readonly IProposalRepository _proposalRepository;
        protected readonly IMapper _mapper;
        protected readonly IUserService _userService;
        protected readonly IJobRepository _jobRepository;

        public ProposalAppService(IProposalRepository proposalRepository, IMapper mapper, IUserService userService, IJobRepository jobRepository)
        {
            _proposalRepository = proposalRepository;
            _mapper = mapper;
            _userService = userService;
            _jobRepository = jobRepository;
        }

        public ResponseViewModel ApproveOrDisapprove(int statusId, int proposalId)
        {
            var result = _proposalRepository.GetProposalStatuses().FirstOrDefault(x => x.Id == statusId);

            if(result == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_STATUS, ResponseErrorCodeStatus.INVALID_STATUS) ;
            }

            var proposal = _proposalRepository.GetProposalBy(proposalId);

            if(proposal == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PROPOSAL, ResponseErrorCodeStatus.INVALID_PROPOSAL);
            }

            var saved = _proposalRepository.ApproveDisApprove(statusId, proposalId);

            return Ok(_mapper.Map<Proposal, ProposalViewModel>(saved));
        }

        public ResponseViewModel CreateProposalJob(ProposalInputModel proposal)
        {
            var job = _jobRepository.GetJobBy(proposal.JobId);

            if(job == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_JOB, ResponseErrorCodeStatus.INVALID_JOB);
            }

            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            var mappedResult = _mapper.Map<ProposalInputModel, Proposal>(proposal);

            mappedResult.ProposalStatusId = (int)ProposalStatusEnum.PENDING;

            mappedResult.AppUserId = user.Id;

            var result = _mapper.Map<Proposal, ProposalViewModel>(_proposalRepository.CreateProposal(mappedResult));

            return Ok(result);
        }

        public ResponseViewModel GetAllProposals()
        {
            var result = _proposalRepository.GetProposals().Select(_mapper.Map<Proposal, ProposalViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetProposalBy(int id)
        {
            return Ok(_mapper.Map<Proposal, ProposalViewModel>(_proposalRepository.GetProposalBy(id)));
        }

        public ResponseViewModel GetProposalBy(int id, int jobId)
        {
            var result = _proposalRepository.GetProposals().Where(x => x.JobId == jobId).Select(_mapper.Map<Proposal, ProposalViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetProposalStatuses()
        {
            var results = _proposalRepository.GetProposalStatuses()
                        .Select(_mapper.Map<ProposalStatus, ProposalStatusViewModel>);
            return Ok(results);
        }

        public ResponseViewModel UpdateProposal(ProposalInputModel proposal)
        {
            return Ok(_mapper.Map<Proposal, ProposalViewModel>(_proposalRepository.UpdateProposal(
                    _mapper.Map<ProposalInputModel, Proposal>(proposal)
                )));
        }
    }
}
