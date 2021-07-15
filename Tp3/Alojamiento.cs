
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class Alojamiento
    {
        public int pk { get; set; }
        public int codigo;
        public string nombre;
        public string ciudad;
        public string barrio;
        public int estrellas;
        public int cantPersonas;
        public bool tv;

        public int precioDia;
        public int habitaciones;
        public int baños;

        public int precioPorPersona;

        public string tipo;

        public Alojamiento(int Codigo,string Tipo, string Ciudad, string Barrio, int Estrellas, int CantPersonas, bool Tv, int PrecioDIA,int PrecioPorPersona, int Habitaciones, int Baños, string Nombre)
        {
            codigo = Codigo;
            nombre = Nombre;
            barrio = Barrio;
            ciudad = Ciudad;
            estrellas = Estrellas;
            cantPersonas = CantPersonas;
            tv = Tv;
            precioDia = PrecioDIA;
            precioPorPersona = PrecioPorPersona;
            habitaciones = Habitaciones;
            baños = Baños;
            tipo = Tipo;
        }

        public Alojamiento()
        {

        }

        public override string ToString()
        {
            return codigo + " - " + nombre + " - " + ciudad + " - " + barrio + " - " + estrellas;
        }
        public bool igualCodigo(Alojamiento a)
        {
            return codigo == a.getCodigo();
        }


        public void setPrecioDia(int pred) { precioDia = pred; }
        public void setPrecioPorPersona(int predp) { precioPorPersona = predp; }
        public void setCodigo(int Codigo) { codigo = Codigo; }
        public void setHabitaciones(int hab) { habitaciones = hab; }
        public void seBaños(int bañ) { baños = bañ; }

        public void setNombre(string Nombre) { nombre = Nombre; }
        public void setTipo(string Tipo) { tipo = Tipo; }
        public void setEstrellas(int Estrellas) { estrellas = Estrellas; }
        public void setCiudad(string Ciudad) { ciudad = Ciudad; }
        public void setBarrio(string Barrio) { barrio = Barrio; }
        public void setCantPersonas(int CantPersonas) { cantPersonas = CantPersonas; }
        public void setTV(bool tieneTV) { tv = tieneTV; }


        public int getPrecioDia() { return precioDia; }
        public int getPrecioPorPersona() { return precioPorPersona; }
        public int getHabitaciones() { return habitaciones; }
        public int getbaños() { return baños; }

        public int getCodigo() { return codigo; }
        public string getNombre() { return nombre; }
        public string getTipo() { return tipo; }
        public string getCiudad() { return ciudad; }
        public bool getTV() { return tv; }
        public string getBarrio() { return barrio; }
        public int getEstrellas() { return estrellas; }
        public int getCantPersonas() { return cantPersonas; }


    }
}
