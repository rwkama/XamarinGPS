using System;
using System.Collections.Generic;
using System.Text;

namespace XamGps.Entidades
{
   public class Cliente
    {
        public int IdCliente { get; set; }
        public int CedulaCli { get; set; }
        public string NomCli { get; set; }
        public string DirCli { get; set; }
        public string telCli { get; set; }
        public string PassCli { get; set; }

        public Cliente(int idCliente, int cedulaCli, string nomCli, string dirCli, string telCli, string passCli)
        {
            IdCliente = idCliente;
            CedulaCli = cedulaCli;
            NomCli = nomCli;
            DirCli = dirCli;
            this.telCli = telCli;
            PassCli = passCli;
        }

        public Cliente()
        {
        }
    }
}
