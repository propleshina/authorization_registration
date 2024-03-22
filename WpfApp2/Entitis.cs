namespace Autoryzation
{
    using WpfApp2;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class Entitis : DbContext
    {
        private static Entitis _context; 
        public Entitis()
            : base("name=Entitis") { }
        public static Entitis GetContext()
        {
            if (_context == null)
                _context = new Entitis(); return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}