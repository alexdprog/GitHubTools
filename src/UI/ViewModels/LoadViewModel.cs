using AutoMapper;
using GitHubTools.CoreApplication.Interfaces;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Domain.Entities;
using GitHubTools.Infrastructure.Interfaces;
using Microsoft.OpenApi.Extensions;
using System.Windows.Input;

namespace GitHubTools.App.ViewModels
{
    public class LoadViewModel : BaseViewModel
    {
        private readonly IDataProvider _provider;
        private readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IOwnerRepository _ownerReposotiry;

        private string userName;
        public string _message;

        private bool _isConnectionSuccess;
        private bool _isConnectionFailure;

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName
        {
            get => userName; set => SetProperty(ref userName, value);
        }

        /// <summary>
        /// Sign query success.
        /// </summary>
        public bool IsConnectionSuccess
        {
            get => _isConnectionSuccess; set => SetProperty(ref _isConnectionSuccess, value);
        }

        /// <summary>
        /// Sign query fail.
        /// </summary>
        public bool IsConnectionFailure
        {
            get => _isConnectionFailure; set => SetProperty(ref _isConnectionFailure, value);
        }

        /// <summary>
        /// Status message.
        /// </summary>
        public string Message
        {
            get => _message; set => SetProperty(ref _message, value);
        }

        /// <summary>
        /// Load command.
        /// </summary>
        public ICommand OnLoadCommand { private set; get; }

        /// <summary>
        /// Clear command/
        /// </summary>
        public ICommand OnClearCommand { private set; get; }
         
        public LoadViewModel(
            IDataProvider dataProvider,
            IMapper autoMapper,
            IUnitOfWork unitOfWork)
        {
            _provider = dataProvider;
            _mapper = autoMapper;
            _unitOfWork = unitOfWork;
            _ownerReposotiry = _unitOfWork.OwnerRepository;
            
            OnLoadCommand = new Command(OnLoad);
            OnClearCommand = new Command(OnClear);
        }

        async void OnLoad()
        {
            UserProfile userProfile = new UserProfile()
            {
                UserName = this.UserName
            };

            var repositories = await _provider.LoadRepositories(userProfile);
            IsConnectionSuccess = repositories.Success;
            IsConnectionFailure = !_isConnectionSuccess;
            if (repositories.Success)
            {
                await _unitOfWork.Clear();
                
                if (repositories.Value.Count > 0)
                {
                    OwnerDb ownerDb = _mapper.Map<OwnerDb>(repositories.Value[0].owner);
                    await _ownerReposotiry.Add(ownerDb);
                    foreach (var item in repositories.Value)
                    {
                        var repDb = _mapper.Map<RepositoryDb>(item);
                        ownerDb.repositories.Add(repDb);
                    }
                }
                await _unitOfWork.Commit();
                Message = "Successfull";
            }
            else
            {
                Message = repositories.ConnectionResult.Status.GetDisplayName();
            }
        }

        async void OnClear()
        {
            await _unitOfWork.Clear();
        }

        public override Task Reload()
        {
            IsConnectionSuccess = false;
            IsConnectionFailure = false;
            return base.Reload();
        }
    }
}
