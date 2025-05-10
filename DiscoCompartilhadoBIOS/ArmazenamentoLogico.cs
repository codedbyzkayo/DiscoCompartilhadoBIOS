namespace DiscoCompartilhado.Modelos
{
    public class ArmazenamentoLogico
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long CapacidadeBytes { get; set; }
        public long EspacoLivre { get; set; }
        public string Serial { get; set; }
        public string SistemaArquivos { get; set; }
        public int TipoMidia { get; set; }
        public int TipoDriver { get; set; }
        public string EnderecoRede { get; set; }
    }
}