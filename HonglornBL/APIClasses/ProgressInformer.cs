using System.Windows.Forms;
using HonglornBL.Interfaces;

namespace HonglornBL.APIClasses
{
    class ProgressInformer : IProgressInformer
    {
        public ProgressBarStyle Style { get; set; }
        public string StatusMessage { get; set; }
    }
}