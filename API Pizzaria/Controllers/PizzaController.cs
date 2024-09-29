using API_Pizzaria.Dto;
using Microsoft.AspNetCore.Mvc;
using API_Pizzaria.Models;
using API_Pizzaria.Services.Pizza;

namespace API_Pizzaria.Controllers
{
	public class PizzaController : Controller
	{
		private readonly IPizzaInterface _pizzaInterface;

		public PizzaController(IPizzaInterface pizzaInterface)
        { 
			_pizzaInterface = pizzaInterface;
		}

        public async Task<IActionResult> Index()
		{
			var pizza = await _pizzaInterface.GetPizzas();
			return View(pizza);
		}

		public IActionResult Cadastrar()
		{
			return View();
		}

		public async Task<IActionResult> Detalhes(int id)
		{
			var pizza = await _pizzaInterface.GetPizzaPorId(id);
			return View(pizza);
		}

		public async Task<IActionResult> Editar(int id)
		{
			var pizza = await _pizzaInterface.GetPizzaPorId(id);
			return View(pizza);
		}

		public async Task<IActionResult> Remover(int id)
		{
			var pizza = await _pizzaInterface.RemoverPizza(id);
			return RedirectToAction("Index", "Pizza");
		}
			

		[HttpPost]
		public async Task<IActionResult> Cadastrar(PizzaCriacaoDto pizzaCriacaoDto, IFormFile foto)
		{
			if(ModelState.IsValid)
			{
				var pizza = await _pizzaInterface.CriarPizza(pizzaCriacaoDto, foto);
			    return RedirectToAction("Index", "Pizza");
			}
			else
			{
				return View(pizzaCriacaoDto);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Editar(PizzaModel pizzaModel, IFormFile foto)
		{
			if (ModelState.IsValid)
			{
				var pizza = await _pizzaInterface.EditarPizza(pizzaModel, foto);
				return RedirectToAction("Index", "Pizza");
			}
			else
			{
				return View(pizzaModel);
			}
        }
	}
}
