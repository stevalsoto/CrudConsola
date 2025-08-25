using CrudConsola.Services;

namespace CrudConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicio = new PersonaService();
            int opcion = 0;

            do
            {
                MostrarMenu();
                string? entradaOpcion = Console.ReadLine();

                if (!int.TryParse(entradaOpcion, out opcion))
                {
                    Console.WriteLine("⚠️ Ingresa un número válido (1-5)");
                    Pausa();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        CrearPersona(servicio);
                        break;
                    case 2:
                        LeerPersonas(servicio);
                        break;
                    case 3:
                        ActualizarPersona(servicio);
                        break;
                    case 4:
                        EliminarPersona(servicio);
                        break;
                    case 5:
                        Console.WriteLine("👋 Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción no válida, elige entre 1 y 5.");
                        break;
                }

                if (opcion != 5) Pausa();

            } while (opcion != 5);
        }

        // =================== MÉTODOS AUXILIARES ===================

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("===== CRUD en Consola =====");
            Console.WriteLine("1. Crear persona");
            Console.WriteLine("2. Leer personas");
            Console.WriteLine("3. Actualizar persona");
            Console.WriteLine("4. Eliminar persona");
            Console.WriteLine("5. Salir");
            Console.Write("👉 Elige una opción: ");
        }

        static void CrearPersona(PersonaService servicio)
        {
            Console.Write("👉 Ingresa el nombre: ");
            string? inputNombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputNombre))
            {
                Console.WriteLine("⚠️ El nombre no puede estar vacío.");
                return;
            }

            Console.Write("👉 Ingresa la edad: ");
            string? inputEdad = Console.ReadLine();

            if (!int.TryParse(inputEdad, out int edad) || edad < 0 || edad > 120)
            {
                Console.WriteLine("⚠️ Ingresa una edad válida (0-120).");
                return;
            }

            servicio.Crear(inputNombre, edad);
            Console.WriteLine("✅ Persona creada con éxito.");
        }

        static void LeerPersonas(PersonaService servicio)
        {
            var lista = servicio.Leer();

            if (lista.Count == 0)
            {
                Console.WriteLine("📭 No hay personas registradas.");
                return;
            }

            Console.WriteLine("\n--- Lista de Personas ---");
            foreach (var p in lista)
            {
                Console.WriteLine($"🆔 Id: {p.Id}, 👤 Nombre: {p.Nombre}, 🎂 Edad: {p.Edad}");
            }
        }

        static void ActualizarPersona(PersonaService servicio)
        {
            if (!ValidarListaNoVacia(servicio)) return;

            Console.Write("👉 Ingresa el Id a actualizar: ");
            string? inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("⚠️ Ingresa un Id numérico válido.");
                return;
            }

            Console.Write("👉 Nuevo nombre: ");
            string? inputNombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputNombre))
            {
                Console.WriteLine("⚠️ El nombre no puede estar vacío.");
                return;
            }

            Console.Write("👉 Nueva edad: ");
            string? inputEdad = Console.ReadLine();
            if (!int.TryParse(inputEdad, out int edad) || edad < 0 || edad > 120)
            {
                Console.WriteLine("⚠️ Edad inválida (0-120).");
                return;
            }

            if (servicio.Actualizar(id, inputNombre, edad))
                Console.WriteLine("✅ Persona actualizada correctamente.");
            else
                Console.WriteLine("⚠️ Persona no encontrada.");
        }

        static void EliminarPersona(PersonaService servicio)
        {
            if (!ValidarListaNoVacia(servicio)) return;

            Console.Write("👉 Ingresa el Id a eliminar: ");
            string? inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("⚠️ Ingresa un Id numérico válido.");
                return;
            }

            var lista = servicio.Leer();
            var persona = lista.Find(p => p.Id == id);
            if (persona == null)
            {
                Console.WriteLine("⚠️ Persona no encontrada.");
                return;
            }

            Console.Write($"❓¿Estás seguro de eliminar a {persona.Nombre}? (s/n): ");
            string? confirmacion = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(confirmacion) && confirmacion.ToLower() == "s")
            {
                if (servicio.Eliminar(id))
                    Console.WriteLine("🗑️ Persona eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("🚫 Eliminación cancelada.");
            }
        }

        static bool ValidarListaNoVacia(PersonaService servicio)
        {
            if (servicio.Leer().Count == 0)
            {
                Console.WriteLine("📭 No hay personas registradas.");
                return false;
            }
            return true;
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}