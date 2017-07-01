namespace HomeWork.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class HomeworkModel : DbContext
	{
		public HomeworkModel()
			: base("name=HomeworkModel")
		{
		}

		public virtual DbSet<AccountBook> AccountBooks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
