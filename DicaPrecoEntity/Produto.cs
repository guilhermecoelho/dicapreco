using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicaPrecoEntity
{
    [Serializable]
    public class Produto : UnidadeMedida
    {
        public int codProd { get; set; }
        public String descrProd{ get; set; }
    }
}
