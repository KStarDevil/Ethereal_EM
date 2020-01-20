namespace Ethereal_EM.Repository
{
    public interface ICarRepo:IRepositoryBase <CarRepo>
    {
        dynamic ShowCar(int id);
        dynamic ShowCarByID(int id);
    }
}