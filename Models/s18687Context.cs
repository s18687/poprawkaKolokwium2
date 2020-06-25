using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace poprawka.Models
{
    public partial class s18687Context : DbContext
    {
        public s18687Context()
        {
        }

        public s18687Context(DbContextOptions<s18687Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<BreedType> BreedType { get; set; }
        public virtual DbSet<Championship> Championship { get; set; }
        public virtual DbSet<ChampionshipTeam> ChampionshipTeam { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<IdWyrobuCukierniczego> IdWyrobuCukierniczego { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }
        public virtual DbSet<VolunteerPet> VolunteerPet { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18687;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("Animal_pk");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Owner");
            });

            modelBuilder.Entity<BreedType>(entity =>
            {
                entity.HasKey(e => e.IdBreedType)
                    .HasName("BreedType_pk");

                entity.Property(e => e.IdBreedType).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Championship>(entity =>
            {
                entity.HasKey(e => e.IdChampionship)
                    .HasName("Championship_pk");

                entity.Property(e => e.IdChampionship).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChampionshipTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdTeam, e.IdChampionship })
                    .HasName("Championship_Team_pk");

                entity.ToTable("Championship_Team");

                entity.HasOne(d => d.IdChampionshipNavigation)
                    .WithMany(p => p.ChampionshipTeam)
                    .HasForeignKey(d => d.IdChampionship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Championship_Team_Championship");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.ChampionshipTeam)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Championship_Team_Team");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<IdWyrobuCukierniczego>(entity =>
            {
                entity.HasKey(e => e.IdWyrobuCukierniczego1)
                    .HasName("IdWyrobuCukierniczego_pk");

                entity.Property(e => e.IdWyrobuCukierniczego1)
                    .HasColumnName("IdWyrobuCukierniczego")
                    .ValueGeneratedNever();

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisk)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("Owner_pk");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("Pet_pk");

                entity.Property(e => e.IdPet).ValueGeneratedNever();

                entity.Property(e => e.ApprocimateDateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateAdopted).HasColumnType("datetime");

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdBreedTypeNavigation)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.IdBreedType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_BreedType");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer)
                    .HasName("Player_pk");

                entity.Property(e => e.IdPlayer).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdTeam, e.IdPlayer })
                    .HasName("Player_Team_pk");

                entity.ToTable("Player_Team");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.IdPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Team_Player");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Team_Team");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(e => e.IdProcedure)
                    .HasName("Procedure_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcedureAnimal>(entity =>
            {
                entity.HasKey(e => new { e.ProcedureIdProcedure, e.AnimalIdAnimal, e.Date })
                    .HasName("Procedure_Animal_pk");

                entity.ToTable("Procedure_Animal");

                entity.Property(e => e.ProcedureIdProcedure).HasColumnName("Procedure_IdProcedure");

                entity.Property(e => e.AnimalIdAnimal).HasColumnName("Animal_IdAnimal");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.AnimalIdAnimalNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.AnimalIdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Animal");

                entity.HasOne(d => d.ProcedureIdProcedureNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.ProcedureIdProcedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Procedure");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("Team_pk");

                entity.Property(e => e.IdTeam).ValueGeneratedNever();

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("Volunteer_pk");

                entity.Property(e => e.IdVolunteer).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.InverseIdSupervisorNavigation)
                    .HasForeignKey(d => d.IdSupervisor)
                    .HasConstraintName("Volunteer_Volunteer");
            });

            modelBuilder.Entity<VolunteerPet>(entity =>
            {
                entity.HasKey(e => new { e.IdPet, e.IdVolunteer })
                    .HasName("Volunteer_Pet_pk");

                entity.ToTable("Volunteer_Pet");

                entity.Property(e => e.DataAccepted).HasColumnType("datetime");

                entity.HasOne(d => d.IdPetNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdPet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Pet");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Volunteer");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.DataPrzyjecia).HasColumnType("datetime");

                entity.Property(e => e.DataRealizacji).HasColumnType("datetime");

                entity.Property(e => e.KlientIdKlient).HasColumnName("Klient_IdKlient");

                entity.Property(e => e.PracownikIdPracownik).HasColumnName("Pracownik_IdPracownik");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.KlientIdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientIdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.PracownikIdPracownikNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PracownikIdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownik");
            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => new { e.ZamowienieIdZamowienia, e.IdWyrobuCukierniczegoIdWyrobuCukierniczego })
                    .HasName("Zamowienie_WyrobCukierniczy_pk");

                entity.ToTable("Zamowienie_WyrobCukierniczy");

                entity.Property(e => e.ZamowienieIdZamowienia).HasColumnName("Zamowienie_IdZamowienia");

                entity.Property(e => e.IdWyrobuCukierniczegoIdWyrobuCukierniczego).HasColumnName("IdWyrobuCukierniczego_IdWyrobuCukierniczego");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.IdWyrobuCukierniczegoIdWyrobuCukierniczegoNavigation)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.IdWyrobuCukierniczegoIdWyrobuCukierniczego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_WyrobCukierniczy_IdWyrobuCukierniczego");

                entity.HasOne(d => d.ZamowienieIdZamowieniaNavigation)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.ZamowienieIdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_WyrobCukierniczy_Zamowienie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
