namespace RiscSegPre.Domain.Entities.Adapter
{
    public interface IEnderecoCep
    {
        Endereco ConsultarPorCep(string cep);
    }
}
