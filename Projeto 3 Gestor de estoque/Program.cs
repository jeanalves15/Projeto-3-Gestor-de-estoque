using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace Projeto_3_Gestor_de_estoque
{
    internal class Program
    {   
        static List<Iestoque> produtos = new List<Iestoque>();
        enum Menu {Lista =1, Adicionar , Remover ,Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheusair=false;
            while (!escolheusair)
            {
                Console.WriteLine("Sistema  de estoque");
                Console.WriteLine("1-Lista\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");
                string opStr=( Console.ReadLine());
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Lista:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheusair = true;
                            break;
                    }
                }
                else
                {

                    escolheusair = true;
                }
                Console.Clear();

            }

           
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Escolha um ID para remover");
            int id =int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count  ) 
            {
                produtos.RemoveAt(id);
                Salvar();
            
            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Escolha um ID que você quer dar entrada:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();

            }


        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Escolha um ID que você quer dar saida:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();

            }


        }

        static void Listagem()
        {
            Console.WriteLine("Listagem de produtos");
            int i = 0;
            foreach(Iestoque produto in produtos)
            {
                Console.WriteLine("ID: "+i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();



        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produtos");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Cursos");
            int opcao =int.Parse(Console.ReadLine());
            switch (opcao)
            {
                    case 1:
                    CadastroPF();
                        break;
                    case 2:
                    CadastroEbook();
                        break;
                    case 3:
                    CadastroCursos();
                        break;
            }
            

            

           
        }
        static void CadastroPF()
        {

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete");
            float frete=float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();

        }
        static void CadastroEbook()
        {

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor");
            string autor=Console.ReadLine();
            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }
        static void CadastroCursos()
        {

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor");
            string autor = Console.ReadLine();
            Cursos cs = new Cursos(nome, preco, autor);
            produtos.Add(cs);
            Salvar();

        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                produtos = (List<Iestoque>)encoder.Deserialize(stream);
                if(produtos == null)
                {
                    produtos = new List<Iestoque>();
                }
            }
            catch (Exception ex)
            {
                produtos = new List<Iestoque>();
            }
            stream.Close();
        }



    }
}

