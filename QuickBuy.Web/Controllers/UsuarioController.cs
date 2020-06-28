using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{

    [Route("api/[Controller]")]
    public class UsuarioController: Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
       

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest(err.ToString());
            }
        }

        [HttpPost("verificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                if(usuarioRetorno != null)
                {
                    return Ok(usuarioRetorno);
                }
                return BadRequest("Usuario ou senha inválido");
            }
            catch (Exception err)
            {
                return BadRequest(err.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _usuarioRepositorio.Obter(usuario.Email);
                if (usuarioCadastrado != null)
                    return BadRequest("Usuário já cadastrado no sistema.");

                _usuarioRepositorio.Adicionar(usuario);

                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.ToString());
            }
        }


    }
}
