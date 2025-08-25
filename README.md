# Proyecto CRUD en C# (Consola)

Este proyecto es una **aplicación de consola en C#** que implementa las operaciones básicas de un CRUD (**Crear, Leer, Actualizar y Eliminar**) utilizando una lista en memoria.  

La finalidad es **practicar la lógica de programación, validación de datos y organización del código en capas** como paso previo a trabajar con **bases de datos SQL (SQLite/SQL Server) y Entity Framework Core**.

---

## 🚀 Características

- Proyecto en **C# con .NET 6+/7/8**.  
- CRUD completo con operaciones en memoria:
  - ➕ **Crear**: registrar nuevas personas con nombre y edad.  
  - 📋 **Leer**: mostrar la lista completa de personas.  
  - ✏️ **Actualizar**: editar los datos de una persona existente.  
  - 🗑️ **Eliminar**: borrar un registro con confirmación.  
- Validaciones incluidas:
  - Nombres vacíos o inválidos.  
  - Edad fuera de rango (0–120).  
  - Id inexistente o no numérico.  
  - Confirmación antes de eliminar.  
- Separación en carpetas para simular un proyecto real:
  - `Models` → modelo de datos.  
  - `Services` → lógica de negocio (CRUD).  
  - `Program.cs` → interfaz de consola con menú.  

---

## 📂 Estructura del proyecto
CRUDConsola/

├── Models/

│ └── Persona.cs

├── Services/

│ └── PersonaService.cs

└── Program.cs

---

## 🛠️ Requisitos

- Tener instalado el **.NET SDK 6.0 o superior** 👉 [Descargar aquí](https://dotnet.microsoft.com/en-us/download)  
- Un editor como **Visual Studio Code** o **Visual Studio**  

---

## ▶️ Ejecución del proyecto

1. Clonar el repositorio:  

   ```bash
   git clone https://github.com/TU-USUARIO/CRUDConsola.git
   cd CRUDConsola
Compilar y ejecutar la aplicación:

bash
dotnet run
Seguir las instrucciones del menú en consola:

text
===== CRUD en Consola =====
1. Crear persona
2. Leer personas
3. Actualizar persona
4. Eliminar persona
5. Salir
👉 Elige una opción:
