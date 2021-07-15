using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class Usuario
    {
        public int DNI;
        public string Nombre;
        public string Mail;
        public string Password;
        public bool esAdmin;
        public bool bloqueado;
        List<Usuario> usuarios = new List<Usuario> { };
        public int num_usr { get; set; }

        public Usuario(int DNI, string nom, string mail, string pass)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;
            bloqueado = false;
            esAdmin = false;

        }
        public Usuario(int DNI, string nom, string mail, string pass,bool esAdmin, bool bloq)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;
            this.esAdmin = esAdmin;
            bloqueado = bloq;

        }
        public Usuario()
        {

        }

        public bool insertarUsuario(Usuario usu)
        {
            foreach (Usuario a in usuarios)

                if (a != null && a.getDNI() != usu.getDNI())
                {

                    usuarios.Add(usu);
                    return true;

                }

            return false;
        }


        public void setDNI(int dni)
        {
            DNI = dni;
        }
        public int getDNI()
        {
            return DNI;
        }
        public bool igualCodigoUsuario(Usuario a)
        {
            return DNI == a.getDNI();
        }
        public void setNombre(String nom)
        {
            Nombre = nom;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public void setMail(String mail)
        {
            Mail = mail;
        }
        public String getMail()
        {
            return Mail;
        }
        public void setPassword(String pass)
        {
            Password = pass;
        }
        public String getPassword()
        {
            return Password;
        }
        public void setesAdmin(bool adm)
        {
            esAdmin = adm;
        }
        public bool getesAdmin()
        {
            return esAdmin;
        }
        public void setBloqueado(bool bloq)
        {
            bloqueado = bloq;
        }
        public bool getBloqueado()
        {
            return bloqueado;
        }

        override public String ToString()
        {
            return DNI + "," + Nombre + "," + Mail + "," + Password + "," + bloqueado + "," + esAdmin;
        }
    }
}
