using Confitec.Data;
using Confitec.Extensions;
using Confitec.Models;
using Confitec.ViewModels;
using Confitec.ResultViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase{

        [HttpGet("v1/usuarios")]
        public async Task<IActionResult> GetAsyc([FromServices]ConfitecDbContext context)
        {
            try
            {
                var usuarios = await context.Usuario.ToListAsync();
                return Ok(new ResultViewModel<List<Usuario>>(usuarios));
            }
            catch (DbUpdateException ex){
                return StatusCode(500, new ResultViewModel<List<Usuario>>("EXGCLI001 Não foi possível buscar todos os usuários! Favor contate o suporte"));
            }
            catch (Exception ex){
                return StatusCode(500, new ResultViewModel<List<Usuario>>("EXGCLI002 Erro interno do servidor! Favor contate o suporte"));
            }
            
        }

        [HttpGet("v1/usuarios/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices]ConfitecDbContext context, [FromRoute] int id)
        {

            try
            {
                var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario == null)
                return NotFound(new ResultViewModel<Usuario>("EXGCLI005 Não foi encontrado nenhum usuário com o código fornecido! Favor contate o suporte"));

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (DbUpdateException ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXGCLI003 Não foi possível buscar esse usuário! Favor contate o suporte"));
            }
            catch (Exception ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXGCLI004 Erro interno do servidor! Favor contate o suporte"));
            }
            
        }

        [HttpPost("v1/usuarios")]
        public async Task<IActionResult> CreateAsync([FromServices]ConfitecDbContext context, [FromBody] EditorUsuarioViewModel model)
        {

            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Usuario>(ModelState.GetErros()));

            try
            {
                var usuario = new Usuario()
                {
                    Id = 0,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    DataNascimento = model.DataNascimento,
                    EscolaridadeId = ((int)model.EscolaridadeType),
                    Email = model.Email
                };

                await context.Usuario.AddAsync(usuario);
                await context.SaveChangesAsync();

                return Created($"v1/Usuarios/{usuario.Id}", new ResultViewModel<Usuario>(usuario));

            }
            catch (DbUpdateException ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXCCLI001 Não foi possível incluir esse usuário! Favor contate o suporte"));
            }
            catch (Exception ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXCCLI002 Erro interno do servidor! Favor contate o suporte"));
            }
            
        }

        [HttpPut("v1/usuarios/{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromServices]ConfitecDbContext context, [FromBody] EditorUsuarioViewModel model,[FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Usuario>(ModelState.GetErros()));
                
             try
            {
                 var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            
                if (usuario == null)
                return NotFound(new ResultViewModel<Usuario>("EXUCLI003 Não foi encontrado nenhum usuário com o código fornecido! Favor contate o suporte"));

                usuario.Nome = model.Nome;
                usuario.Sobrenome = model.Sobrenome;
                usuario.DataNascimento = model.DataNascimento;
                usuario.EscolaridadeId = ((int)model.EscolaridadeType);
                usuario.Email = model.Email;

                context.Usuario.Update(usuario);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (DbUpdateException ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXUCLI001 Não foi possível atualizar esse usuário! Favor contate o suporte"));
            }
            catch (Exception ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXUCLI002 Erro interno do servidor! Favor contate o suporte"));
            }
            
        }

        [HttpDelete("v1/usuarios/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices]ConfitecDbContext context,[FromRoute] int id)
        {
            try
            {
                var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            
                if (usuario == null)
                return NotFound(new ResultViewModel<Usuario>("EXDCLI003 Não foi encontrado nenhum usuário com o código fornecido! Favor contate o suporte"));

                context.Usuario.Remove(usuario);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (DbUpdateException ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXDCLI001 Não foi possível incluir esse usuário! Favor contate o suporte"));
            }
            catch (Exception ex){
                return StatusCode(500, new ResultViewModel<Usuario>("EXDCLI002 Erro interno do servidor! Favor contate o suporte"));
            }
            
        }
    }
}