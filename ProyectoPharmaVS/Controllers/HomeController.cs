using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ProyectoPharmaVS.Models;
using ProyectoPharmaVS.Models.Conexiones;
using System.Diagnostics;
using static ProyectoPharmaVS.Util.VariableConexionPostgreSQL;
using ProyectoPharmaVS.Models.Consultas;
using ProyectoPharmaVS.Models.DTOs;

namespace ProyectoPharmaVS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            // Profesor

            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            //Generamos conexión con postgre y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<ProductoDTO> listProductoDTO = new List<ProductoDTO>();

            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);
            

            ConsultasPostgre.ConsultaInsertPostgreSQL(conexionGenerada);

            listProductoDTO = ConsultasPostgre.ConsultaSelectPostgreSQL(conexionGenerada);
            int cont = listProductoDTO.Count();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista compuesta por: " + cont + " productos");
            Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista productos:");
            foreach (ProductoDTO producto in listProductoDTO)
                System.Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", producto.md_uuid,
                 producto.id_producto, producto.cod_producto, producto.nombre_producto, producto.tipo_producto_origen, producto.tipo_producto_clase, producto.des_producto);


            conexionGenerada.Close();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}