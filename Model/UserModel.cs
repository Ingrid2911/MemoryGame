﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryWPF.Model
{
    public class UserModel : BaseClass
    {
        public string ImagePath { get; set; }
        private int _gamesPlayed;
        private int _gamesWon;
        private String _name;
        public UserModel(string name, string imagePath)
        {
            _name = name;
            ImagePath = imagePath;
            GamesWon = 0;
            GamesPlayed = 0;
        }
        public int GamesPlayed { 
            get
            {
                return _gamesPlayed;
            } 
            set
            {
                _gamesPlayed = value;
                OnPropertyChanged();
            } 
        }
        public int GamesWon
        {
            get
            {
                return _gamesWon;
            }
            set
            {
                _gamesWon = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public void Save()
        {
            string fileName = Name + "User.json";
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}
