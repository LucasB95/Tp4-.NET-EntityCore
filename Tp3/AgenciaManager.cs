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
        public Agencia miAgencia;
        private DbSet<Usuario> misUsuarioos;
        private DbSet<Alojamiento> misAlojamientos;
        private DbSet<Reserva> misReservas;
        private MyContext contexto;
        private MyContextAlojamiento contextoAloj;
        private MyContextReserva contextoReser;
        public int contadorReservas = 0;
        public int contInsertar = 0;
        public int prueba = 0;
        public int alojcont = 0;
        public int usuarioscont = 0;


        public AgenciaManager()
        {
            
             inicializarAtributosUsuario();
             inicializarAtributosAlojamiento();
            inicializarAtributosReserva();

        }
        public List<List<string>> buscarAlojamiento(String Ciudad, DateTime Pdesde, DateTime Phasta, int cantPersonas, String Tipo,int estrellas)
        {


            List<List<string>> aloj = new List<List<string>>();
            foreach (Alojamiento u in contextoAloj.alojamientos)
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

        private void inicializarAtributosUsuario()
        {
            try
            {
                //creo un contexto
                contexto = new MyContext();
                //cargo los usuarios
                contexto.usuarios.Load();
                misUsuarioos = contexto.usuarios;
            }
            catch (Exception)
            {

            }
        }

        public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contexto.usuarios)
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
                contexto.SaveChanges();
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
                foreach (Usuario u in contexto.usuarios)
                    if (u.DNI == Dni)
                    {
                        contexto.usuarios.Remove(u);
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
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
            foreach (Usuario u in contexto.usuarios)
                if (u.DNI == dni)
                {
                    if(passn == passnc)
                    {
                    u.Password = passn;
                    contexto.usuarios.Update(u);
                    salida = true;                         
                    }
                  
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
              

    }
        
        public bool modificarUsuarioAdmin(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
        bool salida = false;
        foreach (Usuario u in contexto.usuarios)
            if (u.DNI == Dni)
            {
                u.Nombre = Nombre;
                u.Mail = Mail;
                u.Password = Password;
                u.esAdmin = EsADM;
                u.bloqueado = Bloqueado;
                contexto.usuarios.Update(u);
                salida = true;
            }
        if (salida)
            contexto.SaveChanges();
        return salida;

    }

        public bool autenticarUsuario(int DNI, string password)
        {
            foreach ( Usuario usu in contexto.usuarios)
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

            foreach (Usuario usu in contexto.usuarios)
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
            foreach (Usuario a in contexto.usuarios)
            {
                if (a != null && a.getBloqueado() != true)
                {
                    usu.setBloqueado(true);
                    contexto.usuarios.Update(usu);
                    return true;
                }
            }
            return false;
        }

        public bool bloquearUsuario(int dni)
        {
            foreach (Usuario a in contexto.usuarios)
            {
                if (a != null && a.getDNI() == dni)
                {
                   
                    a.setBloqueado(false);
                    contexto.usuarios.Update(a);

                    return true;
                }
            }
            return false;
        }

        private void inicializarAtributosAlojamiento()
        {

            try
            {
                //creo un contexto
                contextoAloj = new MyContextAlojamiento();
                //cargo los usuarios
                contextoAloj.alojamientos.Load();
                misAlojamientos = contextoAloj.alojamientos;
            }
            catch (Exception)
            {

            }
        }
        public List<List<string>> obtenerAlojamiento()
        {
           
            List<List<string>> aloj = new List<List<string>>();

            foreach (Alojamiento u in contextoAloj.alojamientos)       

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
                contextoAloj.SaveChanges();
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
            foreach (Alojamiento u in contextoAloj.alojamientos)
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
                    contextoAloj.alojamientos.Update(u);
                  
                    salida = true;
                }
            if (salida)
                contextoAloj.SaveChanges();
            return salida;
        }

        public bool quitarAlojamiento(Alojamiento aloj)
        {
            try
            {
                bool salida = false;
                foreach (Alojamiento u in contextoAloj.alojamientos)
                    if (u.codigo == aloj.codigo)
                    {
                        contextoAloj.alojamientos.Remove(u);
                     
                        salida = true;
                    }
                if (salida)
                    contextoAloj.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void inicializarAtributosReserva()
        {

            try
            {
                //creo un contexto
                contextoReser = new MyContextReserva();
                //cargo los usuarios
                contextoReser.reservas.Load();
             
                misReservas = contextoReser.reservas;

                contadorReservas = contextoReser.reservas.Count();

            }
            catch (Exception)
            {

            }
        }

        public List<List<string>> obtenerReserva()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Reserva u in contextoReser.reservas)
             
                salida.Add(new List<string>() { u.id.ToString(), u.fdesde.ToString(), u.fhasta.ToString(), u.precio.ToString(), u.propiedadint.ToString(), u.personaint.ToString() });
            return salida;
        }

        public List<List<string>> obtenerReservas(int dni)
        {


            List<List<string>> reser = new List<List<string>>();

            foreach (Reserva u in contextoReser.reservas)

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
            foreach (Usuario a in contexto.usuarios)
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
                contextoReser.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool modificarReserva(Reserva reservaNueva, int idAModificar) // Datos de Reserva
        {
            bool reserv = false;
            foreach (Reserva reser in contextoReser.reservas)
            {
                if (reser.id == idAModificar)
                {
                    reser.fdesde = reservaNueva.fdesde;
                    reser.fhasta = reservaNueva.fhasta;
                    reser.precio = reservaNueva.precio;
                    contextoReser.reservas.Update(reser);
                    reserv = true;
                }
            }
            if (reserv)
                contextoReser.SaveChanges();
            return reserv;
        }

        public bool eliminarReserva(Reserva reservar)
        {
            try
            {
                bool salida = false;
                foreach (Reserva u in contextoReser.reservas)
                    if (u.id == reservar.id)
                    {
                        contextoReser.reservas.Remove(u);
                   
                        salida = true;
                    }
                if (salida)
                    contextoReser.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public void cerrar()
        {
            contexto.Dispose();
            contextoAloj.Dispose();
            contextoReser.Dispose();
        }


    }
}
