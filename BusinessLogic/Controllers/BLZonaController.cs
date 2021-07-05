using DataAccess.Persistence;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class BLZonaController
    {
        private Repository _Repository;

        public BLZonaController()
        {
            this._Repository = new Repository();
        }

        public List<string> agregarZona(DtoZona nDtoZona)
        {
            List<string> colErrores = validarZona(nDtoZona,false);
            if (colErrores.Count() == 0)
            {
                this._Repository.GetZonaRepository().altaZona(nDtoZona);
            }
            return colErrores;
        }

        public List<string> eliminarZona (int numeroZona)
        {
            List<string> colErrores = new List<string>();
            if(colErrores.Count()==0&&this._Repository.GetZonaRepository().existeZona(numeroZona))
            {
                this._Repository.GetZonaRepository().bajaZona(numeroZona);
            }
            else
            {
                colErrores.Add("Zona no encontrada en la base de datos");
            }
            return colErrores;
        }


        public List<string> modificarZona(DtoZona mDtoZona)
        {
            List<string> colErrores = validarZona(mDtoZona, true);
            if(colErrores.Count()==0)
            {
                this._Repository.GetZonaRepository().modificarZona(mDtoZona);
            }
            return colErrores;
        }

        public List<DtoZona> listarZonas()
        {
            return this._Repository.GetZonaRepository().listarZonas();
        }

        //validacion
        public List<string> validarZona(DtoZona dtoZona, bool modificacion)
        {
            List<string> colErrores = new List<string>();

            if(dtoZona.nombre ==null)
            {
                colErrores.Add("El nombre de la zona no puede estar vacio");
            }
            if(dtoZona.color==null)
            {
                colErrores.Add("La zona debe tener un color asignado");
            }
            if(modificacion)
            {
                if (!this._Repository.GetZonaRepository().existeZona(dtoZona.numero))
                {
                    colErrores.Add("La zona no existe");
                }
            }
            


            return colErrores;
        }

        public bool puntoEnZonas(DtoPunto punto,List<DtoZona> zonas)
        {
            foreach (DtoZona zona in zonas)
            {
                if (puntoEnZona((float)punto.longitud, (float)punto.latitud, zona.colDtoPunto))
                {
                    return true;
                }
            }
            return false;
        }


        public bool zonaSuperPuesta(List<DtoPunto> newZonaPts, List<DtoZona> zonas)
        {
            for (int punto = 0; punto < newZonaPts.Count(); punto++)
            {
                DtoPunto pB1 = newZonaPts[punto];
                DtoPunto pB2 = new DtoPunto();
                if (newZonaPts.Count()-1>punto)
                {
                    pB2 = newZonaPts[punto + 1];
                }else
                {
                    pB2 = newZonaPts[0];
                }
                
                foreach (DtoZona zona in zonas)
                {
                    for (int i = 0; i < zona.colDtoPunto.Count(); i++)
                    {
                        DtoPunto pA1 = zona.colDtoPunto[i];
                        DtoPunto pA2 = new DtoPunto();
                        if (zona.colDtoPunto.Count()-1>i)
                        {
                            pA2 = zona.colDtoPunto[i + 1];
                        }
                        else
                        {
                            pA2 = zona.colDtoPunto[0];
                        }

                        if (vectoresCruzados(pA1, pA2, pB1, pB2))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }




        //-------------------------------------------------------------------------------------------------

        //Comprobar si las 2 lineas a comparar se cruzan
        public static bool vectoresCruzados(DtoPunto pA1, DtoPunto pA2, DtoPunto pB1, DtoPunto pB2)
        {
            List<decimal> ABCP1 = pMatrizABC(pA1, pA2);
            List<decimal> ABCP2 = pMatrizABC(pB1, pB2);
            decimal A1 = ABCP1[0], B1 = ABCP1[1], C1 = ABCP1[2];
            decimal A2 = ABCP2[0], B2 = ABCP2[1], C2 = ABCP2[2];
            decimal det = A1 * B2 - A2 * B1;

            if (det == 0)
            {
                return false;
            }
            else
            {
                decimal X = (B2 * C1 - B1 * C2) / det;
                decimal Y = (A1 * C2 - A2 * C1) / det;
                if (puntoEnVector(pA1, pA2, X, Y) && puntoEnVector(pB1, pB2, X, Y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static List<decimal> pMatrizABC(DtoPunto a, DtoPunto b)
        {
            decimal x1 = a.latitud, x2 = b.latitud, y1 = a.longitud, y2 = b.longitud;
            List<decimal> ABC = new List<decimal>();
            decimal A = y2 - y1, B = x1 - x2, C = (A * x1) + (B * y1);
            ABC.Add(A); ABC.Add(B); ABC.Add(C);
            return ABC;
        }
        public static bool puntoEnVector(DtoPunto a, DtoPunto b, decimal X, decimal Y)
        {
            decimal x1 = a.latitud, x2 = b.latitud, y1 = a.longitud, y2 = b.longitud;
            decimal minX = Math.Min(x1, x2);
            decimal maxX = Math.Max(x1, x2);
            decimal maxY = Math.Max(y1, y2);
            decimal minY = Math.Min(y1, y2);

            if (minX <= X && X <= maxX && minY <= Y && Y <= maxY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

           //-------------------------------------------------------------------------------------------------

        //calculos del punto en poligono
        private static double DotProduct(double Ax, double Ay,double Bx, double By, double Cx, double Cy)
        {
            // Get the vectors' coordinates.
            double BAx = Ax - Bx;
            double BAy = Ay - By;
            double BCx = Cx - Bx;
            double BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }

        public static double CrossProductLength(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
        {
            // Get the vectors' coordinates.
            double BAx = Ax - Bx;
            double BAy = Ay - By;
            double BCx = Cx - Bx;
            double BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        public static double GetAngle(double Ax, double Ay,double Bx, double By, double Cx, double Cy)
        {
            // Get the dot product.
            double dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            double cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }


        public bool puntoEnZona(double X, double Y,List<DtoPunto> puntos)
        {
            int max_point = puntos.Count - 1;
            double total_angle = GetAngle((double)puntos[max_point].latitud, (double)puntos[max_point].longitud,X, Y,(double)puntos[0].latitud, (double)puntos[0].longitud);
            for (int i = 0; i < max_point; i++)
            {
                total_angle += GetAngle(
                    (double)puntos[i].latitud, (double)puntos[i].longitud,
                    X, Y,
                    (double)puntos[i + 1].latitud, (double)puntos[i + 1].longitud);
            }
            return (Math.Abs(total_angle) > 1);
        }

    }
}
