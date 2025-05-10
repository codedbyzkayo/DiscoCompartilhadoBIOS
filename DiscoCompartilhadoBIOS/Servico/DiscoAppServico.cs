using DiscoCompartilhado.Handlers;
using DiscoCompartilhado.Modelos;

namespace DiscoCompartilhado.Servicos
{
    public class DiscoAppServico
    {
        public static ArmazenamentoLogico ObterDisco(string consulta = null)
        {
            var discoHandler = new DiscoHandler(consulta);
            return discoHandler.ObterInformacoesDisco();
        }
    }
}