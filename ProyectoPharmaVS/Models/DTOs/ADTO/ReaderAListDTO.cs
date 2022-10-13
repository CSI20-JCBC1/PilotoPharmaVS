using Npgsql;

namespace ProyectoPharmaVS.Models.DTOs.ADTO
{
    public class ReaderAListDTO
    {
        public static List<ProductoDTO> ReaderAListProductoDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<ProductoDTO> listAlumnos = new List<ProductoDTO>();
            while (resultadoConsulta.Read())
            {
                listAlumnos.Add(new ProductoDTO(
                    
                    resultadoConsulta[0].ToString(),
                    (int)Int64.Parse(resultadoConsulta[1].ToString()),
                    resultadoConsulta[2].ToString(),
                    resultadoConsulta[3].ToString(),
                    resultadoConsulta[4].ToString(),
                    resultadoConsulta[5].ToString(),
                    resultadoConsulta[6].ToString()
                    )
                    );

            }
            return listAlumnos;
        }
    }
}