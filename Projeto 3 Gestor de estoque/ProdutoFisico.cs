﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3_Gestor_de_estoque
{
    [System.Serializable]
     class ProdutoFisico : Produto, Iestoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;

        }

        public void AdicionarEntrada()
        {
        Console.WriteLine("Adicionar entrada no estoque do produto " +nome);
        Console.WriteLine("Digite a quantidade que você quer dar entrada");
        int entrada =int.Parse(Console.ReadLine());
        estoque += entrada;
        Console.WriteLine("Entrada registrada");
        Console.ReadLine();

            
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar saida no estoque do produto " + nome);
            Console.WriteLine("Digite a quantidade que você quer dar retirar");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();


        }

        public void Exibir()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Preço: " + preco);
            Console.WriteLine("Estoque: " + estoque);
            Console.WriteLine("Frete: " + frete);
            Console.WriteLine("==========================");
        }

    }

    }
