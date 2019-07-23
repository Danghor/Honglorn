namespace HonglornBL
{
    public interface IEntityManager<in TModel>
    {
        void Update(TModel model);
    }
}