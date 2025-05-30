﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MemoryWPF.Model;

namespace MemoryWPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            AboutMe = new RelayCommand(About);
            _loginView = new LoginView();
            if (_loginView.DataContext is LoginViewModel vm)
            {
                vm.LoggedIn += OnLoggedIn;
            }
            CurrentView = _loginView;
        }
        private void OnLoggedIn(UserModel user)
        {
            UserPageView userPage = new UserPageView(user);
            ((UserPageViewModel)userPage.DataContext).ExitAction += ExitUserPage;

            CurrentView= userPage;
        }
        private void ExitUserPage()
        {
            CurrentView = _loginView;
        }

        private void About(object obj)
        {
            MessageBox.Show("Email:ingrid.mihaita@student.unitbv.ro\nNume:Mihăiță Ingrid Anamaria \nGrupa:10LF233");
        }

        private object _currentView;
        private LoginView _loginView;
        public ICommand AboutMe { get; }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
