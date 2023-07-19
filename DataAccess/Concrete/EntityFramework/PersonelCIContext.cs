using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public partial class PersonelCIContext : DbContext
    {
        public PersonelCIContext()
        {
        }

        public PersonelCIContext(DbContextOptions<PersonelCIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departman> Departmen { get; set; } = null!;
        public virtual DbSet<Durak> Duraks { get; set; } = null!;
        public virtual DbSet<Kimlik1> Kimlik1s { get; set; } = null!;
        public virtual DbSet<Overtime> Overtimes { get; set; } = null!;
        public virtual DbSet<Personel1> Personel1s { get; set; } = null!;
        public virtual DbSet<Personelovertime> Personelovertimes { get; set; } = null!;
        public virtual DbSet<Personelshift> Personelshifts { get; set; } = null!;
        public virtual DbSet<Servi> Servis { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.79;Database=PersonelCI;User Id=MSSQLMASTER;Password=helloWorld1991.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Turkish_CI_AS");

            modelBuilder.Entity<Departman>(entity =>
            {
                entity.HasKey(e => new { e.Srkodu, e.Kodu });

                entity.ToTable("DEPARTMAN");

                entity.HasIndex(e => new { e.Srkodu, e.Kodu }, "IDX_YN_01");

                entity.Property(e => e.Srkodu).HasColumnName("SRKODU");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("KODU")
                    .IsFixedLength();

                entity.Property(e => e.Adi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADI");

                entity.Property(e => e.Harekleme)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HAREKLEME")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Idno).HasColumnName("IDNO");

                entity.Property(e => e.NormKadro).HasColumnName("NORM_KADRO");

                entity.Property(e => e.Sirket)
                    .HasColumnName("SIRKET")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Durak>(entity =>
            {
                entity.HasKey(e => new { e.Srkodu, e.ServisKodu, e.DurakKodu });

                entity.ToTable("DURAK");

                entity.Property(e => e.Srkodu).HasColumnName("SRKODU");

                entity.Property(e => e.ServisKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SERVIS_KODU");

                entity.Property(e => e.DurakKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DURAK_KODU");

                entity.Property(e => e.DurakAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DURAK_ADI");

                entity.Property(e => e.Idno)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDNO");
            });

            modelBuilder.Entity<Kimlik1>(entity =>
            {
                entity.HasKey(e => e.Idno);

                entity.ToTable("KIMLIK1");

                entity.HasIndex(e => new { e.Prsicil, e.Uyruk, e.Cinsyt, e.Czseri, e.Tckmno }, "A1");

                entity.HasIndex(e => new { e.Prsicil, e.Tckmno }, "IDXKIM")
                    .IsUnique();

                entity.Property(e => e.Idno)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNO");

                entity.Property(e => e.Aileno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AILENO")
                    .IsFixedLength();

                entity.Property(e => e.Anne)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ANNE");

                entity.Property(e => e.Baba)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BABA");

                entity.Property(e => e.Ciltno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CILTNO")
                    .IsFixedLength();

                entity.Property(e => e.Cinsyt)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CINSYT")
                    .IsFixedLength();

                entity.Property(e => e.Czno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CZNO")
                    .IsFixedLength();

                entity.Property(e => e.Czseri)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CZSERI")
                    .IsFixedLength();

                entity.Property(e => e.Dini)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DINI")
                    .IsFixedLength();

                entity.Property(e => e.Dogil)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOGIL");

                entity.Property(e => e.Dogilce)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DOGILCE");

                entity.Property(e => e.Dogtar)
                    .HasColumnType("datetime")
                    .HasColumnName("DOGTAR");

                entity.Property(e => e.Il)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IL");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ILCE");

                entity.Property(e => e.Kangrb)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("KANGRB")
                    .IsFixedLength();

                entity.Property(e => e.Kayitno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("KAYITNO");

                entity.Property(e => e.Koy)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("KOY");

                entity.Property(e => e.Mahalle)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MAHALLE");

                entity.Property(e => e.Medhal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MEDHAL")
                    .IsFixedLength();

                entity.Property(e => e.Onsoy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ONSOY");

                entity.Property(e => e.Prsicil)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PRSICIL");

                entity.Property(e => e.Sirano)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SIRANO")
                    .IsFixedLength();

                entity.Property(e => e.Tckmno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TCKMNO");

                entity.Property(e => e.Uyruk)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UYRUK")
                    .IsFixedLength();

                entity.Property(e => e.Verned)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VERNED");

                entity.Property(e => e.Vertar)
                    .HasColumnType("datetime")
                    .HasColumnName("VERTAR");

                entity.Property(e => e.Veryer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VERYER");
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.ToTable("OVERTIMES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Endhour)
                    .HasMaxLength(20)
                    .HasColumnName("ENDHOUR");

                entity.Property(e => e.Overtimeid).HasColumnName("OVERTIMEID");

                entity.Property(e => e.Overtimename)
                    .HasMaxLength(20)
                    .HasColumnName("OVERTIMENAME");

                entity.Property(e => e.Starthour)
                    .HasMaxLength(20)
                    .HasColumnName("STARTHOUR");
            });

            modelBuilder.Entity<Personel1>(entity =>
            {
                entity.HasKey(e => e.Sicilno);

                entity.ToTable("PERSONEL1");

                entity.HasIndex(e => new { e.Sicilno, e.Adi, e.Soyadi, e.Kartno, e.Isgirt, e.Iscikt }, "A1");

                entity.HasIndex(e => e.Sicilno, "PERSONEL1_SICILNO_A");

                entity.Property(e => e.Sicilno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SICILNO");

                entity.Property(e => e.Adi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ADI");

                entity.Property(e => e.Aktif)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AKTIF")
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.Altdepart)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ALTDEPART");

                entity.Property(e => e.Altdepart2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALTDEPART2");

                entity.Property(e => e.Altdepart3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALTDEPART3");

                entity.Property(e => e.Altdepart4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALTDEPART4");

                entity.Property(e => e.Altdeptar)
                    .HasColumnType("datetime")
                    .HasColumnName("ALTDEPTAR");

                entity.Property(e => e.Altdeptar2)
                    .HasColumnType("datetime")
                    .HasColumnName("ALTDEPTAR2");

                entity.Property(e => e.Altdeptar3)
                    .HasColumnType("datetime")
                    .HasColumnName("ALTDEPTAR3");

                entity.Property(e => e.Altdeptar4)
                    .HasColumnType("datetime")
                    .HasColumnName("ALTDEPTAR4");

                entity.Property(e => e.Amir1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMIR1");

                entity.Property(e => e.Amir2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMIR2");

                entity.Property(e => e.Amir3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMIR3");

                entity.Property(e => e.Amir4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMIR4");

                entity.Property(e => e.Amir5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AMIR5");

                entity.Property(e => e.BirimKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIRIM_KODU");

                entity.Property(e => e.BirimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("BIRIM_TARIHI");

                entity.Property(e => e.Cikndn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CIKNDN")
                    .IsFixedLength();

                entity.Property(e => e.Depart)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPART")
                    .IsFixedLength();

                entity.Property(e => e.Deptar)
                    .HasColumnType("datetime")
                    .HasColumnName("DEPTAR");

                entity.Property(e => e.DomainUsername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOMAIN_USERNAME");

                entity.Property(e => e.Durak)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DURAK");

                entity.Property(e => e.DurakTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("DURAK_TARIHI");

                entity.Property(e => e.GecisYetkituru)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GECIS_YETKITURU");

                entity.Property(e => e.Gmyaka)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GMYAKA")
                    .IsFixedLength();

                entity.Property(e => e.Gorev)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GOREV")
                    .IsFixedLength();

                entity.Property(e => e.Gorevtar)
                    .HasColumnType("datetime")
                    .HasColumnName("GOREVTAR");

                entity.Property(e => e.GrupKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRUP_KODU");

                entity.Property(e => e.GrupTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("GRUP_TARIHI");

                entity.Property(e => e.Idno).HasColumnName("IDNO");

                entity.Property(e => e.Iscikt)
                    .HasColumnType("datetime")
                    .HasColumnName("ISCIKT");

                entity.Property(e => e.Isgirt)
                    .HasColumnType("datetime")
                    .HasColumnName("ISGIRT");

                entity.Property(e => e.Kadro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("KADRO")
                    .IsFixedLength();

                entity.Property(e => e.Kadrotar)
                    .HasColumnType("datetime")
                    .HasColumnName("KADROTAR");

                entity.Property(e => e.Kartno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("KARTNO");

                entity.Property(e => e.Kisitlama)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("KISITLAMA")
                    .HasDefaultValueSql("('False')");

                entity.Property(e => e.Kod1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("KOD1")
                    .IsFixedLength();

                entity.Property(e => e.Kod2)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("KOD2")
                    .IsFixedLength();

                entity.Property(e => e.Kredi)
                    .HasColumnName("KREDI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KrediBastar)
                    .HasColumnType("datetime")
                    .HasColumnName("KREDI_BASTAR");

                entity.Property(e => e.KrediBittar)
                    .HasColumnType("datetime")
                    .HasColumnName("KREDI_BITTAR");

                entity.Property(e => e.Krttar)
                    .HasColumnType("datetime")
                    .HasColumnName("KRTTAR");

                entity.Property(e => e.Masraf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASRAF");

                entity.Property(e => e.Masraftar)
                    .HasColumnType("datetime")
                    .HasColumnName("MASRAFTAR");

                entity.Property(e => e.Mesai)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MESAI")
                    .HasDefaultValueSql("('HAYIR')")
                    .IsFixedLength();

                entity.Property(e => e.Meslek)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MESLEK")
                    .IsFixedLength();

                entity.Property(e => e.Meslektar)
                    .HasColumnType("datetime")
                    .HasColumnName("MESLEKTAR");

                entity.Property(e => e.OnySifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ONY_SIFRE");

                entity.Property(e => e.Pertip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERTIP")
                    .IsFixedLength();

                entity.Property(e => e.Pertiptar)
                    .HasColumnType("datetime")
                    .HasColumnName("PERTIPTAR");

                entity.Property(e => e.PiCardid)
                    .HasColumnName("PI_CARDID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PiIdno)
                    .HasColumnName("PI_IDNO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PiIdnoYdk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PI_IDNO_YDK");

                entity.Property(e => e.Posta).HasColumnName("POSTA");

                entity.Property(e => e.Postar)
                    .HasColumnType("datetime")
                    .HasColumnName("POSTAR");

                entity.Property(e => e.Puantb)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PUANTB")
                    .HasDefaultValueSql("('HAYIR')")
                    .IsFixedLength();

                entity.Property(e => e.Servis)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SERVIS")
                    .IsFixedLength();

                entity.Property(e => e.Servistar)
                    .HasColumnType("datetime")
                    .HasColumnName("SERVISTAR");

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIFRE");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOYADI");

                entity.Property(e => e.SubeKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBE_KODU");

                entity.Property(e => e.SubeTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("SUBE_TARIHI");

                entity.Property(e => e.Tpgirt)
                    .HasColumnType("datetime")
                    .HasColumnName("TPGIRT");

                entity.Property(e => e.Ucrettipi)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("UCRETTIPI");

                entity.Property(e => e.Ucretturu)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("UCRETTURU");

                entity.Property(e => e.Yetkituru)
                    .HasColumnName("YETKITURU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yilizhesapt)
                    .HasColumnType("datetime")
                    .HasColumnName("YILIZHESAPT");
            });

            modelBuilder.Entity<Personelovertime>(entity =>
            {
                entity.ToTable("PERSONELOVERTIMES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createdat)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEDAT");

                entity.Property(e => e.Overtimeday)
                    .HasMaxLength(50)
                    .HasColumnName("OVERTIMEDAY");

                entity.Property(e => e.Overtimeid).HasColumnName("OVERTIMEID");

                entity.Property(e => e.Sicilno)
                    .HasMaxLength(20)
                    .HasColumnName("SICILNO");
            });

            modelBuilder.Entity<Personelshift>(entity =>
            {
                entity.ToTable("PERSONELSHIFTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createday)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEDAY");

                entity.Property(e => e.Endday)
                    .HasMaxLength(20)
                    .HasColumnName("ENDDAY");

                entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");

                entity.Property(e => e.Sicilno)
                    .HasMaxLength(20)
                    .HasColumnName("SICILNO");

                entity.Property(e => e.Startday)
                    .HasMaxLength(20)
                    .HasColumnName("STARTDAY");
            });

            modelBuilder.Entity<Servi>(entity =>
            {
                entity.HasKey(e => new { e.Srkodu, e.Kodu });

                entity.ToTable("SERVIS");

                entity.HasIndex(e => new { e.Srkodu, e.Kodu }, "IDX_YN_01");

                entity.Property(e => e.Srkodu).HasColumnName("SRKODU");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("KODU")
                    .IsFixedLength();

                entity.Property(e => e.Idno).HasColumnName("IDNO");

                entity.Property(e => e.Turu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TURU");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("SHIFTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Endhour)
                    .HasMaxLength(10)
                    .HasColumnName("ENDHOUR");

                entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");

                entity.Property(e => e.Shiftname)
                    .HasMaxLength(20)
                    .HasColumnName("SHIFTNAME");

                entity.Property(e => e.Starthour)
                    .HasMaxLength(10)
                    .HasColumnName("STARTHOUR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
