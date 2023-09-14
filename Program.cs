using System;
using Produtos;
using System.Collections.Generic;

class Program
{
    static List<Produto> listaDeProdutos = new List<Produto>();

    public static void Main(string[] args)
    {
        //Variaveis do sistema
        char escolha;
        int id;
        int numero;
        double medidas;
        string descricao;
        string tipo;
        double valorCompra;
        double valorVenda;
        string pedreira;
        //Imprime o menu do sistema
        Console.WriteLine(@">>> Gestão de Blocos <<<
1 – Cadastrar Bloco
2 – Listar Blocos 
3 – Buscar Bloco por código 
4 – Listar Blocos por pedreira 
5 - SAIR");

        // Criar 10 produtos com valores diferentes
        CriarProduto(1, 12345, 2.2, "Bloco 1", "Mármore", 50.0, 75.0, "Pedreira A");
        CriarProduto(2, 67890, 3.3, "Bloco 2", "Granito", 60.0, 80.0, "Pedreira B");
        CriarProduto(3, 11111, 1.5, "Bloco 3", "Mármore", 45.0, 70.0, "Pedreira A");
        CriarProduto(4, 22222, 2.8, "Bloco 4", "Granito", 55.0, 85.0, "Pedreira C");
        CriarProduto(5, 33333, 1.0, "Bloco 5", "Mármore", 40.0, 60.0, "Pedreira B");
        CriarProduto(6, 44444, 4.2, "Bloco 6", "Granito", 70.0, 100.0, "Pedreira A");
        CriarProduto(7, 55555, 2.5, "Bloco 7", "Mármore", 48.0, 72.0, "Pedreira C");
        CriarProduto(8, 66666, 3.7, "Bloco 8", "Granito", 65.0, 90.0, "Pedreira B");
        CriarProduto(9, 77777, 2.0, "Bloco 9", "Mármore", 42.0, 68.0, "Pedreira A");
        CriarProduto(10, 88888, 3.0, "Bloco 10", "Granito", 58.0, 78.0, "Pedreira C");

        while (true)
        {
            Console.Write("Escolha uma opção: ");
            escolha = char.Parse(Console.ReadLine());
            switch (escolha)
            {
                case '1':
                    CadastrarBloco();
                    Console.WriteLine("Produto Cadastrado com sucesso!");
                    break;
                case '2':
                    AcessarProdutosAnteriores();
                    Console.WriteLine("Fim da lista!");
                    break;
                case '3':
                    BuscarBlocoCodigo();
                    break;
                case '4':
                    BuscarBlocoPedreira();
                    break;
                case '5':
                    Console.WriteLine("Encerrando o programa");
                    return;
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
        }


    }

    //Função para criar produto
    public static void CriarProduto(int id, int numero, double medidas, string descricao, string tipo, double compra, double venda, string pedreira)
    {
        // Criando um objeto Produto
        Produto produto = new Produto();
        produto.setId(id);
        produto.setNumero(numero);
        produto.setMedidas(medidas);
        produto.setDescricao(descricao);
        produto.setTipo(tipo);
        produto.setValorCompra(compra);
        produto.setValorVenda(venda);
        produto.setPedreira(pedreira);

        // Adicione o produto à lista de produtos
        listaDeProdutos.Add(produto);
    }

    //Acessa a opção 1
    public static void CadastrarBloco()
    {
        Produto ultimoProduto = listaDeProdutos[listaDeProdutos.Count - 1];
        //Variaveis do bloco que esta sendo criado
        int id;
        int numero;
        double medidas;
        string descricao;
        string tipo;
        char escolhaTipo;
        double valorCompra;
        double valorVenda;
        string pedreira;

        Console.WriteLine("Opção de cadastrar Bloco:"); // Mensagem ao usuario

        //Codigo de escolha do usuario
        id = ultimoProduto.getId() + 1; //Pega o ultimo objeto criado e seu ID e soma 1
        Console.Write("Numero: ");
        numero = int.Parse(Console.ReadLine()); //Da escolha ao usuario de criar um numero
        Console.Write("Medidas: ");
        medidas = double.Parse(Console.ReadLine()); //Escolhe as medidas
        Console.Write("Descrição: ");
        descricao = (Console.ReadLine()); // Coloca a descriação

    ESCOLHATIPO:
        // Escolhe o tipo baseado na opção dada
        Console.Write("Tipo do Bloco (1 - Mármore / 2 - Granito): ");
        escolhaTipo = char.Parse(Console.ReadLine());

        tipo = "Mármore"; // Valor padrão
                          //Escolha do tipo
        if (escolhaTipo == '1')
        {
            tipo = "Mármore";
        }
        else if (escolhaTipo == '2')
        {
            tipo = "Granito";
        }
        else
        {  // Caso usuario coloque um tipo que não existe
            goto ESCOLHATIPO;
        }

        Console.Write("Valor de compra: ");
        valorCompra = double.Parse(Console.ReadLine()); //define valor da compra
        Console.Write("Valor de Venda: ");
        valorVenda = double.Parse(Console.ReadLine()); // define valor da venda
        Console.Write("Pedreira: ");
        pedreira = (Console.ReadLine()); // Define a pedreira

        // Cria o produto com os valores cadastrado
        CriarProduto(id,
          numero,
          medidas,
          descricao,
          tipo,
          valorCompra,
          valorVenda,
          pedreira);
    }

    //Acessa a opção 2
    public static void AcessarProdutosAnteriores()
    {
        Console.WriteLine("Produtos Anteriores:");
        //Percorre a lista de produtos
        foreach (Produto produto in listaDeProdutos)
        {
            Console.WriteLine("_______________________");
            // Acessa função do objeto
            produto.ImprimirInformacoes();
        }
    }

    //Acessa a opção 3
    public static void BuscarBlocoCodigo()
    {
        Console.WriteLine("Escreva codigo do produto:");
        int codigoEncontrar;
        //Amarzena a variavel que o usuario quer procurar
        codigoEncontrar = int.Parse(Console.ReadLine());

        // Percorre a lista de produto que ja existe
        foreach (Produto produto in listaDeProdutos)
        { // Se o codigoEncontrar for igual ele vai para e imprimir o que encontrou
            if (produto.getId() == codigoEncontrar)
            {
                Console.WriteLine("Produto encontrado!");
                produto.ImprimirInformacoes(); //Imprime os valores do produto
                break; // Sai da função se encontrar
            }
        } // se ele não encontrar nada
        Console.WriteLine("Produto não encontrado!");

    }

    //Acessa a opção 4 (e é uma copia do anterior)
    public static void BuscarBlocoPedreira()
    {
        Console.WriteLine("Escreva a pedreira do produto:");
        string pedreiraEncontrar;
        //Amarzena a variavel que o usuario quer procurar
        pedreiraEncontrar = Console.ReadLine()!;

        // Percorre a lista de produto que ja existe
        foreach (Produto produto in listaDeProdutos)
        { // Se o pedreiraEncontrar for igual ele vai para e imprimir o que encontrou
            if (produto.getPedreira() == pedreiraEncontrar)
            {
                Console.WriteLine("Produto encontrado!");
                produto.ImprimirInformacoes(); //Imprime os valores do produto
                break; // Sai da função se encontrar
            }
        } // se ele não encontrar nada
        Console.WriteLine("Produto não encontrado!");
    }


}
