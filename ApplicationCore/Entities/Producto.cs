using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Producto : BaseEntity<int>, IAggregateRoot
    {
        private decimal _precioCompra = 0;
        private decimal _precioVenta = 0;

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCompra 
        {
            get
            {
                return _precioCompra;
            }

            set
            {
                _precioCompra = value;
            }
        }
        public decimal PrecioVenta
        {
            get
            {
                return _precioVenta;
            }

            set
            {
                _precioVenta = value;
            }
        }
        public decimal Utilidad 
        {
            get
            {
                return this.Utilidad;
            }
            set
            {
               Utilidad = _precioVenta - _precioCompra;
            }
        }
        public bool Activo { get; set; }
    }
}
