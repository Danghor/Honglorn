using System.Windows.Forms;

namespace HonglornBL.Interfaces
{
    public interface IProgressInformer
    {
        ProgressBarStyle Style { get; }
        string StatusMessage { get; }
    }
}