using CrudConsola.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudConsola.Services
{
    public class PersonaService
    {
        private List<Persona> personas = new List<Persona>();
        private int ultimoId = 0;

        public void Crear(string nombre, int edad)
        {
            ultimoId++;
            personas.Add(new Persona { Id = ultimoId, Nombre = nombre, Edad = edad });
        }

        public List<Persona> Leer()
        {
            return personas;
        }

        public bool Actualizar(int id, string nombre, int edad)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null) return false;

            persona.Nombre = nombre;
            persona.Edad = edad;
            return true;
        }

        public bool Eliminar(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null) return false;
            personas.Remove(persona);
            return true;
        }
    }
}