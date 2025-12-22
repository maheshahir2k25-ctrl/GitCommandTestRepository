using MVVM.Model;
using MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{

    //public class UserViewModel : INotifyPropertyChanged
    //{
    //    private User _user = new User();

    //    public UserViewModel()
    //    {
    //        _user = new User { FirstName = "Anand", LastName = "Jadhav" };
    //    }

    //    public string FirstName
    //    {
    //        get { return _user.FirstName; }
    //        set
    //        {
    //            if (_user.FirstName != value)
    //            {
    //                _user.FirstName = value;
    //                OnPropertyChanged();
    //                OnPropertyChanged("FullName"); // Notify that FullName changed too!
    //            }
    //        }
    //    }

    //    public string LastName
    //    {
    //        get { return _user.LastName; }
    //        set
    //        {
    //            if (_user.LastName != value)
    //            {
    //                _user.LastName = value;
    //                OnPropertyChanged();
    //                OnPropertyChanged("FullName");
    //            }
    //        }
    //    }

    //    // --- CHECK THIS SECTION CAREFULLY ---
    //    public string FullName
    //    {
    //        get { return $"{_user.FirstName} {_user.LastName}"; }
    //    }
    //    // ------------------------------------

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void OnPropertyChanged([CallerMemberName] string name = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //    }
    //}

    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user = new User();
        public ICommand ClearNameCommand { get; }
        public UserViewModel()
        {
            // Initialize with some dummy data
            //_user = new User { FirstName = "Anand", LastName = "Jadhav" };
            // Pattern: new RelayCommand(TheMethodToRun, OptionalCondition)
            ClearNameCommand = new RelayCommand(ClearMethod, CanClear);
        }
        public string FirstName
        {
            get { return _user.FirstName; }
            set
            {
                if (_user.FirstName != value)
                {
                    _user.FirstName = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get { return _user.LastName; }
            set
            {
                if (_user.LastName != value)
                {
                    _user.LastName = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get { return $"{_user.FirstName} {_user.LastName}"; }
        }

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set
            {
                if (_isFocused != value)
                {
                    _isFocused = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        // --- STEP 3: The Actual Logic ---
        private void ClearMethod(object obj)
        {
            FirstName = "";
            LastName = "";
            // Because your Setters define OnPropertyChanged, the UI clears instantly!
            IsFocused = true; // Set focus to the FirstName TextBox after clearing
            IsFocused = false; // Reset the focus flag
        }

        private bool CanClear(object obj)
        {
            return !string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName);

        }
    }
}
