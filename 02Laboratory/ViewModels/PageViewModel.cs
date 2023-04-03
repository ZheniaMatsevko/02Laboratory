using _02Laboratory.Models;
using _02Laboratory.Services;
using _02Laboratory.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _02Laboratory.ViewModels
{
    class PageViewModel : INotifyPropertyChanged
    {
        private Person _user = new Person();
        private RelayCommand<object> _proceedCommand;
        private DateTime? _chosenDate;
        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        public string FirstName
        {
            get { return _user.FirstName; }
            set { _user.FirstName = value; }
        }

        public string LastName
        {
            get { return _user.LastName; }
            set { _user.LastName = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        private bool CanExecute(object obj)
        {
            return _chosenDate!=null && !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(Email);
        }

        private async void Proceed()
        {
            if (!WorkWithDate.checkDate(_chosenDate.Value))
            {
                MessageBox.Show("Wrong date! The year must be between 1900 and 2023.");
                return;
            }
            _user.DateOfBirth = _chosenDate.Value;

            await Task.Run(() => doAsyncOperation());

            if (_chosenDate.Value.Day == DateTime.Today.Day && _chosenDate.Value.Month == DateTime.Today.Month)
                MessageBox.Show("Happy birthday!!!");
        }

     

        private void doAsyncOperation()
        {
            _user.Proceed();
            showInfo();
            WestZodiacSign = _user.SunSign.ToString();
            ChineseZodiacSign = _user.ChineseSign.ToString();
            IsAdult = _user.IsAdult.ToString();
            IsBirthday = _user.IsBirthday.ToString();
        
        }

        public string DateOfBirth
        {
            get { return (_user.SunSign == WestZodiacSigns.None) ? "" : _user.DateOfBirth.ToShortDateString(); }
            set
            {
                OnPropertyChanged();
            }
        }

        public string WestZodiacSign
        {
            get
            {
                return (_user.SunSign == WestZodiacSigns.None) ? "" : _user.SunSign.ToString();
            }
            set
            {
                OnPropertyChanged();
            }
        }

        public string IsAdult
        {
            get { return (_user.ChineseSign == ChineseZodiacSigns.None) ? "" : _user.IsAdult.ToString(); }
            set { OnPropertyChanged(); }
        }
        public string IsBirthday
        {
            get { return (_user.ChineseSign == ChineseZodiacSigns.None) ? "" : _user.IsBirthday.ToString(); }
            set { OnPropertyChanged(); }
        }

        public string ChineseZodiacSign
        {
            get { return (_user.ChineseSign == ChineseZodiacSigns.None) ? "" : _user.ChineseSign.ToString(); }
            set
            {
                OnPropertyChanged();
            }
        }

        public DateTime? ChosenDate
        {
            get
            {
                return _chosenDate ??= DateTime.Today;
            }
            set
            {
                if (_chosenDate.Value.CompareTo(value) != 0)
                    _chosenDate = value.Value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void showInfo()
        {
            OnPropertyChanged("FirstName");
            OnPropertyChanged("LastName");
            OnPropertyChanged("DateOfBirth");
            OnPropertyChanged("Email");
        }
    }
}
