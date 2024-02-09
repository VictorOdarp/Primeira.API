using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using PrimeiraAPI.DataContext;
using PrimeiraAPI.Models;
using PrimeiraAPI.Services;
using PrimeiraAPI.Services.FuncionarioService;
using System.Security.AccessControl;

namespace PrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            var list = await _funcionarioInterface.GetFuncionarios();
            return Ok(list);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionariosById(int id)
        {
            var byId = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(byId);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionarios(FuncionarioModel create)
        {
            var novoFuncionario = await _funcionarioInterface.CreateFuncionarios(create);
            return Ok(novoFuncionario);
        }
        
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            var deleteFuncionario = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(deleteFuncionario);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel update)
        {
            var funcionario = await _funcionarioInterface.UpdateFuncionario(update);
            return Ok(funcionario);
        }

        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DataAlteracaoFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.DataAlteracaoFuncionario(id);
            return Ok(funcionario);
        }
    }
}
