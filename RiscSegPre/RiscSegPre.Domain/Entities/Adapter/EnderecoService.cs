namespace RiscSegPre.Domain.Entities.Adapter
{
    public class EnderecoService
    {
        private readonly IEnderecoCep _endereco;

        public EnderecoService(IEnderecoCep endereco)
        {
            _endereco = endereco;
        }

        public Endereco Consultar(string cep)
        {
            return _endereco.ConsultarPorCep(cep);
        }
    }
}
