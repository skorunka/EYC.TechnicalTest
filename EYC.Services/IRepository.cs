namespace EYC.Services
{
	public interface IRepository<out T>
	{
		T Find(string productId);
	}
}