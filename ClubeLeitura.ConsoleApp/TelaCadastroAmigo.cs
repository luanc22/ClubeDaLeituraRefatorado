using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite S para sair");

            Console.WriteLine();
            Console.Write("Opcao escolhida: ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo amigo = ObterAmigo();

            amigo.id = numeroAmigo++;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite endereco: ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.nomeResponavel = nomeResponsavel;
            amigo.endereco = endereco;
            amigo.telefone = telefone;

            return amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Caixa");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o id do amigo que deseja editar: ");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroAmigo)
                {
                    Amigo amigo = ObterAmigo();

                    amigos[i] = amigo;
                    amigos[i].id = numeroAmigo;

                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editada com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroAmigo)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public void VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo amigo = amigos[i];

                Console.WriteLine("Nome: " + amigo.nome);
                Console.WriteLine("Nome Responsavel: " + amigo.nomeResponavel);
                Console.WriteLine("Endereco: " + amigo.endereco);
                Console.WriteLine("Telefone: " + amigo.telefone);

                Console.WriteLine();
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }
    }
}
