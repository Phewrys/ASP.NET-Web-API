using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public IEnumerable<Aluno> Get()
        {
            //Models.Alunos aluno = new Models.Alunos();
            Aluno aluno = new Aluno();

            return aluno.ListarAluno();
        }

        // GET: api/Aluno/5
        public Aluno Get(int id)
        {
            Aluno aluno = new Aluno();

            return aluno.ListarAluno().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Aluno> Post(Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            _aluno.Inserir(aluno);

            return _aluno.ListarAluno();
        }

        // PUT: api/Aluno/5
        public Aluno Put(int id, [FromBody]Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            return _aluno.Atualizar(id, aluno);
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            Aluno _aluno = new Aluno();

            _aluno.Deletar(id);
        }
    }
}
