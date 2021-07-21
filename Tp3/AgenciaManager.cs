using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace Tp3
{
    class AgenciaManager
    {
  
        private DbSet<Usuario> misUsuarioos;
        private DbSet<Alojamiento> misAlojamientos;
        private DbSet<Reserva> misReservas;
        private MyContextGlobal contextGlobal;
        public int contadorReservas = 0;
        public int contInsertar = 0;
        public int prueba = 0;
        public int alojcont = 0;
        public int usuarioscont = 0;
        public int Total = 0;
        public int ts = 0;         

        public AgenciaManager()
        {
            inicializarAtributos();
        }
        public List<List<string>> buscarAlojamiento(String Ciudad, DateTime Pdesde, DateTime Phasta, int cantPersonas, String Tipo,int estrellas)
        {


            List<List<string>> aloj = new List<List<string>>();
            foreach (Alojamiento u in contextGlobal.alojamientos)
            {
              
                    if (u.getCantPersonas() >= cantPersonas || u.getEstrellas() >= estrellas)
                    {

                        if( u.getTipo() == Tipo)
                    {
                        aloj.Add(new List<string>() {u.tipo,u.codigo.ToString(), u.nombre, u.ciudad, u.barrio, u.estrellas.ToString(), u.cantPersonas.ToString(),u.tv.ToString(),u.precioDia.ToString(),
                                            u.precioPorPersona.ToString(),u.habitaciones.ToString(),u.baños.ToString()});
                    }else if(Tipo == "Ambos")
                    {
                        aloj.Add(new List<string>() {u.tipo,u.codigo.ToString(), u.nombre, u.ciudad, u.barrio, u.estrellas.ToString(), u.cantPersonas.ToString(),u.tv.ToString(),u.precioDia.ToString(),
                                            u.precioPorPersona.ToString(),u.habitaciones.ToString(),u.baños.ToString()});
                    }

                }
                
            }

            return aloj;
        }

        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contextGlobal = new MyContextGlobal();
                //cargo los usuarios
                contextGlobal.usuarios.Load();
                misUsuarioos = contextGlobal.usuarios;
                //cargo Alojamientos
                contextGlobal.alojamientos.Load();
                misAlojamientos = contextGlobal.alojamientos;
                //cargo Reservas
                contextGlobal.reservas.Load();
                misReservas = contextGlobal.reservas;
                contadorReservas = contextGlobal.reservas.Count();
            }
            catch (Exception)
            {

            }
        }

        public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contextGlobal.usuarios)
                salida.Add(new List<string>() { u.DNI.ToString(), u.Nombre, u.Mail, u.Password, u.esAdmin.ToString(), u.bloqueado.ToString() });
            return salida;
        }

        public bool AgregarUsuario(Usuario usu)
        {

            try
            {
                Usuario nuevo = new Usuario(usu.DNI, usu.Nombre, usu.Mail, usu.Password, usu.esAdmin, usu.bloqueado);
                //contexto.usuarios.Add(nuevo);
                misUsuarioos.Add(nuevo);
                contextGlobal.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool eliminarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contextGlobal.usuarios)
                    if (u.DNI == Dni)
                    {
                        contextGlobal.usuarios.Remove(u);
                        salida = true;
                    }
                if (salida)
                    contextGlobal.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificaUsuario(int dni, string passv, string passn, string passnc)
        {

            bool salida = false;
            foreach (Usuario u in contextGlobal.usuarios)
                if (u.DNI == dni)
                {
                    if(passn == passnc)
                    {
                    u.Password = passn;
                        contextGlobal.usuarios.Update(u);
                    salida = true;                         
                    }
                  
                }
            if (salida)
                contextGlobal.SaveChanges();
            return salida;
              

    }
        
        public bool modificarUsuarioAdmin(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
        bool salida = false;
        foreach (Usuario u in contextGlobal.usuarios)
            if (u.DNI == Dni)
            {
                u.Nombre = Nombre;
                u.Mail = Mail;
                u.Password = Password;
                u.esAdmin = EsADM;
                u.bloqueado = Bloqueado;
                    contextGlobal.usuarios.Update(u);
                salida = true;
            }
        if (salida)
            contextGlobal.SaveChanges();
        return salida;

    }

        public bool autenticarUsuario(int DNI, string password)
        {
            foreach ( Usuario usu in contextGlobal.usuarios)
            {
                if (usu.getDNI() == DNI && usu.getPassword() == password)
                {
                    if (!usu.getBloqueado())
                    {
                        return true;

                    }
                }
            }

           
      
            return false;
        }
        public bool autenticarUsuarioAdmin(int DNI, string password)
        {

            foreach (Usuario usu in contextGlobal.usuarios)
            {
                if (usu.getDNI() == DNI && usu.getPassword() == password)
                {
                    if (usu.getesAdmin())
                    {
                        return true;
                    }
                }
            }

         

            return false;

        }

        public bool desbloquearUsuario(Usuario usu)
        {
            foreach (Usuario a in contextGlobal.usuarios)
            {
                if (a != null && a.getBloqueado() != true)
                {
                    usu.setBloqueado(true);
                    contextGlobal.usuarios.Update(usu);
                    return true;
                }
            }
            return false;
        }

        public bool bloquearUsuario(int dni)
        {
            foreach (Usuario a in contextGlobal.usuarios)
            {
                if (a != null && a.getDNI() == dni)
                {
                   
                    a.setBloqueado(false);
                    contextGlobal.usuarios.Update(a);

                    return true;
                }
            }
            return false;
        }

        public List<List<string>> obtenerAlojamiento()
        {
           
            List<List<string>> aloj = new List<List<string>>();

            foreach (Alojamiento u in contextGlobal.alojamientos)       

                aloj.Add(new List<string>() {u.tipo,u.codigo.ToString(), u.nombre, u.ciudad, u.barrio, u.estrellas.ToString(), u.cantPersonas.ToString(),u.tv.ToString(),u.precioDia.ToString(),
                                            u.precioPorPersona.ToString(),u.habitaciones.ToString(),u.baños.ToString()});
            
            return aloj;
        }

        public bool agregarAlojamiento(Alojamiento aloj)
        {
            try
            {
                Alojamiento nuevo = new Alojamiento(aloj.codigo, aloj.tipo, aloj.ciudad, aloj.barrio, aloj.estrellas, aloj.cantPersonas, aloj.tv, aloj.precioDia, aloj.precioPorPersona, aloj.habitaciones, aloj.baños, aloj.nombre);
                //contexto.usuarios.Add(nuevo);
                misAlojamientos.Add(nuevo);
                contextGlobal.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificarAlojamiento(Alojamiento aloj)
        {

            bool salida = false;
            foreach (Alojamiento u in contextGlobal.alojamientos)
                if (u.codigo == aloj.codigo)
                {
                    u.nombre = aloj.nombre;
                    u.tipo = aloj.tipo;
                    u.barrio = aloj.barrio;
                    u.ciudad = aloj.ciudad;
                    u.estrellas = aloj.estrellas;
                    u.cantPersonas = aloj.cantPersonas;
                    u.tv = aloj.tv;
                    u.precioDia = aloj.precioDia;
                    u.precioPorPersona = aloj.precioPorPersona;
                    u.habitaciones = aloj.habitaciones;
                    u.baños = aloj.baños;
                    contextGlobal.alojamientos.Update(u);
                  
                    salida = true;
                }
            if (salida)
                contextGlobal.SaveChanges();
            return salida;
        }

        public bool quitarAlojamiento(Alojamiento aloj)
        {
            try
            {
                bool salida = false;
                foreach (Alojamiento u in contextGlobal.alojamientos)
                    if (u.codigo == aloj.codigo)
                    {
                        contextGlobal.alojamientos.Remove(u);
                     
                        salida = true;
                    }
                if (salida)
                    contextGlobal.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<List<string>> obtenerReserva()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Reserva u in contextGlobal.reservas)
             
                salida.Add(new List<string>() { u.id.ToString(), u.fdesde.ToString(), u.fhasta.ToString(), u.precio.ToString(), u.propiedadint.ToString(), u.personaint.ToString() });
            return salida;
        }

        public List<List<string>> obtenerReservas(int dni)
        {


            List<List<string>> reser = new List<List<string>>();

            foreach (Reserva u in contextGlobal.reservas)

            {
                if(u.personaint == dni)
                {
                reser.Add(new List<string>() { u.id.ToString(), u.fdesde.ToString(), u.fhasta.ToString(), u.precio.ToString(), u.propiedadint.ToString(), u.personaint.ToString() });

                }
            }
            return reser;
        }
        public List<Usuario> buscarReserva(int DNIusuario)
        {
            List<Usuario> usuarios = new List<Usuario> { };
            foreach (Usuario a in contextGlobal.usuarios)
            {
                if (a.getDNI() == DNIusuario)
                {
                    usuarios.Add(a);
                }
            }
            return usuarios;
        }

        public bool reservar(Reserva reservar)
        {

            try
            {
                Reserva nuevo = new Reserva(reservar.id,reservar.fdesde, reservar.fhasta, reservar.precio, reservar.propiedadint, reservar.personaint);
                //contexto.usuarios.Add(nuevo);
          
                misReservas.Add(nuevo);
                contextGlobal.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool calculoReserva(DateTime pdesde,DateTime phasta,int cantPersonas,int precioC,int precioH)
        {
            bool calculo = false;

            ts = phasta.Day - pdesde.Day;        
            precioC = (precioC * cantPersonas) * ts;
            precioH = (precioH * cantPersonas) * ts;
            Total = precioC + precioH;

            if(Total > 0)
            {
                calculo = true;
            }


            return calculo;

        }

        public bool modificarReserva(Reserva reservaNueva, int idAModificar) // Datos de Reserva
        {
            bool reserv = false;
            foreach (Reserva reser in contextGlobal.reservas)
            {
                if (reser.id == idAModificar)
                {
                    reser.fdesde = reservaNueva.fdesde;
                    reser.fhasta = reservaNueva.fhasta;
                    reser.precio = reservaNueva.precio;
                    contextGlobal.reservas.Update(reser);
                    reserv = true;
                }
            }
            if (reserv)
                contextGlobal.SaveChanges();
            return reserv;
        }

        public bool eliminarReserva(Reserva reservar)
        {
            try
            {
                bool salida = false;
                foreach (Reserva u in contextGlobal.reservas)
                    if (u.id == reservar.id)
                    {
                        contextGlobal.reservas.Remove(u);
                   
                        salida = true;
                    }
                if (salida)
                    contextGlobal.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public void cerrar()
        {
            contextGlobal.Dispose();
        
        }


    }
}
