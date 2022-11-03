namespace JhonStore.Controllers.Data
{
    public class Gol
    {
        private readonly Carro _carro;
        public Gol(Carro carro)
        {
            _carro = carro;
        }
        public void ProntoParaVender()
        {
            _carro.CriarCarro();
        }
    }
}
