﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MemoryWPF.Model;
namespace MemoryWPF.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public GameView(UserModel user)
        {
            InitializeComponent();
            this.Data = new GameViewModel(user);
            Data.GameEnded += OnGameEnded;
            this.DataContext = Data;
        }
        public GameView(int rows, int columns,string selectedCategory, int time, UserModel user)
        {
            InitializeComponent();
            this.Data = new GameViewModel(rows,columns,selectedCategory,time,user);
            Data.GameEnded += OnGameEnded;
            this.DataContext = Data;
        }
        public GameViewModel Data { get; set; }
        private void OnGameEnded()
        {
            this.Close();
        }
    }
}
