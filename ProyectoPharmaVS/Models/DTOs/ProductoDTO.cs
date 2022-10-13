namespace ProyectoPharmaVS.Models.DTOs
{
    public class ProductoDTO
    {

            public string md_uuid { get; private set; }
            public int id_producto { get; private set; }
            public string cod_producto { get; private set; }
            public string? nombre_producto { get; private set; }
            public string? tipo_producto_origen { get; private set; }
            public string? tipo_producto_clase { get; private set; }
            public string? des_producto { get; private set; }

        public ProductoDTO(string md_uuid, int id_producto, string cod_producto, string? nombre_producto, string? tipo_producto_origen, string? tipo_producto_clase, string? des_producto)
        {
            this.md_uuid = md_uuid;
            this.id_producto = id_producto;
            this.cod_producto = cod_producto;
            this.nombre_producto = nombre_producto;
            this.tipo_producto_origen = tipo_producto_origen;
            this.tipo_producto_clase = tipo_producto_clase;
            this.des_producto = des_producto;

        }

        //Constructor ProductoDTO completo



    }
}
