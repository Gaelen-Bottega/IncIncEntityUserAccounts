// PieceworkerModel.cs
// Author: Gaelen Rhoads & Kyle Chapman
// Created: December 6, 2021
// Modified: December 6, 2021
// Description: This is a context describing relationships related to the PieceworkerModel for which
// there are no relationships. To be used with entity relationships.

using IncIncEntityUserAccounts.Models;
using Microsoft.EntityFrameworkCore;

namespace IncIncEntityUserAccounts.Contexts
{
    public class WorkerContext : DbContext
    {
        /// <summary>
        /// Constructor for the WorkerContext
        /// </summary>
        /// <param name="options"></param>
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }

        /// <summary>
        /// Entity that we read/write, "Pieceworker"
        /// </summary>
        public DbSet<PieceworkerModel> Workers { get; set; }

    }
}