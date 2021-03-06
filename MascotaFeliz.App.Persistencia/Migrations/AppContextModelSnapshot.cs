// <auto-generated />
using System;
using MascotaFeliz.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MascotaFeliz.App.Dominio.HistorialVisitas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Fechas")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("HistorialesDeVisita");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Animo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaVisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrecuenciaRespiratoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDVete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.MascotaAfiliada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("MascotasAfiliadas");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Medicamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Dosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.HistorialVisitas", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("MascotaFeliz.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Cliente");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.MascotaAfiliada", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Mascota", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Medicamentos", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}
