﻿/* ***********************************************
 * author :  韩奎奎
 * function: 
 * history:  created by 韩奎奎 2017/5/22 11:32:06
 * ***********************************************/

namespace Cis.Mr.EntityFramework.Repositories
{
    using Abp.Dependency;
    using Abp.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SqlExecuter : ISqlExecuter, ITransientDependency
    {
        private readonly IDbContextProvider _dbContextProvider;

        public SqlExecuter(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// 

        /// 执行给定的命令
        /// 

        /// 命令字符串
        /// 要应用于命令字符串的参数
        /// 执行命令后由数据库返回的结果
        public int Execute(string sql, params object[] parameters)
        {
            return _dbContextProvider.DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// 

        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。
        /// 

        /// 查询所返回对象的类型
        /// SQL 查询字符串
        /// 要应用于 SQL 查询字符串的参数
        /// 
        public IQueryable SqlQuery(string sql, params object[] parameters)
        {
            return _dbContextProvider.DbContext.Database.SqlQuery(sql, parameters).AsQueryable();
        }
    }
}
