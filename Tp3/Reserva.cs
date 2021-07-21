using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class Reserva
    {
        public int pk { get; set; }
        public int id;
        public DateTime fdesde;
        public DateTime fhasta;
        public Alojamiento propiedad;
        public Usuario persona;
        public int propiedadint;
        public int personaint;
        public int precio;       

        public Reserva(int Id,DateTime Fdesde, DateTime Fhasta, int Precio, int Propiedadint, int Personaint)
        {
            id=Id;
            fdesde = Fdesde;
            fhasta = Fhasta;
            propiedadint = Propiedadint;
            personaint = Personaint;
            precio = Precio;
        }
        public Reserva()
        {

        }

        public override string ToString()
        {
            return id + " - " + fdesde + " - " + fhasta + " - " + propiedad + " - " + persona + " - " + precio;
        }

        public void setID(int ID) { id = ID; }
        public void setPropiedadInt(int Propiedadint) { propiedadint = Propiedadint; }
        public void setPersonaInt(int PersonaInt) { personaint = PersonaInt; }

        public void setPk(int pk) { this.pk = pk;  }

        public void setFDesde(DateTime FDesde) { fdesde = FDesde; }
        public void setFHasta(DateTime FHasta) { fhasta = FHasta; }
        public void setPropiedad(Alojamiento Propiedad) { propiedad = Propiedad; }
        public void setPersona(Usuario persona) { this.persona = persona; }
        public void setPrecio(int Precio) { precio = Precio; }

        public int getID() { return id; }
        public DateTime getFDesde() { return fdesde; }
        public DateTime getFHasta() { return fhasta; }
        public Alojamiento getPropiedad() { return propiedad; }
        public Usuario getPersona() { return persona; }
        public int getPrecio() { return precio; }

        public int getPk() { return pk; }

        public int getPropiedadInt() { return propiedadint; }
        public int getPersonaint() { return personaint; }

    }
}
