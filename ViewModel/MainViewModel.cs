using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace color.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        System.Timers.Timer timer;
        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                if (_labelText != value)
                {
                    _labelText = value;
                    OnPropertyChanged(nameof(LabelText));
                }
            }
        }
        private Color _upperLeft;
        public Color UpperLeft
        {
            get { return _upperLeft; }
            set
            {
                if (_upperLeft != value)
                {
                    _upperLeft = value;
                    OnPropertyChanged(nameof(UpperLeft));
                }
            }
        }
        private Color _upperCenter;
        public Color UpperCenter
        {
            get { return _upperCenter; }
            set
            {
                if (_upperCenter != value)
                {
                    _upperCenter = value;
                    OnPropertyChanged(nameof(UpperCenter));
                }
            }
        }
        private Color _upperRight;
        public Color UpperRight
        {
            get { return _upperRight; }
            set
            {
                if (_upperRight != value)
                {
                    _upperRight = value;
                    OnPropertyChanged(nameof(UpperRight));
                }
            }
        }

        private Color _centerLeft;
        public Color CenterLeft
        {
            get { return _centerLeft; }
            set
            {
                if (_centerLeft != value)
                {
                    _centerLeft = value;
                    OnPropertyChanged(nameof(CenterLeft));
                }
            }
        }

        private Color _centerCenter;
        public Color CenterCenter
        {
            get { return _centerCenter; }
            set
            {
                if (_centerCenter != value)
                {
                    _centerCenter = value;
                    OnPropertyChanged(nameof(CenterCenter));
                }
            }
        }
        private Color _centerRight;
        public Color CenterRight
        {
            get { return _centerRight; }
            set
            {
                if (_centerRight != value)
                {
                    _centerRight = value;
                    OnPropertyChanged(nameof(CenterRight));
                }
            }
        }

        private Color _lowerLeft;
        public Color LowerLeft
        {
            get { return _lowerLeft; }
            set
            {
                if (_lowerLeft != value)
                {
                    _lowerLeft = value;
                    OnPropertyChanged(nameof(LowerLeft));
                }
            }
        }
        private Color _lowerCenter;
        public Color LowerCenter
        {
            get { return _lowerCenter; }
            set
            {
                if (_lowerCenter != value)
                {
                    _lowerCenter = value;
                    OnPropertyChanged(nameof(LowerCenter));
                }
            }
        }
        private Color _lowerRight;
        public Color LowerRight
        {
            get { return _lowerRight; }
            set
            {
                if (_lowerRight != value)
                {
                    _lowerRight = value;
                    OnPropertyChanged(nameof(LowerRight));
                }
            }
        }

        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    OnPropertyChanged(nameof(IsToggled));

                    ToggleCommand.Execute(_isToggled);
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SpinCommand { get; }
        public ICommand ToggleCommand { get; }
        public MainViewModel()
        {
            LabelText = "Welcome to the Color Game!";
            SpinCommand = new RelayCommand(Spin);
            ToggleCommand = new RelayCommand<bool>(OnToggled);

            UpperLeft = Color.FromArgb("#FF0000");
            UpperCenter = Color.FromArgb("#008000");
            UpperRight = Color.FromArgb("#0000FF");
            CenterLeft = Color.FromArgb("#FFFF00");
            CenterCenter = Color.FromArgb("#800080");
            CenterRight = Color.FromArgb("#FFA500");
            LowerLeft = Color.FromArgb("#FFFFFF");
            LowerCenter = Color.FromArgb("#000000");
            LowerRight = Color.FromArgb("#808080");
        }

        private void Spin()
        {
            string[] colors = { "#FF0000", "#008000", "#0000FF", "#FFFF00", "#800080", "#FFA500", "#FFFFFF", "#000000", "#808080" };
            Random random = new Random();
            int index = random.Next(colors.Length);
            int index2 = random.Next(colors.Length);
            int index3 = random.Next(colors.Length);
            int index4 = random.Next(colors.Length);
            int index5 = random.Next(colors.Length);
            int index6 = random.Next(colors.Length);
            int index7 = random.Next(colors.Length);
            int index8 = random.Next(colors.Length);
            int index9 = random.Next(colors.Length);

            if (index == index2 && index == index3 && index2 == index3)
            {
                Win();
            }
            if (index4 == index5 && index4 == index6 && index5 == index6)
            {
                Win();
            }
            if (index7 == index8 && index7 == index9 && index8 == index9)
            {
                Win();
            }
            if (index2 == index5 && index2 == index8 && index5 == index8)
            {
                Win();
            }
            if (index == index4 && index == index7 && index4 == index7)
            {
                Win();
            }
            if (index3 == index6 && index3 == index9 && index6 == index9)
            {
                Win();
            }

            UpperLeft = Color.FromArgb(colors[index]);
            UpperCenter = Color.FromArgb(colors[index2]);
            UpperRight = Color.FromArgb(colors[index3]);
            CenterLeft = Color.FromArgb(colors[index4]);
            CenterCenter = Color.FromArgb(colors[index5]);
            CenterRight = Color.FromArgb(colors[index6]);
            LowerLeft = Color.FromArgb(colors[index7]);
            LowerCenter = Color.FromArgb(colors[index8]);
            LowerRight = Color.FromArgb(colors[index9]);
        }

       private async void Win()
        {
            LabelText = "You Win!";
            await Task.Delay(2000); // Wait for 2 seconds
            LabelText = string.Empty;
        }

        private void SpinOff()
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }

        private void SpinOn()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer(1000); // Set interval to 1 second
                timer.Elapsed += (s, e) => Spin();
                timer.AutoReset = true; // Repeat the function
            }
            timer.Start();
        }

        private void OnToggled(bool isOn)
        {
            if (isOn)
            {
                SpinOn();
            }
            else
            {
                SpinOff();
            }
        }
    }
}
