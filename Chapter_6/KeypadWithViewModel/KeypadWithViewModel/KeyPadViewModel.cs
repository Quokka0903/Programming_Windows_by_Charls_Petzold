﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KeypadWithViewModel
{
    class KeyPadViewModel : INotifyPropertyChanged
    {
        string inputString = "";
        string displayText = "";
        char[] specialChars = { '*', '#' };

        public event PropertyChangedEventHandler PropertyChanged;

        //생성자
        public KeyPadViewModel()
        {
            this.AddCharacterCommand = new DelegateCommand(ExecuteAddCharacter);
            this.DeleteCharacterCommand = new DelegateCommand(ExecuteDeleteCharacter, CanExecuteDeleteCharacter);
        }

        //공용 속성
        public string InputString
        {
            protected set
            {
                bool previousCanExecuteDeleteChar = this.CanExecuteDeleteCharacter(null);

                if (this.SetProperty<string>(ref inputString, value))
                {
                    this.DisplayText = FormatText(inputString);

                    if (previousCanExecuteDeleteChar != this.CanExecuteDeleteCharacter(null))
                        this.DeleteCharacterCommand.RaiseCanExecuteChanged();
                }
            }

            get
            {
                return inputString;
            }
        }

        public string DisplayText
        {
            protected set { this.SetProperty<string>(ref displayText, value);  }
            get { return displayText; }
        }


        // ICommand 구현
        public IDelegateCommand AddCharacterCommand { protected set; get; }
        public IDelegateCommand DeleteCharacterCommand { protected set; get; }
        
        //Execute와 CanExecute
        void ExecuteAddCharacter(object param)
        {
            this.InputString += param as string;
        }

        void ExecuteDeleteCharacter(object param)
        {
            this.InputString = this.InputString.Substring(0, this.InputString.Length - 1);
        }

        bool CanExecuteDeleteCharacter(object param)
        {
            return this.InputString.Length > 0;
        }

        //InputString에서 불리는 전용 메서드
        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}", str.Substring(0, 3), str.Substring(3));
            }
            else
            {
                formatted = String.Format("({0}) {1}-{2}", str.Substring(0, 3), str.Substring(3, 3), str.Substring(6));
            }

            return formatted;
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
