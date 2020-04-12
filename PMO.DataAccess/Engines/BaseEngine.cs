using System;
using System.Collections.Generic;
using System.Text;

namespace PMO.DataAccess.Engines
{
    public abstract class BaseEngine
    {

        protected readonly string connectionString;
        public BaseEngine()
        {
            //TODO: Inject Connection string from Service Config
            this.connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=pmo;User ID=sa;Password=mosl_123";
        }
    }
}
