using Greenwich.DataPersistence.IRepositories;
using Greenwich.DataPersistence.Repositories;
using Greenwich.EntityFramework;

namespace Greenwich.DataPersistence.Common
{
    public class GEWUnitOfWork : IGEWUnitOfWork
    {
        #region Constructor

        private readonly GEWDbcontext _dbContext;

        public GEWUnitOfWork(GEWDbcontext dbcontext)
        {
            _dbContext = dbcontext;
        }

        #endregion

        #region Public Functions

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        #endregion

        private IDepartmentRepository _departmentRepository;
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_dbContext);
                return _departmentRepository;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        private IUserRoleRepository _userRoleRepository;
        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(_dbContext);
                return _userRoleRepository;
            }
        }

        private IIdeaRepository _IdeaRepository;
        public IIdeaRepository IdeaRepository
        {
            get
            {
                if (_IdeaRepository == null)
                    _IdeaRepository = new IdeaRepository(_dbContext);
                return _IdeaRepository;
            }
        }


        private ISubmissionRepository _submissionRepository;
        public ISubmissionRepository SubmissionRepository
        {
            get
            {
                if (_submissionRepository == null)
                    _submissionRepository = new SubmissionRepository(_dbContext);
                return _submissionRepository;
            }
        }


        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_dbContext);
                return _categoryRepository;
            }
        }

        private IFileSubmissionRepository _fileSubmissionRepository;
        public IFileSubmissionRepository FileSubmissionRepository
        {
            get
            {
                if (_fileSubmissionRepository == null)
                    _fileSubmissionRepository = new FileSubmissionRepository(_dbContext);
                return _fileSubmissionRepository;
            }
        }

        private ICommentRepository _commentRepository;
        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_dbContext);
                return _commentRepository;
            }
        }

        private IReplyRepository _replyRepository;
        public IReplyRepository ReplyRepository
        {
            get
            {
                if (_replyRepository == null)
                    _replyRepository = new ReplyRepository(_dbContext);
                return _replyRepository;
            }
        }

        private IViewMonitoringRepository _viewMonitoringRepository;
        public IViewMonitoringRepository ViewMonitoringRepository
        {
            get
            {
                if (_viewMonitoringRepository == null)
                    _viewMonitoringRepository = new ViewMonitoringRepository(_dbContext);
                return _viewMonitoringRepository;
            }
        }

        private IReactionRepository _reactionRepository;
        public IReactionRepository ReactionRepository
        {
            get
            {
                if (_reactionRepository == null)
                    _reactionRepository = new ReactionRepository(_dbContext);
                return _reactionRepository;
            }
        }

        #region Dispose Handler

        private bool _isDispose;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDispose && disposing)
            {
                _dbContext.Dispose();
            }

            _isDispose = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
