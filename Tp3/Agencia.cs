using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Tp3
{
    class Agencia
    {
        public List<Alojamiento> misAlojamientos;
        public int cantAlojamientos; 


        public Agencia()
        {
            misAlojamientos = new List<Alojamiento>();
           
        }

        public Agencia(int CantidadAlojamientos)
        {
            misAlojamientos = new List<Alojamiento>();
            cantAlojamientos = CantidadAlojamientos;
        }

        public bool insertarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)

                if (a != null && a.igualCodigo(aloj))

                    return false;

            misAlojamientos.Add(aloj);
            return true;
        }

     //public bool insertarAlojamientoBD(Alojamiento aloj)
     //   {
     //       foreach (Alojamiento a in misAlojamientos)

     //           if (a != null && a.igualCodigo(aloj))
     //           {
     //               return false;

     //           }
     //           else
     //           {
     //               int resultadoQuery;
     //               string connectionString = Properties.Resources.ConnectionString;
     //               string queryString = "INSERT INTO [dbo].[ALOJAMIENTO] ([CODIGO],[TIPO],[BARRIO],[CIUDAD],[ESTRELLAS],[CANTPERSONAS],[TV],[PRECIODIA_CABAÑA],[PRECIOPERSONA_HOTEL],[HABITACIONES],[BAÑOS],[NOMBRE])  VALUES (@codigo,@tipo,@barrio,@ciudad,@estrellas,@cantpersonas,@tv,@preciodia_cabaña,@preciopersona_hotel,@habitaciones,@baños,@nombre);";
     //               using (SqlConnection connection =
     //                   new SqlConnection(connectionString))
     //               {
     //                   SqlCommand command = new SqlCommand(queryString, connection);
     //                   command.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NVarChar));
     //                   command.Parameters.Add(new SqlParameter("@barrio", SqlDbType.NVarChar));
     //                   command.Parameters.Add(new SqlParameter("@ciudad", SqlDbType.NVarChar));
     //                   command.Parameters.Add(new SqlParameter("@estrellas", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@cantpersonas", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@tv", SqlDbType.Bit));
     //                   command.Parameters.Add(new SqlParameter("@preciodia_cabaña", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@preciopersona_hotel", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@habitaciones", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@baños", SqlDbType.Int));
     //                   command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
     //                   command.Parameters["@codigo"].Value = aloj.getCodigo();
     //                   command.Parameters["@tipo"].Value = aloj.getTipo();
     //                   command.Parameters["@barrio"].Value = aloj.getBarrio();
     //                   command.Parameters["@ciudad"].Value = aloj.getCiudad();
     //                   command.Parameters["@estrellas"].Value = aloj.getEstrellas();
     //                   command.Parameters["@tv"].Value = aloj.getTV();
     //                   command.Parameters["@preciodia_cabaña"].Value = aloj.getPrecioDia();
     //                   command.Parameters["@preciopersona_hotel"].Value = aloj.getPrecioPorPersona();
     //                   command.Parameters["@habitaciones"].Value = aloj.getHabitaciones();
     //                   command.Parameters["@baños"].Value = aloj.getbaños();
     //                   command.Parameters["@nombre"].Value = aloj.getNombre();
     //                   try
     //                   {
     //                       connection.Open();
     //                       //esta consulta NO espera un resultado para leer, es del tipo NON Query
     //                       resultadoQuery = command.ExecuteNonQuery();
     //                   }
     //                   catch (Exception ex)
     //                   {
     //                       Console.WriteLine(ex.Message);
     //                       return false;
     //                   }
     //               }
     //               if (resultadoQuery == 1)
     //               {
     //                   //Ahora sí lo agrego en la lista
     //                   misAlojamientos.Add(aloj);
     //                   return true;
     //               }
     //               else
     //               {
     //                   //algo salió mal con la query porque no generó 1 registro
     //                   return false;
     //               }
     //           }


         
     //       return false;
     //   }

        public bool estaAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
                if (a.igualCodigo(aloj))
                    return true;

            return false;
        }



        public bool eliminarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
            {
                if (a.igualCodigo(aloj))
                {
                    misAlojamientos.Remove(aloj);
                    return true;
                }
            }
            return false;
        }

        public bool modificarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
            {
                if (a.igualCodigo(aloj))
                {
                    misAlojamientos.Remove(a);
                    misAlojamientos.Add(aloj);

                }
                return true;
            }
            return false;
        }

        public List<Alojamiento> getAloj()
        {
            return misAlojamientos;
        }
       

        public bool estaLlena() { return cantAlojamientos == misAlojamientos.Count; }
        public bool hayAlojamientos() { return misAlojamientos.Count > 0; }

        //public Agencia soloHoteles()
        //{
        //    Agencia Salida = new Agencia(this.cantAlojamientos);
        //    foreach (Alojamiento a in misAlojamientos)
        //        if (a is Hotel)
        //            Salida.insertarAlojamiento(a);
        //    return Salida;
        //}

        public Agencia masEstrellas(int cant)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)
                if (a.getEstrellas() >= cant)
                    Salida.insertarAlojamiento(a);
            return Salida;
        }

        //public Agencia cabañasEntrePrecios(float d, float h)
        //{
        //    Agencia Salida = new Agencia(this.cantAlojamientos);
        //    foreach (Alojamiento a in misAlojamientos)
        //        if (a is Cabaña)
        //        {
        //            Cabaña c = (Cabaña)a;
        //            if (c.getPrecioPorPersona() <= h && c.getPrecioPorPersona() >= d)
        //                Salida.insertarAlojamiento(c);
        //        }

        //    return Salida;
        //}


        // esto antes no funcionaba esperando respuesta del profe
        //public Agencia alojamientosEntrePrecios(float d, float h)
        //{
        //    Agencia Salida = new Agencia(this.cantAlojamientos);

        //    foreach (Alojamiento a in misAlojamientos)
        //        if (a is Cabaña)
        //        {
        //            Cabaña c = (Cabaña)a;
        //            if (c.getPrecioPorPersona() <= h && c.getPrecioPorPersona() >= d)
        //                Salida.insertarAlojamiento(c);
        //            Console.WriteLine(c.ToString());
        //        }
        //        else if (a is Hotel)
        //        {
        //            Hotel t = (Hotel)a;
        //            if (t.getPrecioPorPersona() <= h && t.getPrecioPorPersona() >= d)
        //                Salida.insertarAlojamiento(t);
        //            Console.WriteLine(t.ToString());
        //        }

        //    return Salida;
        //}


        public int getCantidad() { return cantAlojamientos; }
        public void setCantidad(int CantAlojamientos) { cantAlojamientos = CantAlojamientos; }

        public List<Alojamiento> getAlojamientos()
        {
            return misAlojamientos;
            //return misAlojamientos.OrderBy(a => a.getEstrellas()).ThenBy(a => a.getCantPersonas()).ThenBy(a => a.getCodigo()).ToList();
        }
    }
}
