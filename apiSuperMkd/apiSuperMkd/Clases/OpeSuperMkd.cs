using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiSuperMkd.Models;
using System.Web.Http.Cors;

//[EnableCors(origins: "http://localhost:XXXXX", headers: "*", methods: "*")]

namespace apiSuperMkd.Clases
{
    public class OpeSuperMkd
    {
        public ModSuperMkd objModMdo {  get; set; }
        private bool Validar() 
        {

            if (objModMdo.tipoClasif != 1 && objModMdo.tipoClasif != 5 && objModMdo.tipoClasif != 10)
            {
                objModMdo.Error = "Tipo de Clasificacion no es valida";
                return false;
            }
            else if (objModMdo.porcDscto < 0)
            {
                objModMdo.Error = "Porcentaje de Erro no valido";
                return false;
            }
            else if (objModMdo.subTotal <= 0)
            {
                objModMdo.Error = "El valor de subtotal no es valido";
                return false;
            }


            return true; 
        }
        private void   HallarDscto() 
        {
            try
            {
                float fltSubTotal = 0;
                float fltDescuento = 0;
                switch (objModMdo.tipoClasif)
                {
                  
                    case 1:
                        if (fltSubTotal <= 1_000_000)
                        {
                            fltDescuento = 5;
                        }
                        else if (fltSubTotal <= 5_000_000)
                        {
                            fltDescuento = 8.1f;
                        }
                        else
                        {
                            fltDescuento = 11.2f;
                        }
                        break;
                    case 2:
                        if (fltSubTotal <= 1_000_000)
                        {
                            fltDescuento = 5;
                        }
                        else if (fltSubTotal <= 5_000_000)
                        {
                            fltDescuento = 8.1f;
                        }
                        else
                        {
                            fltDescuento= 11.2f;
                        }
                        break;
                    default:
                        fltDescuento = 0;
                        break;
                }
                objModMdo.porcDscto = fltDescuento;
                objModMdo.subTotal = fltSubTotal;
                objModMdo.vrDscto = objModMdo.subTotal * objModMdo.porcDscto;
            }
            catch 
            {
                return;
            }
        }
        public void hallarDatos()
        {
            if ( ! Validar())
                return ;
            HallarDscto();
            objModMdo.vrDscto = objModMdo.subTotal * objModMdo.porcDscto / 100;
            objModMdo.vrAPagar = objModMdo.subTotal - objModMdo.vrDscto;

        }
    }
}