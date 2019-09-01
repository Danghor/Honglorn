using System;
using System.Windows.Controls;

namespace HonglornWPF.Views.MasterData
{
    /// <summary>
    /// Interaction logic for ClassListView.xaml
    /// </summary>
    public partial class ClassListView : UserControl
    {
        public ClassListView()
        {
            InitializeComponent();
            Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
        }

        private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}
