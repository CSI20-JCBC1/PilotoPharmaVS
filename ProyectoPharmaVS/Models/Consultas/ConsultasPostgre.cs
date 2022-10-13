using Npgsql;
using ProyectoPharmaVS.Models.DTOs;

namespace ProyectoPharmaVS.Models.Consultas
{
    public class ConsultasPostgre
    {
        public static void ConsultaInsertPostgreSQL(NpgsqlConnection conexionGenerada)
        {

            try
            {
                //Se define y ejecuta la consulta Insert
                NpgsqlCommand insert = new NpgsqlCommand("INSERT INTO \"dlk_operacional_productos\".opr_cat_productos ( md_uuid, cod_producto, nombre_producto, tipo_producto_origen, tipo_producto_clase, des_producto) VALUES ('adf131029022fch12345', 'hig_p_gelf_f', 'Gel de aceite de fresa, Farlane.', 'Propio', 'Higiene', 'Gel de aceite de fresa producido por marca propia Farlane.');", conexionGenerada);
                NpgsqlDataReader resultadoInsert = insert.ExecuteReader();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaInsertPostgreSQL] INSERT realizado correctamente");

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar insert: " + e);
                conexionGenerada.Close();

            }

        }

        public static List<ProductoDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<ProductoDTO> listProductos = new List<ProductoDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT md_uuid, cod_producto, nombre_producto, tipo_producto_origen, tipo_producto_clase, des_producto  FROM \"dlk_operacional_productos\".opr_cat_productos", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de productoDTO
                listProductos = DTOs.ADTO.ReaderAListDTO.ReaderAListProductoDTO(resultadoConsulta);
                int cont = listProductos.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " productos");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conjunto de datos");

                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listProductos;
        }


    }
}
