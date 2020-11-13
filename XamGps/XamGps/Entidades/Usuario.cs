

using System;
using System.Collections.Generic;

public partial class Usuario
{
    public int Idusu { get; set; }
    public long CedulaUsu { get; set; }
    public string NombreUsu { get; set; }
    public string ClaveUsu { get; set; }
    public decimal Sueldo { get; set; }
    public System.DateTime FechaIngreso { get; set; }
    public Usuario(int idusu, long cedulaUsu, string nombreUsu, string claveUsu, decimal sueldo, DateTime fechaIngreso)
    {
        Idusu = idusu;
        CedulaUsu = cedulaUsu;
        NombreUsu = nombreUsu;
        ClaveUsu = claveUsu;
        Sueldo = sueldo;
        FechaIngreso = fechaIngreso;
    }
    public Usuario()
    { }
}
