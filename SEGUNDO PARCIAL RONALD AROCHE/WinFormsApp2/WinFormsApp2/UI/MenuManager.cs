using System;
using System.Linq;
using MinecraftManager.Models;
using MinecraftManager.Services;

namespace MinecraftManager.UI
{
    public class MenuManager
    {
        private readonly JugadorService _jugadorService;
        private readonly BloqueService _bloqueService;
        private readonly InventarioService _inventarioService;

        public MenuManager(JugadorService jugadorService, BloqueService bloqueService, InventarioService inventarioService)
        {
            _jugadorService = jugadorService;
            _bloqueService = bloqueService;
            _inventarioService = inventarioService;
        }

        public void MostrarMenuPrincipal()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                MostrarEncabezado("SISTEMA DE GESTIÓN DE MINECRAFT");

                Console.WriteLine("\nMENÚ PRINCIPAL:");
                Console.WriteLine("1. Gestionar Jugadores");
                Console.WriteLine("2. Gestionar Bloques");
                Console.WriteLine("3. Gestionar Inventario");
                Console.WriteLine("4. Salir");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuJugadores();
                        break;

                    case "2":
                        MenuBloques();
                        break;

                    case "3":
                        MenuInventario();
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar el Sistema de Gestión de Minecraft!");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Menú para la gestión de jugadores
        private void MenuJugadores()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                MostrarEncabezado("GESTIÓN DE JUGADORES");

                Console.WriteLine("\nOPCIONES DISPONIBLES:");
                Console.WriteLine("1. Registrar nuevo jugador");
                Console.WriteLine("2. Listar todos los jugadores");
                Console.WriteLine("3. Buscar jugador por ID");
                Console.WriteLine("4. Actualizar jugador");
                Console.WriteLine("5. Eliminar jugador");
                Console.WriteLine("6. Volver al menú principal");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarJugador();
                        break;

                    case "2":
                        ListarJugadores();
                        break;

                    case "3":
                        BuscarJugadorPorId();
                        break;

                    case "4":
                        ActualizarJugador();
                        break;

                    case "5":
                        EliminarJugador();
                        break;

                    case "6":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Menú para la gestión de bloques
        private void MenuBloques()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                MostrarEncabezado("GESTIÓN DE BLOQUES");

                Console.WriteLine("\nOPCIONES DISPONIBLES:");
                Console.WriteLine("1. Registrar nuevo bloque");
                Console.WriteLine("2. Listar todos los bloques");
                Console.WriteLine("3. Buscar bloque por ID");
                Console.WriteLine("4. Buscar bloques por tipo");
                Console.WriteLine("5. Buscar bloques por rareza");
                Console.WriteLine("6. Actualizar bloque");
                Console.WriteLine("7. Eliminar bloque");
                Console.WriteLine("8. Volver al menú principal");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarBloque();
                        break;

                    case "2":
                        ListarBloques();
                        break;

                    case "3":
                        BuscarBloquePorId();
                        break;

                    case "4":
                        BuscarBloquePorTipo();
                        break;

                    case "5":
                        BuscarBloquePorRareza();
                        break;

                    case "6":
                        ActualizarBloque();
                        break;

                    case "7":
                        EliminarBloque();
                        break;

                    case "8":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Menú para la gestión de inventario
        private void MenuInventario()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                MostrarEncabezado("GESTIÓN DE INVENTARIO");

                Console.WriteLine("\nOPCIONES DISPONIBLES:");
                Console.WriteLine("1. Agregar bloques al inventario");
                Console.WriteLine("2. Listar todo el inventario");
                Console.WriteLine("3. Ver inventario de un jugador");
                Console.WriteLine("4. Actualizar cantidad en inventario");
                Console.WriteLine("5. Eliminar elemento del inventario");
                Console.WriteLine("6. Volver al menú principal");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarAInventario();
                        break;

                    case "2":
                        ListarInventario();
                        break;

                    case "3":
                        VerInventarioJugador();
                        break;

                    case "4":
                        ActualizarInventario();
                        break;

                    case "5":
                        EliminarDeInventario();
                        break;

                    case "6":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Funciones para Jugadores
        private void RegistrarJugador()
        {
            Console.Clear();
            MostrarEncabezado("REGISTRAR NUEVO JUGADOR");

            var jugador = new Jugador();

            Console.Write("\nNombre del jugador: ");
            jugador.Nombre = Console.ReadLine();

            Console.Write("Nivel inicial (deje en blanco para nivel 1): ");
            string nivelStr = Console.ReadLine();
            jugador.Nivel = string.IsNullOrEmpty(nivelStr) ? 1 : int.Parse(nivelStr);

            try
            {
                _jugadorService.Crear(jugador);
                Console.WriteLine("\n¡Jugador registrado con éxito!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al registrar el jugador: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ListarJugadores()
        {
            Console.Clear();
            MostrarEncabezado("LISTA DE JUGADORES");

            var jugadores = _jugadorService.ObtenerTodos();

            if (jugadores.Count == 0)
            {
                Console.WriteLine("\nNo hay jugadores registrados.");
            }
            else
            {
                Console.WriteLine("\nJUGADORES REGISTRADOS:");
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine(jugador);
                }
                Console.WriteLine($"\nTotal de jugadores: {jugadores.Count}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarJugadorPorId()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR JUGADOR POR ID");

            Console.Write("\nIngrese el ID del jugador: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var jugador = _jugadorService.ObtenerPorId(id);

                if (jugador != null)
                {
                    Console.WriteLine("\nJugador encontrado:");
                    Console.WriteLine(jugador);

                    // Mostrar inventario del jugador
                    var inventario = _inventarioService.ObtenerPorJugador(jugador.Id);
                    if (inventario.Count > 0)
                    {
                        Console.WriteLine("\nInventario del jugador:");
                        foreach (var item in inventario)
                        {
                            Console.WriteLine($"- {item.Cantidad} {item.NombreBloque}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nEste jugador no tiene bloques en su inventario.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un jugador con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ActualizarJugador()
        {
            Console.Clear();
            MostrarEncabezado("ACTUALIZAR JUGADOR");

            Console.Write("\nIngrese el ID del jugador a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var jugador = _jugadorService.ObtenerPorId(id);

                if (jugador != null)
                {
                    Console.WriteLine("\nJugador encontrado:");
                    Console.WriteLine(jugador);

                    Console.WriteLine("\nIngrese los nuevos datos (deje en blanco para mantener el valor actual):");

                    Console.Write($"Nombre ({jugador.Nombre}): ");
                    string nombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nombre))
                        jugador.Nombre = nombre;

                    Console.Write($"Nivel ({jugador.Nivel}): ");
                    string nivelStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nivelStr) && int.TryParse(nivelStr, out int nivel))
                        jugador.Nivel = nivel;

                    _jugadorService.Actualizar(jugador);
                    Console.WriteLine("\n¡Jugador actualizado con éxito!");
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un jugador con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarJugador()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR JUGADOR");

            Console.Write("\nIngrese el ID del jugador a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var jugador = _jugadorService.ObtenerPorId(id);

                if (jugador != null)
                {
                    Console.WriteLine("\nJugador a eliminar:");
                    Console.WriteLine(jugador);

                    Console.Write("\n¿Está seguro de eliminar este jugador? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        _jugadorService.Eliminar(id);
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un jugador con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Funciones para Bloques
        private void RegistrarBloque()
        {
            Console.Clear();
            MostrarEncabezado("REGISTRAR NUEVO BLOQUE");

            var bloque = new Bloque();

            Console.Write("\nNombre del bloque: ");
            bloque.Nombre = Console.ReadLine();

            Console.Write("Tipo (Mineral, Madera, Piedra, Decoración, etc.): ");
            bloque.Tipo = Console.ReadLine();

            Console.Write("Rareza (Común, Raro, Épico, Legendario, etc.): ");
            bloque.Rareza = Console.ReadLine();

            _bloqueService.Crear(bloque);

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ListarBloques()
        {
            Console.Clear();
            MostrarEncabezado("LISTA DE BLOQUES");

            var bloques = _bloqueService.ObtenerTodos();

            if (bloques.Count == 0)
            {
                Console.WriteLine("\nNo hay bloques registrados.");
            }
            else
            {
                Console.WriteLine("\nBLOQUES REGISTRADOS:");
                foreach (var bloque in bloques)
                {
                    Console.WriteLine(bloque);
                }
                Console.WriteLine($"\nTotal de bloques: {bloques.Count}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarBloquePorId()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR BLOQUE POR ID");

            Console.Write("\nIngrese el ID del bloque: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var bloque = _bloqueService.ObtenerPorId(id);

                if (bloque != null)
                {
                    Console.WriteLine("\nBloque encontrado:");
                    Console.WriteLine(bloque);
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un bloque con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarBloquePorTipo()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR BLOQUES POR TIPO");

            Console.Write("\nIngrese el tipo de bloque a buscar: ");
            string tipo = Console.ReadLine();

            var bloques = _bloqueService.BuscarPorTipo(tipo);

            if (bloques.Count == 0)
            {
                Console.WriteLine($"\nNo se encontraron bloques del tipo '{tipo}'.");
            }
            else
            {
                Console.WriteLine($"\nBloques encontrados del tipo '{tipo}':");
                foreach (var bloque in bloques)
                {
                    Console.WriteLine(bloque);
                }
                Console.WriteLine($"\nTotal de bloques encontrados: {bloques.Count}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarBloquePorRareza()
        {
            Console.Clear();
            MostrarEncabezado("BUSCAR BLOQUES POR RAREZA");

            Console.Write("\nIngrese la rareza de bloque a buscar: ");
            string rareza = Console.ReadLine();

            var bloques = _bloqueService.BuscarPorRareza(rareza);

            if (bloques.Count == 0)
            {
                Console.WriteLine($"\nNo se encontraron bloques con rareza '{rareza}'.");
            }
            else
            {
                Console.WriteLine($"\nBloques encontrados con rareza '{rareza}':");
                foreach (var bloque in bloques)
                {
                    Console.WriteLine(bloque);
                }
                Console.WriteLine($"\nTotal de bloques encontrados: {bloques.Count}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ActualizarBloque()
        {
            Console.Clear();
            MostrarEncabezado("ACTUALIZAR BLOQUE");

            Console.Write("\nIngrese el ID del bloque a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var bloque = _bloqueService.ObtenerPorId(id);

                if (bloque != null)
                {
                    Console.WriteLine("\nBloque encontrado:");
                    Console.WriteLine(bloque);

                    Console.WriteLine("\nIngrese los nuevos datos (deje en blanco para mantener el valor actual):");

                    Console.Write($"Nombre ({bloque.Nombre}): ");
                    string nombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nombre))
                        bloque.Nombre = nombre;

                    Console.Write($"Tipo ({bloque.Tipo}): ");
                    string tipo = Console.ReadLine();
                    if (!string.IsNullOrEmpty(tipo))
                        bloque.Tipo = tipo;

                    Console.Write($"Rareza ({bloque.Rareza}): ");
                    string rareza = Console.ReadLine();
                    if (!string.IsNullOrEmpty(rareza))
                        bloque.Rareza = rareza;

                    _bloqueService.Actualizar(bloque);
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un bloque con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarBloque()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR BLOQUE");

            Console.Write("\nIngrese el ID del bloque a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var bloque = _bloqueService.ObtenerPorId(id);

                if (bloque != null)
                {
                    Console.WriteLine("\nBloque a eliminar:");
                    Console.WriteLine(bloque);

                    Console.Write("\n¿Está seguro de eliminar este bloque? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        _bloqueService.Eliminar(id);
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un bloque con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Funciones para Inventario
        private void AgregarAInventario()
        {
            Console.Clear();
            MostrarEncabezado("AGREGAR BLOQUES AL INVENTARIO");

            // Primero mostramos la lista de jugadores
            var jugadores = _jugadorService.ObtenerTodos();
            if (jugadores.Count == 0)
            {
                Console.WriteLine("\nNo hay jugadores registrados. Primero debe registrar un jugador.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nJUGADORES DISPONIBLES:");
            foreach (var jugador in jugadores)
            {
                Console.WriteLine($"{jugador.Id}. {jugador.Nombre}");
            }

            Console.Write("\nSeleccione el ID del jugador: ");
            if (!int.TryParse(Console.ReadLine(), out int jugadorId) || _jugadorService.ObtenerPorId(jugadorId) == null)
            {
                Console.WriteLine("\nID de jugador inválido.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Luego mostramos la lista de bloques
            var bloques = _bloqueService.ObtenerTodos();
            if (bloques.Count == 0)
            {
                Console.WriteLine("\nNo hay bloques registrados. Primero debe registrar un bloque.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nBLOQUES DISPONIBLES:");
            foreach (var bloque in bloques)
            {
                Console.WriteLine($"{bloque.Id}. {bloque.Nombre} (Tipo: {bloque.Tipo}, Rareza: {bloque.Rareza})");
            }

            Console.Write("\nSeleccione el ID del bloque: ");
            if (!int.TryParse(Console.ReadLine(), out int bloqueId) || _bloqueService.ObtenerPorId(bloqueId) == null)
            {
                Console.WriteLine("\nID de bloque inválido.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nCantidad a agregar: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
            {
                Console.WriteLine("\nCantidad inválida. Debe ser un número positivo.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            var inventario = new Inventario
            {
                JugadorId = jugadorId,
                BloqueId = bloqueId,
                Cantidad = cantidad
            };

            _inventarioService.Agregar(inventario);

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ListarInventario()
        {
            Console.Clear();
            MostrarEncabezado("LISTA COMPLETA DE INVENTARIO");

            var inventarios = _inventarioService.ObtenerTodos();

            if (inventarios.Count == 0)
            {
                Console.WriteLine("\nNo hay elementos en el inventario.");
            }
            else
            {
                Console.WriteLine("\nELEMENTOS EN INVENTARIO:");
                foreach (var inventario in inventarios)
                {
                    Console.WriteLine($"Jugador: {inventario.NombreJugador} - Bloque: {inventario.NombreBloque} - Cantidad: {inventario.Cantidad}");
                }
                Console.WriteLine($"\nTotal de registros de inventario: {inventarios.Count}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void VerInventarioJugador()
        {
            Console.Clear();
            MostrarEncabezado("VER INVENTARIO DE JUGADOR");

            // Mostrar lista de jugadores
            var jugadores = _jugadorService.ObtenerTodos();
            if (jugadores.Count == 0)
            {
                Console.WriteLine("\nNo hay jugadores registrados.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nJUGADORES DISPONIBLES:");
            foreach (var jugador in jugadores)
            {
                Console.WriteLine($"{jugador.Id}. {jugador.Nombre}");
            }

            Console.Write("\nSeleccione el ID del jugador: ");
            if (int.TryParse(Console.ReadLine(), out int jugadorId))
            {
                var jugador = _jugadorService.ObtenerPorId(jugadorId);

                if (jugador != null)
                {
                    Console.WriteLine($"\nInventario de {jugador.Nombre} (Nivel {jugador.Nivel}):");

                    var inventario = _inventarioService.ObtenerPorJugador(jugadorId);

                    if (inventario.Count == 0)
                    {
                        Console.WriteLine("\nEste jugador no tiene bloques en su inventario.");
                    }
                    else
                    {
                        foreach (var item in inventario)
                        {
                            Console.WriteLine($"- {item.Cantidad} {item.NombreBloque}");
                        }

                        // Sumar el total de bloques
                        int totalBloques = inventario.Sum(i => i.Cantidad);
                        Console.WriteLine($"\nTotal de bloques: {totalBloques}");
                        Console.WriteLine($"Total de tipos de bloques: {inventario.Count}");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un jugador con ID {jugadorId}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ActualizarInventario()
        {
            Console.Clear();
            MostrarEncabezado("ACTUALIZAR CANTIDAD EN INVENTARIO");

            var inventarios = _inventarioService.ObtenerTodos();

            if (inventarios.Count == 0)
            {
                Console.WriteLine("\nNo hay elementos en el inventario.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nELEMENTOS EN INVENTARIO:");
            foreach (var inv in inventarios)
            {
                Console.WriteLine($"ID: {inv.Id} - Jugador: {inv.NombreJugador} - Bloque: {inv.NombreBloque} - Cantidad: {inv.Cantidad}");
            }

            Console.Write("\nIngrese el ID del registro a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Buscar el inventario
                var inventario = inventarios.FirstOrDefault(i => i.Id == id);

                if (inventario != null)
                {
                    Console.WriteLine($"\nVa a actualizar: {inventario.NombreJugador} - {inventario.NombreBloque} - Cantidad actual: {inventario.Cantidad}");

                    Console.Write("\nNueva cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaCantidad) && nuevaCantidad > 0)
                    {
                        inventario.Cantidad = nuevaCantidad;
                        _inventarioService.Actualizar(inventario);
                    }
                    else
                    {
                        Console.WriteLine("\nCantidad inválida. Debe ser un número positivo.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un registro de inventario con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarDeInventario()
        {
            Console.Clear();
            MostrarEncabezado("ELIMINAR ELEMENTO DEL INVENTARIO");

            var inventarios = _inventarioService.ObtenerTodos();

            if (inventarios.Count == 0)
            {
                Console.WriteLine("\nNo hay elementos en el inventario.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nELEMENTOS EN INVENTARIO:");
            foreach (var inv in inventarios)
            {
                Console.WriteLine($"ID: {inv.Id} - Jugador: {inv.NombreJugador} - Bloque: {inv.NombreBloque} - Cantidad: {inv.Cantidad}");
            }

            Console.Write("\nIngrese el ID del registro a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // Buscar el inventario
                var inventario = inventarios.FirstOrDefault(i => i.Id == id);

                if (inventario != null)
                {
                    Console.WriteLine($"\nVa a eliminar: {inventario.NombreJugador} - {inventario.NombreBloque} - Cantidad: {inventario.Cantidad}");

                    Console.Write("\n¿Está seguro de eliminar este registro del inventario? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        _inventarioService.Eliminar(id);
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un registro de inventario con ID {id}.");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Función para mostrar encabezados con estilo
        private static void MostrarEncabezado(string titulo)
        {
            string borde = new string('=', titulo.Length + 10);

            Console.WriteLine(borde);
            Console.WriteLine($"    {titulo}    ");
            Console.WriteLine(borde);
        }
    }
}