using System.Windows.Forms;

namespace HonglornBL.Interfaces {
  public interface IProgressInformer {
    ProgressBarStyle Style { get; set; }
    string StatusMessage { get; set; }
  }
}