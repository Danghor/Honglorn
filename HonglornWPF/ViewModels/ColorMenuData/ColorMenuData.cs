using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;

namespace HonglornWPF.ViewModels.ColorMenuData
{
    [DebuggerDisplay("{Name} {BorderColorBrush} {FillColorBrush}")]
    abstract class ColorMenuData
    {
        public string Name { get; }
        public Brush BorderColorBrush { get; }
        public Brush FillColorBrush { get; }
        public ICommand ChangeColorCommand { get; }

        protected ColorMenuData(string name, Brush borderColorBrush, Brush fillColorBrush)
        {
            Name = name;
            BorderColorBrush = borderColorBrush;
            FillColorBrush = fillColorBrush;
            ChangeColorCommand = new RelayCommand(ChangeColor);
        }

        protected abstract void ChangeColor();
    }
}