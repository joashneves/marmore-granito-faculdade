using System;
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

        //Carrega todos os dados de um TxT
        CarregarDados();

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
                    SalvarDados(); // Chama a função de salvar dados antes de sair
                    Console.WriteLine("Encerrando o programa");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }
        }
    }

    //Função para criar produto
    public static void CriarProduto(int id, int numero, double medidasComprimento, double medidasLargura, double medidasAltura, string descricao, string tipo, double compra, double venda, string pedreira)
    {
        // Criando um objeto Produto
        Produto produto = new Produto();
        produto.setId(id);
        produto.setNumero(numero);
        produto.setMedidasComprimento(medidasComprimento);
        produto.setMedidasLargura(medidasLargura);
        produto.setMedidasAltura(medidasAltura);
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
        Produto ultimoProduto = null; // o ultimo produto para poder pegar o ID como null

        try // Procura pelo o ultimo produto da lista
        {
            if (listaDeProdutos.Count > 0)
            {
                ultimoProduto = listaDeProdutos[listaDeProdutos.Count - 1];
            }
        }
        catch (Exception e) // Caso for a primeira vez provavelmente dara erro
        {
            ultimoProduto = null; // e se ocorrer um erro, define como null
        }

        // Cria um novo produto se a lista está vazia ou se ocorreu um erro ao acessar o último produto
        if (ultimoProduto == null)
        {
            ultimoProduto = new Produto();
        }
        //Variaveis do bloco que esta sendo criado
        int id;
        int numero;
        double medidasComprimento;
        double medidasLargura;
        double medidasAltura;
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
        Console.WriteLine("Medidas: ");
        Console.Write("Medida Comprimento: ");
        medidasComprimento = verificarNumDouble(Console.ReadLine()); //Escolhe as medidas
        Console.Write("Medidas Largura: ");
        medidasLargura = verificarNumDouble(Console.ReadLine()); //Escolhe as medidas
        Console.Write("Medidas Altura: ");
        medidasAltura = verificarNumDouble(Console.ReadLine()); //Escolhe as medidas
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
          medidasComprimento,
          medidasLargura,
          medidasAltura,
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
            Console.Write($"{produto.getId()} |   {produto.getNumero()} |    {produto.getMedidasComprimento()}x{produto.getMedidasLargura()}x{produto.getMedidasAltura()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |    R${produto.getValorCompra()}    |      R${produto.getValorVenda()}      |   {produto.getPedreira()} \n");
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
                Console.Write($"{produto.getId()} |   {produto.getNumero()} |    {produto.getMedidasComprimento()}x{produto.getMedidasLargura()}x{produto.getMedidasAltura()}  |   {produto.getDescricao()}  |   {produto.getTipo()}  |    R${produto.getValorCompra()}    |      R${produto.getValorVenda()}      |   {produto.getPedreira()} \n");

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
            catch (Exception e)// Caso de um erro e ele não consiga passa para int ele entra nessa linha
            {
                Console.WriteLine("numero invalido! ");
                Console.Write("Insira um novo numero(e somente numeros):"); // Mensagem ao usuario
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
            catch (Exception e)
            {
                Console.WriteLine("numero invalido! ");
                Console.Write("Insira um novo numero(e somente numeros):");
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

    // Salva os dados do programa
    public static void SalvarDados()
    {
        
        // Obtem o diretório atual do aplicativo
        string diretorioAtual = AppDomain.CurrentDomain.BaseDirectory;

        // Combine o diretório atual com o nome do arquivo
        string path = Path.Combine(diretorioAtual, "Dados.txt");
        try
        {
            // Cria o arquivo
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (Produto produto in listaDeProdutos)
                {
                    // Salva os dados no txt
                    sw.WriteLine($"{produto.getId()}/{produto.getNumero()}/{produto.getMedidasComprimento()}/{produto.getMedidasLargura()}/{produto.getMedidasAltura()}/{produto.getDescricao()}/{produto.getTipo()}/{produto.getValorCompra()}/{produto.getValorVenda()}/{produto.getPedreira()}");
                }
               
                Console.WriteLine("Dados salvos em: " + Environment.CurrentDirectory);
            }
        }
        catch (Exception e) //Caso ele não consiga criar um arquivo
        {
            Console.WriteLine("Não foi possivel salvar os dados");
        }
        
    }

    // Carrega os dados assim que o programa inicializa
    public static void CarregarDados()
    {
        // Obtem o diretório atual do aplicativo
        string diretorioAtual = AppDomain.CurrentDomain.BaseDirectory;

        // Combine o diretório atual com o nome do arquivo
        string path = Path.Combine(diretorioAtual, "Dados.txt");

        try
        {
            // Verifique se o arquivo existe antes de tentar lê-lo
            if (File.Exists(path))
            {
                // ler o arquivo
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        // le uma linha e divide os dados com "/"
                        string[] dadosProduto = sr.ReadLine().Split('/');

                        CriarProduto(
                        int.Parse(dadosProduto[0]),
                        int.Parse(dadosProduto[1]),
                        double.Parse(dadosProduto[2]),
                        double.Parse(dadosProduto[3]),
                        double.Parse(dadosProduto[4]),
                        dadosProduto[5],
                        dadosProduto[6],
                        double.Parse(dadosProduto[7]),
                        double.Parse(dadosProduto[8]),
                        dadosProduto[9]
                    );
                    }
                }
            }
        } catch (Exception e)  // Acontece quando chega na linha final e não tem nada para mandar para o programa então ele da erro
        {  
            return;
        }
    }

}