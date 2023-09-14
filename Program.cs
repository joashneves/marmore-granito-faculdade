using System;
using Produtos;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;

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


        // Criar 10 produtos com valores diferentes
        CriarProduto(01, 12345, 2.2, "Bloco 1", "Mármore", 50.0, 75.0, "Pedreira A");
        CriarProduto(02, 67890, 3.3, "Bloco 2", "Granito", 60.0, 80.0, "Pedreira B");
        CriarProduto(03, 11111, 1.5, "Bloco 3", "Mármore", 45.0, 70.0, "Pedreira A");
        CriarProduto(04, 22222, 2.8, "Bloco 4", "Granito", 55.0, 85.0, "Pedreira C");
        CriarProduto(05, 33333, 1.2, "Bloco 5", "Mármore", 40.0, 60.0, "Pedreira B");
        CriarProduto(06, 44444, 4.2, "Bloco 6", "Granito", 70.0, 90.0, "Pedreira A");
        CriarProduto(07, 55555, 2.5, "Bloco 7", "Mármore", 48.0, 72.0, "Pedreira C");
        CriarProduto(08, 66666, 3.7, "Bloco 8", "Granito", 65.0, 90.0, "Pedreira B");
        CriarProduto(09, 77777, 2.3, "Bloco 9", "Mármore", 42.0, 68.0, "Pedreira A");
        CriarProduto(10, 88888, 3.4, "Bloco 10", "Granito", 58.0, 78.0, "Pedreira C");

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


            Console.Write("Escolha uma opção: ");
            escolha = Console.ReadLine()[0]!;

            if (!string.IsNullOrWhiteSpace(escolha)) //Verifica se o console está vazio, caso esteja não inicia a linha devido ao "!"
            {
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
                    default:
                        Console.WriteLine("Opção invalida");
                        break;

                }
            } 

            else
            {
                Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
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
        descricao = (Console.ReadLine()); // Coloca a descriação

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

        Console.Write("Valor de compra: ");
        valorCompra = verificarNumDouble(Console.ReadLine()); //define valor da compra
        Console.Write("Valor de Venda: ");
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

        //Imprime na tela o que foi adicionado com uso de delay
        Console.WriteLine($"Número: {numero}");
        Thread.Sleep(500);
        Console.WriteLine($"Medidas: {medidas}");
        Thread.Sleep(500);
        Console.WriteLine($"Descrição: {descricao}");
        Thread.Sleep(500);
        Console.WriteLine($"Tipo: {tipo}");
        Thread.Sleep(500);
        Console.WriteLine($"Valor de Compra: {valorCompra}");
        Thread.Sleep(500);
        Console.WriteLine($"Valor de Venda: {valorVenda}");
        Thread.Sleep(500);
        Console.WriteLine($"Pedreira: {pedreira}"); 


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
        Console.WriteLine("ID|    NUMERO   | MEDIDAS |  DESCRICAO |    TIPO    | VALOR DA COMPRA |  VALOR DA VENDA |   PEDREIRA");

        //Percorre a lista de produtos
        foreach (Produto produto in listaDeProdutos)
        {
            // Acessa função do objeto
            Console.Write($"{produto.getId()} |     {produto.getNumero()}   |    {produto.getMedidas()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |        {produto.getValorCompra()}       |        {produto.getValorVenda()}       |   {produto.getPedreira()} \n");
            Thread.Sleep(500);
        }
        Console.ReadKey();
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

        Console.WriteLine("ID | NUMERO | MEDIDAS | DESCRICAO | TIPO   |  VALOR DA COMPRA | VALOR DA VENDA | PEDREIRA");

        // Percorre a lista de produto que ja existe
        foreach (Produto produto in listaDeProdutos)
        { // Se o pedreiraEncontrar for igual ele vai para e imprimir o que encontrou
            if (produto.getPedreira() == pedreiraEncontrar)  //pedreiraEncontrar)
            {
                // Acessa função do objeto
                Console.Write($"{produto.getId()} |     {produto.getNumero()}   |    {produto.getMedidas()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |   {produto.getValorCompra()}  |   {produto.getValorVenda()}  |   {produto.getPedreira()} \n");
                Thread.Sleep(500);
            }
        }

        Console.ReadKey();

    }

    // Um Parse teimoso
    public static int verificarNumInt(string numero)
    {
        int num;
        while (true)
        {
            try
            {
                num = int.Parse(numero);
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
}