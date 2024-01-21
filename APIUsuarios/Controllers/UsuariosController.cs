using ApiUsuarios.DAO;
using ApiUsuarios.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("listarPorId")]
        public IActionResult ListarPorId(int id)
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.ListarUsuariosPorId(id);
            return Ok(usuarios);
        }



        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody]UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            dao.CadastrarUsuario(usuario);
            return Ok();
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            dao.AlterarUsuario(usuario);
            return Ok();
        }

        [HttpDelete]
        [Route("remover")]
        public IActionResult Remover([FromBody] UsuarioDTO usuario)
        {
            var dao = new UsuarioDAO();
            dao.RemoverUsuario(usuario);
            return Ok();
        }


        [HttpDelete]
        [Route("deletar")]
        public IActionResult Deletar(int id)
        {
            var dao = new UsuarioDAO();
            dao.RemoverUsuario(id);
            return Ok();
        }
    }
}   