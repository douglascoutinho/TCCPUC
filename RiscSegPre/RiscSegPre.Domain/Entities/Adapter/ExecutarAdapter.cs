namespace RiscSegPre.Domain.Entities.Adapter
{
    public static class ExecutarAdapter
    {
        public static Endereco ObterPorCep(string cep)
        {
            var endereco = new EnderecoService(new EnderecoAdapter(new AddressApiService()));
            return endereco.Consultar(cep);
        }
    }
}
