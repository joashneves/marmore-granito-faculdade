using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos
{

    public class Produto
    {
        private int id;
        private int numero;
        private double medidas;
        private string descricao;
        private string tipo;
        private double valorCompra;
        private double valorVenda;
        private string pedreira;

        public void setId(int ID)
        {
            this.id = ID;
        }

        public int getId()
        {
            return id;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setMedidas(double medidas)
        {
            this.medidas = medidas;
        }

        public double getMedidas()
        {
            return medidas;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public string getDescricao()
        {
            return descricao;
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public string getTipo()
        {
            return tipo;
        }

        public void setValorCompra(double valorCompra)
        {
            this.valorCompra = valorCompra;
        }

        public double getValorCompra()
        {
            return valorCompra;
        }

        public void setValorVenda(double valorVenda)
        {
            this.valorVenda = valorVenda;
        }

        public double getValorVenda()
        {
            return valorVenda;
        }

        public void setPedreira(string pedreira)
        {
            this.pedreira = pedreira;
        }

        public string getPedreira()
        {
            return pedreira;
        }

        public void ImprimirInformacoes()
        {
            Console.WriteLine($"CODIGO: {getId()}");
            Console.WriteLine($"Número: {getNumero()}");
            Console.WriteLine($"Medidas: {getMedidas()}");
            Console.WriteLine($"Descrição: {getDescricao()}");
            Console.WriteLine($"Tipo: {getTipo()}");
            Console.WriteLine($"Valor de Compra: {getValorCompra()}");
            Console.WriteLine($"Valor de Venda: {getValorVenda()}");
            Console.WriteLine($"Pedreira: {getPedreira()}");
        }
    }
}
