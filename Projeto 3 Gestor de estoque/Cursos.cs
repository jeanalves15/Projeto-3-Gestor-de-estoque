using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3_Gestor_de_estoque
{
    [System.Serializable]
    internal class Cursos:Produto,Iestoque
    {
        public string autor;
        private int vagas;

        public Cursos(string nome,float preco,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Adicionar vagas no curso " + nome);
            Console.WriteLine("Digite a quantidade que você quer dar entrada");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();


        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar saida no estoque do produto " + nome);
            Console.WriteLine("Digite a quantidade que você quer dar retirar");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("Nome: "+nome);
            Console.WriteLine("Preço: " + preco);
            Console.WriteLine("Vagas restantes: " + vagas);
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("==========================");
        }
    }
}
