using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3_Gestor_de_estoque
{
    [System.Serializable]
    internal class Ebook:Produto,Iestoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome,float preco,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um produto");
            Console.ReadLine();
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar vendas no Ebook " + nome);
            Console.WriteLine("Digite a quantidade de vendas que você quer dar entrada");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Preço: " + preco);
            Console.WriteLine("Venda: " +vendas );
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("==========================");
        }
    }
}
