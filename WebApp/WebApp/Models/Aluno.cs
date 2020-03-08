using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public int ra { get; set; }

        public List<Aluno> ListarAluno()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json"); //Recebe o arquivo JSON.
            var json = File.ReadAllText(caminhoArquivo); //Transfere o arquivo JSON para a variavel json.
            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json); //Deserializa o json e atribui para listaAlunos. (converte o arquivo json para objeto (listaAlunos)).

            return listaAlunos;
        }

        public bool RescreverArquivo(List<Aluno> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented); // Converte o objeto (listaAlunos) para json.
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Aluno Inserir(Aluno Aluno)
        {
            var listaAlunos = this.ListarAluno();

            var maxId = listaAlunos.Max(aluno => aluno.id);
            Aluno.id = maxId + 1;
            listaAlunos.Add(Aluno);

            RescreverArquivo(listaAlunos);
            return Aluno;
        }

        public Aluno Atualizar(int id, Aluno Aluno)
        {
            var listaAlunos = this.ListarAluno();

            var itemIndex = listaAlunos.FindIndex(p => p.id == Aluno.id);
            if (itemIndex >= 0)
            {
                Aluno.id = id;
                listaAlunos[itemIndex] = Aluno;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaAlunos);
            return Aluno;
        }

        public bool Deletar(int id)
        {
            var listaAlunos = this.ListarAluno();

            var itemIndex = listaAlunos.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaAlunos);
            return true;
        }
    }
}