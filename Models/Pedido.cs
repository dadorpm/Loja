using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Models
{
    public class Pedido
    {
        public Pedido()
        {

        }
        public Pedido(Roupa roupa)
        {
            this.Roupa = roupa;
            this.Data = DateTime.Now;
        }
        public int PedidoId { get; set; }
        public int RoupaId { get; set; }
        public virtual Roupa Roupa { get; set; }
        public DateTime Data { get; set; }
    }
}
