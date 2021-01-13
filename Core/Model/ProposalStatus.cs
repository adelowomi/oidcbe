namespace Core.Model
{
    public class ProposalStatus : BaseNameEntity
    {
       
    }

    public enum ProposalStatusEnum
    {
        PENDING = 1,
        APPROVED,
        DECLINED
    }
}
