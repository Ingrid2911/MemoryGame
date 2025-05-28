using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryWPF.Model
{
    public class CardModel : BaseClass
    {
        private bool _isFlipped;
        private bool _isMatched;
        private string _imagepath; 
        private string _backimage; 
        public CardModel(bool isFlipped, bool isMatched, string imagePath)
        {
            string imageFolder = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Images");
            _backimage = Path.Combine(imageFolder, "guess_card.jpeg");
            _isFlipped = isFlipped;
            _isMatched = isMatched;
            _imagepath = imagePath;
        }
        public string ImagePath
        {
            get
            {
                if (!IsFlipped)
                {
                    return _backimage;
                }
                return _imagepath;
            }
            set
            {
                _backimage = value;
                OnPropertyChanged();
            }
        }
        public string RealImage
        {
            get { return _imagepath; }
            set
            {
                _imagepath = value;
                OnPropertyChanged();
            }
        }

        public bool IsFlipped
        {
            get => _isFlipped;
            set
            {
                if (_isFlipped != value)
                {
                    _isFlipped = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ImagePath)); 
                }
            }
        }

        public bool IsMatched
        {
            get => _isMatched;
            set
            {
                _isMatched = value;
                OnPropertyChanged();
            }
        }
    }
}
