using System;
using System.Collections.Generic;

namespace CoffVArt.Models;

public partial class Insumo
{
    public int IdInsumos { get; set; }

    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public double Precio { get; set; }

    public int Cantidad { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();
}
