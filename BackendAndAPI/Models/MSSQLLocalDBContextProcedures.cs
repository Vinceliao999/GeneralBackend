﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BackendAndAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BackendAndAPI.Models
{
    public partial class MSSQLLocalDBContext
    {
        private IMSSQLLocalDBContextProcedures _procedures;

        public virtual IMSSQLLocalDBContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new MSSQLLocalDBContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IMSSQLLocalDBContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAllUsersResult>().HasNoKey().ToView(null);
        }
    }

    public partial class MSSQLLocalDBContextProcedures : IMSSQLLocalDBContextProcedures
    {
        private readonly MSSQLLocalDBContext _context;

        public MSSQLLocalDBContextProcedures(MSSQLLocalDBContext context)
        {
            _context = context;
        }

        public virtual async Task<int> AddUserAsync(string Name, int? Height, int? Weight, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Name",
                    Size = 40,
                    Value = Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Height",
                    Value = Height ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Weight",
                    Value = Weight ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AddUser] @Name, @Height, @Weight", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetAllUsersResult>> GetAllUsersAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetAllUsersResult>("EXEC @returnValue = [dbo].[GetAllUsers]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}