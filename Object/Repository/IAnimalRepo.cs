using Animals_Web.Object;


namespace Animals_Web.Object.Repository
{
    public interface IAnimalRepo
    {
        Task<List<Animal>> GetAllAsync();

        Task<List<Animal>> GetAnimalsUnderAge20();

        Task<List<Animal>> GetUsernameNameStartB();

        Task<List<Animal>> GetIdNrPar();




    }
}
