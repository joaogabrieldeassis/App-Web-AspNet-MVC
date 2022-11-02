using JhonStore.Models;

namespace JhonStore.Controllers.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }
    }
    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    }

}
