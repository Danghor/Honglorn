using HonglornWPF.ViewModels.ColorMenuData;
using MahApps.Metro;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace HonglornWPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public IEnumerable<AppThemeMenuData> AppThemes { get; }
        public IEnumerable<AccentColorMenuData> AccentColors { get; }

        public MainWindowViewModel()
        {
            AppThemes = ThemeManager.AppThemes.Select(a => new AppThemeMenuData(a.Name, (Brush)a.Resources["BlackColorBrush"], (Brush)a.Resources["WhiteColorBrush"]));
            AccentColors = ThemeManager.Accents.Select(a => new AccentColorMenuData(a.Name, null, (Brush)a.Resources["AccentColorBrush"]));
        }
    }
}