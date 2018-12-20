using MahApps.Metro;
using System.Windows;
using System.Windows.Media;

namespace HonglornWPF.ViewModels.ColorMenuData
{
    class AppThemeMenuData : ColorMenuData
    {
        public AppThemeMenuData(string name, Brush borderColorBrush, Brush fillColorBrush) : base(name, borderColorBrush, fillColorBrush) { }

        protected override void ChangeColor()
        {
            ThemeManager.ChangeAppTheme(Application.Current, Name);
        }
    }
}