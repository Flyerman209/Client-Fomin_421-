namespace WpfApp25
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class EquipmentRepairDBEntities : DbContext
    {
        public EquipmentRepairDBEntities()
            : base("name=EquipmentRepairDBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<FaultType> FaultType { get; set; }
        public virtual DbSet<RepairReport> RepairReport { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }

        // Убедитесь, что EquipmentItems правильно определено как DbSet<Equipment>
        public virtual DbSet<Equipment> EquipmentItems { get; set; }
    }
}
