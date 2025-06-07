using Microsoft.EntityFrameworkCore;

namespace DELFOS.JWT.SSO.API.Data
{
    public partial class DELFOS_JWT_SSO_Context
    {
        private Idelfos_jwt_SSO_ContextProcedure? _procedures;

        public virtual Idelfos_jwt_SSO_ContextProcedure Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new DELFOS_JWT_SSO_ContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public Idelfos_jwt_SSO_ContextProcedure GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
        }
    }

    public partial class DELFOS_JWT_SSO_ContextProcedures : Idelfos_jwt_SSO_ContextProcedure
    {
        private readonly DELFOS_JWT_SSO_Context _context;

        public DELFOS_JWT_SSO_ContextProcedures(DELFOS_JWT_SSO_Context context)
        {
            _context = context;
        }
    }
}
