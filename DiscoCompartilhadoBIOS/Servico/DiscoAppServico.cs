using System.Collections.Generic;
using DiscoCompartilhado.Handlers;
using DiscoCompartilhado.Modelos;

namespace DiscoCompartilhado.Servicos
{
    public class DiscoAppServico
    {
        public static List<ArmazenamentoLogico>? ObterDiscos(string? consulta = null)
        {
            var discoHandler = new DiscoHandler(consulta);
            return discoHandler.ObterInformacoesDiscos();
        }
    }
}