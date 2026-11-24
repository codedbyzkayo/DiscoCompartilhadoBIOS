using DiscoCompartilhado.Servicos;
using DiscoCompartilhado.Modelos;
using System;

namespace DiscoCompartilhado
{
    class Program
    {
        static void Main()
        {
            try
            {
                var discos = DiscoAppServico.ObterDiscos();

                if (discos == null)
                {
                    Console.WriteLine("Não foi possível obter informações dos discos.");
                }
                else if (discos.Count == 0)
                {
                    Console.WriteLine("Nenhum disco disponível foi encontrado.");
                }
                else
                {
                    foreach (var disco in discos)
                    {
                        Console.WriteLine($"Informações do Disco {disco.Nome}");
                        Console.WriteLine($"  Nome: {disco.Nome}");
                        Console.WriteLine($"  Descrição: {disco.Descricao}");
                        Console.WriteLine($"  Capacidade: {disco.CapacidadeBytes} bytes");
                        Console.WriteLine($"  Espaço Livre: {disco.EspacoLivre} bytes");
                        Console.WriteLine($"  Serial: {disco.Serial}");
                        Console.WriteLine($"  Sistema de Arquivos: {disco.SistemaArquivos}");
                        Console.WriteLine($"  Tipo de Mídia: {disco.TipoMidia}");
                        Console.WriteLine($"  Tipo de Driver: {disco.TipoDriver}");
                        Console.WriteLine($"  Endereço de Rede: {disco.EnderecoRede}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao executar o programa: {ex.Message}");
            }
        }
    }
}