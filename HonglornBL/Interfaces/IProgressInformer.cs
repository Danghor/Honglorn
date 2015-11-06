namespace HonglornBL.Interfaces {
  public interface IProgressInformer {
    bool Finished { get; set; }
    long Maximum { get; set; }
    long Current { get; set; }
    string StatusMessage { get; set; }
  }
}