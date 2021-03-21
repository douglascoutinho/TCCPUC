namespace RiscSegPre.Domain.Entities.Adapter
{
    public class EnderecoAdapter : IEnderecoCep
    {
        private readonly IAddressApi _addressAPI;

        public EnderecoAdapter(IAddressApi addressAPI)
        {
            _addressAPI = addressAPI;
        }

        public Endereco ConsultarPorCep(string cep)
        {
            var endereco = _addressAPI.GetAddressByZipCode(cep);

            return new Endereco
            {
                cep = endereco.ZipCode,
                logradouro = endereco.PublicPlace,
                bairro = endereco.Neighborhood,
                cidade = endereco.City,
                complemento = endereco.Complement,
                estado = endereco.State,
                numero = endereco.Number
            };
        }
    }
}
