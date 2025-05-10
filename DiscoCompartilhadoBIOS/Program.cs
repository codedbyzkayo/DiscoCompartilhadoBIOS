using DiscoCompartilhado.Servicos;
using DiscoCompartilhado.Modelos; // Adicione esta linha
using System;

namespace DiscoCompartilhado
{
    class Program
    {
        static void Main()
        {
            try
            {
                ArmazenamentoLogico disco = DiscoAppServico.ObterDisco();

                if (disco != null)
                {
                    Console.WriteLine("Informações do Disco:");
                    Console.WriteLine($"  Nome: {disco.Nome}");
                    Console.WriteLine($"  Descrição: {disco.Descricao}");
                    Console.WriteLine($"  Capacidade: {disco.CapacidadeBytes} bytes");
                    Console.WriteLine($"  Espaço Livre: {disco.EspacoLivre} bytes");
                    Console.WriteLine($"  Serial: {disco.Serial}");
                    Console.WriteLine($"  Sistema de Arquivos: {disco.SistemaArquivos}");
                    Console.WriteLine($"  Tipo de Mídia: {disco.TipoMidia}");
                    Console.WriteLine($"  Tipo de Driver: {disco.TipoDriver}");
                    Console.WriteLine($"  Endereço de Rede: {disco.EnderecoRede}");
                }
                else
                {
                    Console.WriteLine("Não foi possível obter informações do disco.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao executar o programa: {ex.Message}");
            }
        }
    }
}