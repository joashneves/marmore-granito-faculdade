﻿using System;
using Produtos;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{

    static List<Produto> listaDeProdutos = new List<Produto>();

    public static void Main(string[] args)
    {
        //Variaveis do sistema
        int escolha;
        int id;
        int numero;
        double medidas;
        string descricao;
        string tipo;
        double valorCompra;
        double valorVenda;
        string pedreira;


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
            Console.Clear();
            //Imprime o menu do sistema
            Console.WriteLine(@">>> Gestão de Blocos <<<
1 – Cadastrar Bloco
2 – Listar Blocos 
3 – Buscar Bloco por código 
4 – Listar Blocos por pedreira 
5 - SAIR");
            
            // Pede o usuario para escolhe uma opção
            Console.Write("Escolha uma opção: ");
            escolha = verificarNumInt(Console.ReadLine());

            // Entra em um novela de casos
            switch (escolha)
            {
                case 1: // caso o usuario digite 1 ele entra na função de cadastrar bloco
                    CadastrarBloco();
                    Console.WriteLine("Produto Cadastrado com sucesso!");
                    break;
                case 2: // caso o usuario digite 2 ele entra na função de lista produtos
                    AcessarProdutosAnteriores();
                    Console.WriteLine("Fim da lista!");
                    break;
                case 3: // caso o usuario digite 3 ele entra na função de buscar produtos por codigo
                    BuscarBlocoCodigo();
                    break;
                case 4: // caso o usuario digite 4 ele entra na função de listar produtos por pedreira
                    BuscarBlocoPedreira();
                    break;
                case 5: // caso o usuario digite 5 ele ele returna a função saindo do switch 
                    Console.WriteLine("Encerrando o programa");
                    return;
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
        int escolhaTipo;
        double valorCompra;
        double valorVenda;
        string pedreira;

        Console.WriteLine("Opção de cadastrar Bloco:"); // Mensagem ao usuario

        //Codigo de escolha do usuario
        id = ultimoProduto.getId() + 1; //Pega o ultimo objeto criado e seu ID e soma 1
        Console.Write("Numero: ");
        numero = verificarNumInt((Console.ReadLine())); //Da escolha ao usuario de criar um numero
        Console.Write("Medidas: ");
        medidas = verificarNumDouble(Console.ReadLine()); //Escolhe as medidas
        Console.Write("Descrição: ");
        descricao = verificarString(Console.ReadLine()); // Coloca a descriação

    ESCOLHATIPO:
        // Escolhe o tipo baseado na opção dada
        Console.Write("Tipo do Bloco (1 - Mármore / 2 - Granito): ");
        escolhaTipo = verificarNumInt(Console.ReadLine());

        tipo = "Mármore"; // Valor padrão
                          //Escolha do tipo
        if (escolhaTipo == 1)
        {
            tipo = "Mármore";
        }
        else if (escolhaTipo == 2)
        {
            tipo = "Granito";
        }
        else
        {  // Caso usuario coloque um tipo que não existe
            goto ESCOLHATIPO;
        }

        Console.Write("Valor de compra: R$");
        valorCompra = verificarNumDouble(Console.ReadLine()); //define valor da compra
        Console.Write("Valor de Venda: R$");
        valorVenda = verificarNumDouble(Console.ReadLine()); // define valor da venda

    ESCOLHATIPOPEDREIRA:
        Console.Write(@"Pedreira: 
1 - Pedreira A
2 - Pedreira B
3 - Pedreira C
");
        escolhaTipo = verificarNumInt(Console.ReadLine()); // Define a pedreira
        pedreira = "Pedreira A"; // Valor padrão

        //Escolha da Pedreira
        if (escolhaTipo == 1)
        {
            pedreira = "Pedreira A";
        }
        else if (escolhaTipo == 2)
        {
            pedreira = "Pedreira B";
        }
        else if (escolhaTipo == 3)
        {
            pedreira = "Pedreira C";
        }
        else
        {  // Caso usuario coloque um tipo que não existe
            goto ESCOLHATIPOPEDREIRA;
        }


        // Cria o produto com os valores cadastrado
        CriarProduto(id,
          numero,
          medidas,
          descricao,
          tipo,
          valorCompra,
          valorVenda,
          pedreira);

        Console.ReadKey();
    }

    //Acessa a opção 2
    public static void AcessarProdutosAnteriores()
    {
        Console.WriteLine("Produtos Anteriores:");
        Console.WriteLine("ID | NUMERO | MEDIDAS |   DESCRICAO  |    TIPO     |  VALOR DA COMPRA | VALOR DA VENDA | PEDREIRA");

        //Percorre a lista de produtos
        foreach (Produto produto in listaDeProdutos)
        {

            // Acessa função do objeto
            Console.Write($"{produto.getId()} |   {produto.getNumero()} |    {produto.getMedidas()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |    R${produto.getValorCompra()}    |      R${produto.getValorVenda()}      |   {produto.getPedreira()} \n");
        }
        Console.ReadKey();
    }

    //Acessa a opção 3 
    public static void BuscarBlocoCodigo()
    {
        Console.WriteLine("Escreva codigo do produto:");
        int codigoEncontrar;
        //Amarzena a variavel que o usuario quer procurar
        codigoEncontrar = int.Parse(verificarString(Console.ReadLine()));

        // Percorre a lista de produto que ja existe
        foreach (Produto produto in listaDeProdutos)
        { // Se o codigoEncontrar for igual ele vai para e imprimir o que encontrou
            if (produto.getId() == codigoEncontrar)
            {
                Console.WriteLine("Produto encontrado!");
                produto.ImprimirInformacoes(); //Imprime os valores do produto
                Console.ReadKey();
                return; // Sai da função se encontrar
            }
        } // se ele não encontrar nada
        Console.WriteLine("Produto não encontrado!");
        Console.ReadKey();
    }

    //Acessa a opção 4 (e é uma copia do anterior)
    public static void BuscarBlocoPedreira()
    {
        Console.WriteLine("Escreva a pedreira do produto:");
        string pedreiraEncontrar;
        int escolhaTipo;
        //Amarzena a variavel que o usuario quer procurar

    ESCOLHATIPOPEDREIRA:
        Console.Write(@"Pedreira: 
1 - Pedreira A
2 - Pedreira B
3 - Pedreira C
");
        escolhaTipo = verificarNumInt(Console.ReadLine()); // Define a pedreira

        //Escolha da Pedreira
        if (escolhaTipo == 1)
        {
            pedreiraEncontrar = "Pedreira A";
        }
        else if (escolhaTipo == 2)
        {
            pedreiraEncontrar = "Pedreira B";
        }
        else if (escolhaTipo == 3)
        {
            pedreiraEncontrar = "Pedreira C";
        }
        else
        {  // Caso usuario coloque um tipo que não existe
            goto ESCOLHATIPOPEDREIRA;
        }

        Console.WriteLine("ID | NUMERO | MEDIDAS |   DESCRICAO  |    TIPO     |  VALOR DA COMPRA | VALOR DA VENDA | PEDREIRA");

        // Percorre a lista de produto que ja existe
        foreach (Produto produto in listaDeProdutos)
        { // Se o pedreiraEncontrar for igual ele vai para e imprimir o que encontrou
            if (produto.getPedreira() == pedreiraEncontrar)  //pedreiraEncontrar)
            {
                // Acessa função do objeto
                Console.Write($"{produto.getId()} |   {produto.getNumero()} |    {produto.getMedidas()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |    R${produto.getValorCompra()}    |      R${produto.getValorVenda()}      |   {produto.getPedreira()} \n");

            }
        }

        Console.ReadKey();

    }

    // Um Parse teimoso
    public static int verificarNumInt(string numero)
    {
        int num; // numero que vai ser retornado
        // a função recebe uma string do Console.Read() e tenta passa para Int
        while (true) // Entra em um loop so saindo caso ele passe a string para int
        {
            try
            {
                //Ele tenta passar para int
                num = int.Parse(numero);
                return num; // caso consiga retorna o valor que foi colocado no Console.Read() e devolve como int

            }
            catch // Caso de um erro e ele não consiga passa para int ele entra nessa linha
            {
                Console.WriteLine("numero invalido! ");
                Console.WriteLine("Insira um novo numero:"); // Mensagem ao usuario
                numero = Console.ReadLine(); // pede novo numero
            }
        }
    }

    // mesma coisa do verificarNumInt() só que devolve um double
    public static double verificarNumDouble(string numero)
    {
        double num;
        while (true)
        {
            try
            {
                num = double.Parse(numero);
                return num;
            }
            catch
            {
                Console.WriteLine("numero invalido! ");
                Console.WriteLine("Insira um novo numero:");
                numero = Console.ReadLine();
            }
        }

    }

    // Certifica se o campo não esta vazio
    public static string verificarString(string palavra)
    {
        // Loop infinito para só sair da função apos colocar uma opção valida
        while (true)
        {
            if (!string.IsNullOrEmpty(palavra)) { // Se o campo estiver preenchido ou null
                return palavra; // Retorne a palavra
            }
            Console.WriteLine("CAMPO NÃO PREENCHIDO!!!"); //Mensagem de aviso
            palavra = Console.ReadLine(); // COloque uma nova palavra
        }

    }
}