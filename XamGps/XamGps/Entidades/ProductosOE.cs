

using System;
using System.Collections.Generic;

public partial class ProductosOE
{
    public int IdProdOE { get; set; }
    public int POE { get; set; }
    public int IdOrdenE { get; set; }

   

    public ProductosOE(int idProdOE, int pOE, int idOrdenE)
    {
        IdProdOE = idProdOE;
        POE = pOE;
        IdOrdenE = idOrdenE;
    }

    public ProductosOE()
    {
    }
}
