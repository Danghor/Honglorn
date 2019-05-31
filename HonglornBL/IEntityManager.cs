namespace HonglornBL
{
    public interface IEntityManager<TModel>
    {
        void Update(TModel model);
    }
}