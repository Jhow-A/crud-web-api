using CrudWebApi.DAL;
using CrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CrudWebApi.Controllers
{
    public class TipoProdutoController : ApiController
    {
        // Método responsável por listar todos os tipos e seus produtos
        public IHttpActionResult Get()
        {
            return Ok(new TipoProdutoDAO().Listar());
        }

        // Método responsável por consultar os produtos de um tipo
        public IHttpActionResult Get(int id)
        {
            try
            {
                TipoProdutoDAO dao = new TipoProdutoDAO();
                TipoProduto TipoProduto = dao.Consultar(id);

                // StatusCode 200
                return Ok(TipoProduto);
            }
            // Captura a excessão de chave não encontrada
            catch (KeyNotFoundException)
            {
                // StatusCode 404
                return NotFound();
            }
        }

        // [FromBody]: recebe o conteúdo para ser inserido no corpo da requisição
        public IHttpActionResult Post([FromBody] TipoProduto TipoProduto)
        {
            try
            {
                TipoProdutoDAO dao = new TipoProdutoDAO();
                dao.Inserir(TipoProduto);

                // Cria uma propriedade para efetuar a consulta da informação cadastrada
                string location = Url.Link("DefaultApi", new { controller = "tipoproduto", id = TipoProduto.IdTipo });

                // StatusCode 201
                return Created(new Uri(location), TipoProduto);
            }
            catch (Exception)
            {
                // StatusCode 400
                return BadRequest();
            }
        }

        // Método responsável por deletar um recurso
        public IHttpActionResult Delete(int id)
        {
            try
            {
                TipoProdutoDAO dao = new TipoProdutoDAO();
                dao.Excluir(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // Método responsável por atualizar um recurso
        public IHttpActionResult Put([FromBody] TipoProduto tipoProduto)
        {
            try
            {
                TipoProdutoDAO dao = new TipoProdutoDAO();
                dao.Alterar(tipoProduto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
