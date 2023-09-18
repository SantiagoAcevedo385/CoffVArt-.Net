using System;
using System.Collections.Generic;

namespace CoffVArt.Models;

public partial class DetallesCompra
{
    public int DetalleCompraId { get; set; }

    public int CompraId { get; set; }

    public int InsumoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Insumo Insumo { get; set; } = null!;
}
