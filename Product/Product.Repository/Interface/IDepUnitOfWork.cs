using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Interface
{
    /// <summary>
    /// 後續可針對資料庫操作設計擴充transaction Commit等方法
    /// </summary>
    public interface IDepUnitOfWork
    {
        public IDbConnection GenConnection();
    }
}
