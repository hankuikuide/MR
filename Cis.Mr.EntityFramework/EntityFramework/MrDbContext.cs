﻿using System.Data.Common;
using Abp.Zero.EntityFramework;
using Cis.Mr.Authorization.Roles;
using Cis.Mr.MultiTenancy;
using Cis.Mr.Users;
using System.Data.Entity;
using Cis.Mr.Menus;
using Abp.Domain.Entities;
using System;
using Cis.Mr.Core;

namespace Cis.Mr.EntityFramework
{
    public class MrDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Menu> Menus { get; set; }
        public virtual IDbSet<TbClaimtype> TbClaimtypes { get; set; }
        public virtual IDbSet<TdSmBill> TdSmBills { get; set; }
        public virtual IDbSet<TbBenefitgroup> TbBenefitgroups { get; set; }
        public virtual IDbSet<TbBenefitplan> TbBenefitplans { get; set; }
        public virtual IDbSet<TbHospital> TbHospitals { get; set; }
        public virtual IDbSet<TbPatient> TbPatients { get; set; }
        public virtual IDbSet<TdMrLeaveHospital> TdMrLeaveHospitals { get; set; }
        public virtual IDbSet<TdMrMedical> TdMrMedicals { get; set; }


        public object GetPropValue(Type type)
        {
            switch (type.Name)
            {
                case "Cis.Mr.Menus.Menu":
                    return Menus;
                default:
                    break;
            }
            return null;
        }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MrDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MrDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MrDbContext since ABP automatically handles it.
         */
        public MrDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MrDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MrDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
