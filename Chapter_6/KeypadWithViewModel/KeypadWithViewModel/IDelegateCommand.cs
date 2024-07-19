using System.Windows.Input;

namespace KeypadWithViewModel
{
    interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
