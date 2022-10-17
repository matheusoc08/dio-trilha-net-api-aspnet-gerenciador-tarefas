using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_trilha_net_api_aspnet_gerenciador_tarefas.Context;
using dio_trilha_net_api_aspnet_gerenciador_tarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace dio_trilha_net_api_aspnet_gerenciador_tarefas.Controllers
{
    public class OrganizadorController : Controller
    {
        private readonly OrganizadorContext _context;

        public OrganizadorController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();

            return View(tarefas);
        }

        [HttpGet("Titulo")]
        public IActionResult Index(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            return View(tarefas);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Tarefa tarefa)
        {

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Novo));
        }

        public IActionResult Editar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            return View(tarefaBanco);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            return View(tarefaBanco);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}