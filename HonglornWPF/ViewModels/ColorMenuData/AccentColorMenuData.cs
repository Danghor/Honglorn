using MahApps.Metro;
using System.Windows;
using System.Windows.Media;

namespace HonglornWPF.ViewModels.ColorMenuData
{
    class AccentColorMenuData : ColorMenuData
    {
        public AccentColorMenuData(string name, Brush borderColorBrush, Brush fillColorBrush) : base(name, borderColorBrush, fillColorBrush) { }

        protected override void ChangeColor()
        {
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Name), ThemeManager.DetectAppStyle(Application.Current).Item1);
        }
    }
}