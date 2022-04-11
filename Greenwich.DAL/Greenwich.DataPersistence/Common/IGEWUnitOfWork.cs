using Greenwich.DataPersistence.IRepositories;

namespace Greenwich.DataPersistence.Common
{
    public interface IGEWUnitOfWork : IDisposable
    {
        Task<int> SaveChangeAsync();
        int SaveChange();

        IDepartmentRepository DepartmentRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }             
        IIdeaRepository IdeaRepository { get; }
        IFileSubmissionRepository FileSubmissionRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }
        IReplyRepository ReplyRepository { get; }
        IViewMonitoringRepository ViewMonitoringRepository { get; }
        IReactionRepository ReactionRepository { get; }
    }
}
