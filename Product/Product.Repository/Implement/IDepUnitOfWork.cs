using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Common
{
    public interface IDepUnitOfWork
    {
        /// <summary>
        /// Connection : 在使用前確認有執行 DepInfrastructure()
        /// </summary>
        public IDbConnection GenConnection();
    }
}
