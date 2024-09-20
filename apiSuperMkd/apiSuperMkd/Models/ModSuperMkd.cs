using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSuperMkd.Models
{
    public class ModSuperMkd
    {

        #region "Atttribtes/Properties"

        public int tipoClasif {  get; set; }
        public float subTotal {  get; set; }

        public float porcDscto { get; set; }
        public float vrAPagar {  get; set; }
        public float vrDscto { get; set; }
        public string Error {  get; set; }
        #endregion

        #region "Constructor"
        public ModSuperMkd() { 
        
            tipoClasif = 0;
            subTotal = 0;
            porcDscto = 0;
            vrAPagar = 0;
            vrDscto = 0;
            Error = string.Empty;
        }
        #endregion
    }
}