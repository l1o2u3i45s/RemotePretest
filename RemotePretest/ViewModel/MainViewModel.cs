using DomainModel;
using DomainModel.Ticket;
using DomainModel.User;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InfraStructure;

namespace RemotePretest.ViewModel
{ 
    public class MainViewModel : ViewModelBase
    {
       
        private BugInvokeService _bugInvokeService;


        private UserType _selectedUserType;

        public UserType SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                Set(()=>SelectedUserType, ref _selectedUserType, value);
                UpdateUser(_selectedUserType, _selectedTicketType); 
            } 
        }

        private TicketType _selectedTicketType;

        public TicketType SelectedTicketType
        {
            get { return _selectedTicketType; }
            set
            {
                Set(() => SelectedTicketType, ref _selectedTicketType, value);
                UpdateUser(_selectedUserType, _selectedTicketType);
            }
        }
        
        private bool _isEnableCreate;

        public bool IsEnableCreate
        {
            get { return _isEnableCreate; }
            set  { Set(() =>  IsEnableCreate,ref _isEnableCreate, value ); }
        }

        private bool _isEnableDelete;

        public bool IsEnableDelete
        {
            get { return _isEnableDelete; }
            set { Set(() => IsEnableDelete, ref _isEnableDelete, value); }
        }

        private bool _isEnableEdit;

        public bool IsEnableEdit
        {
            get { return _isEnableEdit; }
            set { Set(() => IsEnableEdit, ref _isEnableEdit, value); }
        }

        private bool _isEnableResolved;

        public bool IsEnableResolved
        {
            get { return _isEnableResolved; }
            set { Set(() => IsEnableResolved, ref _isEnableResolved, value); }
        }

        private string _summaryData;

        public string SummaryData
        {
            get { return _summaryData; }
            set { Set(() => SummaryData, ref _summaryData, value); }
        }

        private string _descriptionData;

        public string DescriptionData
        {
            get { return _descriptionData; }
            set { Set(() => DescriptionData, ref _descriptionData, value); }
        }

        public RelayCommand CreateCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand ResolveCommand { get; set; }

        public MainViewModel()
        {
            SelectedUserType = UserType.QA;
            SelectedTicketType = TicketType.Bug;
            CreateCommand = new RelayCommand(CreateAction);
            EditCommand = new RelayCommand(EditAction);
            DeleteCommand = new RelayCommand(DeleteAction);
            ResolveCommand = new RelayCommand(ResolveAction);
        }

        private void CreateAction()
        {
            _bugInvokeService.ExecuteCreateTicket( _summaryData, _descriptionData);
        }

        private void EditAction()
        {
            _bugInvokeService.ExecuteEditTicket(_summaryData, _descriptionData);
        }

        private void DeleteAction()
        {
            _bugInvokeService.ExecuteDeleteTicket( );
        }

        private void ResolveAction()
        {
            _bugInvokeService.ExecuteResolvedTicket();
        }
         
        private void UpdateUser(UserType usertype,TicketType tickettype)
        { 
            _bugInvokeService = new BugInvokeService(UserFactory.CreateUser(usertype), TicketFactory.Create(tickettype));
            UpdateAuthoriyUI();
        }

        private void UpdateAuthoriyUI()
        {
             

            IsEnableCreate = _bugInvokeService.IsEnableCreate();
            IsEnableEdit = _bugInvokeService.IsEnableEdit();
            IsEnableDelete = _bugInvokeService.IsEnableDelete();
            IsEnableResolved = _bugInvokeService.IsEnableResolve();
        }
    }
}