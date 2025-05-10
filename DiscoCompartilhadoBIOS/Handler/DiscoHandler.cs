using System;
using System.Linq;
using System.Management;
using DiscoCompartilhado.Modelos;

namespace DiscoCompartilhado.Handlers
{
    public class DiscoHandler
    {
        private readonly string _consulta;

        public DiscoHandler(string consulta = "SELECT * FROM Win32_LogicalDisk")
        {
            _consulta = consulta ?? "SELECT * FROM Win32_LogicalDisk";
        }

        public ArmazenamentoLogico ObterInformacoesDisco()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(_consulta))
                {
                    var disco = searcher.Get()
                        .Cast<ManagementObject>()
                        .Select(discoInfo => new ArmazenamentoLogico
                        {
                            Nome = discoInfo["Name"] as string,
                            Descricao = discoInfo["Description"] as string,
                            CapacidadeBytes = ConverterParaInt64(discoInfo["Size"]),
                            EspacoLivre = ConverterParaInt64(discoInfo["FreeSpace"]),
                            Serial = discoInfo["VolumeSerialNumber"] as string,
                            SistemaArquivos = discoInfo["FileSystem"] as string,
                            TipoMidia = ConverterParaInt32(discoInfo["MediaType"]),
                            TipoDriver = ConverterParaInt32(discoInfo["DriveType"]),
                            EnderecoRede = ObterEnderecoRede()
                        })
                        .FirstOrDefault();

                    return disco;
                }
            }
            catch (ManagementException ex)
            {
                Console.WriteLine($"Erro ao consultar o WMI: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao obter informações do disco: {ex.Message}");
                return null;
            }
        }

        private long ConverterParaInt64(object valor)
        {
            if (valor != null && long.TryParse(valor.ToString(), out long resultado))
            {
                return resultado;
            }
            return 0;
        }

        private int ConverterParaInt32(object valor)
        {
            if (valor != null && int.TryParse(valor.ToString(), out int resultado))
            {
                return resultado;
            }
            return 0;
        }

        private string ObterEnderecoRede()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration"))
                {
                    foreach (ManagementObject networkAdapter in searcher.Get())
                    {
                        if (networkAdapter["IPAddress"] is string[] enderecosIp && enderecosIp.Length > 0)
                        {
                            return enderecosIp[0];
                        }
                    }
                }
            }
            catch (ManagementException ex)
            {
                Console.WriteLine($"Erro ao consultar o WMI para endereço de rede: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter endereço de rede: {ex.Message}");
            }
            return string.Empty;
        }
    }
}