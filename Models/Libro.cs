using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Actividad4ApiSegura.Models;

public partial class Libro
{
    [Key]
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int AnioPublicacion { get; set; }

    public string Genero { get; set; } = null!;

    public int NumeroPaginas { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public bool Disponible { get; set; }

    public int AutorId { get; set; }

    [ForeignKey("AutorId")]
    public virtual Autor Autor { get; set; } = null!;
}
