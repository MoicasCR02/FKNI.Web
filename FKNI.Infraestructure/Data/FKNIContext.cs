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

    public virtual DbSet<Imagenes> Imagenes { get; set; }

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
            entity.HasKey(e => e.IdCarrito).HasName("PK__Carrito__83A2AD9CD86F1A32");

            entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Carrito)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Carrito__id_usua__47DBAE45");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5ABFFC1AC4");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<DetalleCarrito>(entity =>
        {
            entity.HasKey(e => new { e.IdCarrito, e.IdProducto }).HasName("PK__DetalleC__4C51EC5CE185A591");

            entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__id_ca__4AB81AF0");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__id_pr__4BAC3F29");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleP__4F1332DED61178F8");

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
                .HasConstraintName("FK__DetallePe__id_pe__5812160E");
        });

        modelBuilder.Entity<DetallePedidoProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto }).HasName("PK__DetalleP__A003554999873F57");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidoProducto)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__id_pe__5AEE82B9");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidoProducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__id_pr__5BE2A6F2");
        });

        modelBuilder.Entity<Estados>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__86989FB2E43BCAC4");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<Etiquetas>(entity =>
        {
            entity.HasKey(e => e.IdEtiqueta).HasName("PK__Etiqueta__FA0DD2AD74EBD049");

            entity.Property(e => e.IdEtiqueta).HasColumnName("id_etiqueta");
            entity.Property(e => e.NombreEtiqueta)
                .HasMaxLength(100)
                .HasColumnName("nombre_etiqueta");
        });

        modelBuilder.Entity<Imagenes>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__27CC26896D875382");

            entity.Property(e => e.IdImagen).HasColumnName("id_imagen");
            entity.Property(e => e.UrlImagen).HasColumnName("url_imagen");

            entity.HasMany(d => d.IdProducto).WithMany(p => p.IdImagen)
                .UsingEntity<Dictionary<string, object>>(
                    "ImagenesProducto",
                    r => r.HasOne<Productos>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ImagenesP__id_pr__33D4B598"),
                    l => l.HasOne<Imagenes>().WithMany()
                        .HasForeignKey("IdImagen")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ImagenesP__id_im__32E0915F"),
                    j =>
                    {
                        j.HasKey("IdImagen", "IdProducto").HasName("PK__Imagenes__E83F674963A548A2");
                        j.IndexerProperty<int>("IdImagen").HasColumnName("id_imagen");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("id_producto");
                    });
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__0941B0745DE7A7E8");

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
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__6FF0148920BE1F12");

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
                .HasConstraintName("FK__Pedidos__id_clie__52593CB8");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Pedidos__id_esta__5441852A");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK__Pedidos__id_pago__5535A963");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0DB0C5614F");

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
                        .HasConstraintName("FK__ProductoE__id_et__398D8EEE"),
                    l => l.HasOne<Productos>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductoE__id_pr__38996AB5"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdEtiqueta").HasName("PK__Producto__3094C1273D16F654");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("id_producto");
                        j.IndexerProperty<int>("IdEtiqueta").HasColumnName("id_etiqueta");
                    });
        });

        modelBuilder.Entity<Promociones>(entity =>
        {
            entity.HasKey(e => e.IdPromocion).HasName("PK__Promocio__F89308E05FB6B165");

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

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Promociones)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Promocion__id_ca__44FF419A");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Promociones)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Promocion__id_pr__440B1D61");
        });

        modelBuilder.Entity<Resenas>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdProducto }).HasName("PK__Resenas__81CD456D7E12B22A");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Valoracion).HasColumnName("valoracion");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resenas__id_prod__403A8C7D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resenas__id_usua__3F466844");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__6ABCB5E0BBD05391");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD31D2627D");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__2A586E0B7EF68FC9").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(200)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__id_rol__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
