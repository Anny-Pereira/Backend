﻿using System;
using Exemplo_Objeto_como_Argumento.Classes;

namespace Exemplo_Objeto_como_Argumento
{
    class Program
    {
        static void Main(string[] args)
        {
            string Nome;
            float Preco;
            string Verlista;
            string AlterarProduto;
            string RemoverProduto;
            string ProdutoAlterado;
            string ProdutoRemovido;


            Console.WriteLine("Seja bem-vindo(a) à quitandinha!\n");

            Console.WriteLine("Quantos produtos você deseja cadastrar?");
            int ProdutosCad = int.Parse(Console.ReadLine());

            Carrinho carrinho = new Carrinho();

            for (var i = 1; i <= ProdutosCad; i++)
            {
                Console.Write($"\nInsira o nome do produto {i}: ");
                Nome = Console.ReadLine();

                Console.Write($"Insira o preço do produto {i}: ");
                Preco = float.Parse(Console.ReadLine());

                Produto P1 = new Produto(i, Nome, Preco);

                carrinho.AdicionarProduto(P1);

            }

            Console.WriteLine("\nVocê deseja emitir a nota fiscal da lista de produtos (s-sim / n-não)?");
            Verlista = Console.ReadLine();
            if (Verlista == "s")
            {
                carrinho.MostrarProdutos();
            }
            else
            {
                Console.WriteLine("Sessão finalizada. Obrigada pela preferência!");
            }


            Console.WriteLine("\nVocê deseja remover algum produto da lista (s-sim / n-não)?");
            RemoverProduto = Console.ReadLine();
            if (RemoverProduto == "s")
            {
                Console.WriteLine("Qual produto deseja remover?");
                ProdutoRemovido = Console.ReadLine().ToLower();

                Produto ProdutoEncontrado = carrinho.carrinho.Find(x => x.Nome == ProdutoRemovido);

                carrinho.RemoverProduto(ProdutoEncontrado);
            }


            Console.WriteLine("\nVocê deseja alterar algum produto da lista (s-sim / n-não)?");
            AlterarProduto = Console.ReadLine();
            if (AlterarProduto == "s")
            {
                Console.WriteLine("Qual produto deseja alterar?");
                ProdutoAlterado = Console.ReadLine().ToLower();

                Produto ProdutoEncontrado = carrinho.carrinho.Find(x => x.Nome == ProdutoAlterado);

                Produto P2 = new Produto();

                Console.Write($"\nInsira o nome do novo produto: ");
                P2.Nome = Console.ReadLine();

                Console.Write($"Insira o preço do novo produto: ");
                P2.Preco = float.Parse(Console.ReadLine());

                P2.Codigo = ProdutoEncontrado.Codigo;

                carrinho.AlterarProduto(ProdutoEncontrado.Codigo, P2);
            }


        }
    }
}
