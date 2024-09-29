using API_Pizzaria.Models;
using API_Pizzaria.Dto;


namespace API_Pizzaria.Services.Pizza
{
	public interface IPizzaInterface
	{
		Task<PizzaModel> CriarPizza(PizzaCriacaoDto pizzaCriacaoDto, IFormFile foto);
		Task<List<PizzaModel>> GetPizzas();
		Task<PizzaModel> GetPizzaPorId(int id);
		Task<PizzaModel> EditarPizza(PizzaModel pizza, IFormFile? foto);
		Task<PizzaModel> RemoverPizza(int id);
		Task<List<PizzaModel>> GetPizzasFiltro(string? pesquisar);
	}
}
