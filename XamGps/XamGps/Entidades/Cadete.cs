

using System;
using System.Collections.Generic;


public partial class Cadete : Usuario
{
    public int IdCadete { get; set; }
    public long cedulaCadete { get; set; }
    public Cadete(int idusu, long cedulaUsu, string nombreUsu, string claveUsu, decimal sueldo, DateTime fechaIngreso)
         : base(idusu, cedulaUsu, nombreUsu, claveUsu, sueldo, fechaIngreso)
    {

    }

    public Cadete() : base()
    { }
}
