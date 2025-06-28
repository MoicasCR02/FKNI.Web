using System;
using System.Collections.Generic;
using FKNI.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FKNI.Infraestructure.Data;

public partial class FKNIContext : DbContext
{
    public FKNIContext(DbContextOptions<FKNIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carrito { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<DetalleCarrito> DetalleCarrito { get; set; }

    public virtual DbSet<DetallePedido> DetallePedido { get; set; }

    public virtual DbSet<DetallePedidoProducto> DetallePedidoProducto { get; set; }

    public virtual DbSet<Estados> Estados { get; set; }

    public virtual DbSet<Etiquetas> Etiquetas { get; set; }

    public virtual DbSet<ImagenesProducto> ImagenesProducto { get; set; }

    public virtual DbSet<Pagos> Pagos { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Promociones> Promociones { get; set; }

    public virtual DbSet<Resenas> Resenas { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__Carrito__83A2AD9CCE0EFAB1");

            entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Carrito)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Carrito__id_usua__4316F928");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5A1D52673E");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<DetalleCarrito>(entity =>
        {
            entity.HasKey(e => new { e.IdCarrito, e.IdProducto }).HasName("PK__DetalleC__4C51EC5C0A0BD30F");

            entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__id_ca__45F365D3");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__id_pr__46E78A0C");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__4F1332DE320E02DC");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Impuesto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("impuesto");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TotalConImpuesto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_con_impuesto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedido)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__DetallePe__id_pe__534D60F1");
        });

        modelBuilder.Entity<DetallePedidoProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto }).HasName("PK__DetalleP__A003554911A04362");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidoProducto)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__id_pe__5629CD9C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidoProducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__id_pr__571DF1D5");
        });

        modelBuilder.Entity<Estados>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__86989FB2B9328251");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<Etiquetas>(entity =>
        {
            entity.HasKey(e => e.IdEtiqueta).HasName("PK__Etiqueta__FA0DD2AD44AC2F1C");

            entity.Property(e => e.IdEtiqueta).HasColumnName("id_etiqueta");
            entity.Property(e => e.NombreEtiqueta)
                .HasMaxLength(100)
                .HasColumnName("nombre_etiqueta");
        });

        modelBuilder.Entity<ImagenesProducto>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__27CC2689400E5E81");

            entity.Property(e => e.IdImagen).HasColumnName("id_imagen");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(255)
                .HasColumnName("url_imagen");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ImagenesProducto)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__ImagenesP__id_pr__30F848ED");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__0941B07406733CBC");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.CostoEnvio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_envio");
            entity.Property(e => e.DireccionEntrega).HasColumnName("direccion_entrega");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Vuelto).HasColumnName("vuelto");
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__6FF01489F0CD8C57");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.DireccionEnvio).HasColumnName("direccion_envio");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pedido");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.MetodoEntrega)
                .HasMaxLength(50)
                .HasColumnName("metodo_entrega");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedidos__id_clie__4D94879B");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Pedidos__id_esta__4F7CD00D");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK__Pedidos__id_pago__5070F446");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0DB2E8A34D");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.PromedioValoracion)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("promedio_valoracion");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Productos__id_ca__2D27B809");

            entity.HasMany(d => d.IdEtiqueta).WithMany(p => p.IdProducto)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoEtiqueta",
                    r => r.HasOne<Etiquetas>().WithMany()
                        .HasForeignKey("IdEtiqueta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductoE__id_et__36B12243"),
                    l => l.HasOne<Productos>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductoE__id_pr__35BCFE0A"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdEtiqueta").HasName("PK__Producto__3094C12711675D56");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("id_producto");
                        j.IndexerProperty<int>("IdEtiqueta").HasColumnName("id_etiqueta");
                    });
        });

        modelBuilder.Entity<Promociones>(entity =>
        {
            entity.HasKey(e => e.IdPromocion).HasName("PK__Promocio__F89308E027C785C3");

            entity.Property(e => e.IdPromocion).HasColumnName("id_promocion");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.TipoPromocion)
                .HasMaxLength(20)
                .HasColumnName("tipo_promocion");
        });

        modelBuilder.Entity<Resenas>(entity =>
        {
            entity.HasKey(e => e.IdResena).HasName("PK__Resenas__06CD936385C4C8A5");

            entity.Property(e => e.IdResena).HasColumnName("id_resena");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Valoracion).HasColumnName("valoracion");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Resenas__id_prod__3A81B327");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Resenas__id_usua__398D8EEE");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__6ABCB5E011FD52EE");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.id_usuario).HasName("PK__Usuarios__4E3E04ADC4B4879E");

            entity.HasIndex(e => e.correo, "UQ__Usuarios__2A586E0B05F2E298").IsUnique();

            entity.Property(e => e.id_usuario).HasColumnName("id_usuario");
            entity.Property(e => e.contrasena)
                .HasMaxLength(200)
                .HasColumnName("contrasena");
            entity.Property(e => e.correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.fecha_registro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.id_rol).HasColumnName("id_rol");
            entity.Property(e => e.nombre_usuario)
                .HasMaxLength(100)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.id_rol)
                .HasConstraintName("FK__Usuarios__id_rol__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
