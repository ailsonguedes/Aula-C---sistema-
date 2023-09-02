using System;
using System.Collections.Generic;

class Program
{
    class Produto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void NovoProduto(string codigo, string nome, int quantidade)
        {
            Produto produto = new Produto { Codigo = codigo, Nome = nome, Quantidade = quantidade };
            produtos.Add(produto);
        }

        public void ListarProdutos()
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine($"====================\nCódigo: {produto.Codigo}\nNome: {produto.Nome}\nQuantidade: {produto.Quantidade}\n====================\n");
            }
        }

        public void RemoverProduto(string codigo)
        {
            produtos.RemoveAll(produto => produto.Codigo == codigo);
        }

        public void EntradaEstoque(string codigo, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                produto.Quantidade += quantidade;
            }
        }

        public void SaidaEstoque(string codigo, int quantidade)
        {
            Produto produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                produto.Quantidade -= quantidade;
            }
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("====================\n[1] Novo\n[2] Listar\n[3] Remover Produtos\n[4] Entrada Estoque\n[5] Saída Estoque\n[0] Sair\n====================\n");
    }

    static void Main(string[] args)
    {
        Estoque estoque = new Estoque();

        while (true)
        {
            Console.Clear();
            ExibirMenu();
            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite o código do produto: ");
                    string codigo = Console.ReadLine();
                    Console.WriteLine("Digite o nome do produto: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    estoque.NovoProduto(codigo, nome, quantidade);
                    break;

                case "2":
                    estoque.ListarProdutos();
                    break;

                case "3":
                    Console.WriteLine("Digite o código do produto a ser removido: ");
                    string codigoRemover = Console.ReadLine();
                    estoque.RemoverProduto(codigoRemover);
                    break;

                case "4":
                    Console.WriteLine("Digite o código do produto: ");
                    string codigoEntrada = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade a ser adicionada ao estoque: ");
                    int quantidadeEntrada = int.Parse(Console.ReadLine());
                    estoque.EntradaEstoque(codigoEntrada, quantidadeEntrada);
                    break;

                case "5":
                    Console.WriteLine("Digite o código do produto: ");
                    string codigoSaida = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade a ser retirada do estoque: ");
                    int quantidadeSaida = int.Parse(Console.ReadLine());
                    estoque.SaidaEstoque(codigoSaida, quantidadeSaida);
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Escolha novamente.");
                    break;
            }
        }
    }
}
