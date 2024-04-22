using mf_dev_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context; //conteudo do banco de dados
        public VeiculosController(AppDbContext context) //Recebe o conteudo da minha aplicação (Incluir, Apagar, Atualizar)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() //Pagina
        {
            var dados = await _context.Veiculos.ToListAsync(); //Pegando todos os dados da tabela veiculos de forma assincrona

            return View(dados); //Exibindo os dados
        }

        public IActionResult Create() //Get (Adiciona Veiculo)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)//Setter 
        {
            if (ModelState.IsValid) //Se o modelo de dados for válido
            {
                _context.Veiculos.Add(veiculo); //Adiciona na minha lista veiculos na memoria.
                await _context.SaveChangesAsync(); //Salvar no banco
                return RedirectToAction("Index"); //Retorna pra minha tela de Index (listagem de veiculos)
            }
            return View(veiculo);
        }

        public async Task<IActionResult> Edit(int? id) //Get (Edita Veiculo)
        {
            if(id == null) // Se o ID for nulo
            {
                return NotFound(); // ID não encontrado
            }

            var dados = await _context.Veiculos.FindAsync(id);

            if(dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo) //Setter (Edita Veiculo)
        {

            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid) //Se o modelo de dados for válido
            {
                _context.Veiculos.Update(veiculo); //Faz um update
                await _context.SaveChangesAsync(); //Salvar no banco
                return RedirectToAction("Index"); //Retorna pra minha tela de Index (listagem de veiculos)
            }


            return View();
        }
    }
}
