using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace wise_nut.Data.EF
{
	public class StoreDbContext : DbContext
	{
		public DbSet<ProductDto> Products { get; set; }
		public DbSet<OrderDto> Orders { get; set; }
		public DbSet<OrderItemDto> OrderItems { get; set; }
		public StoreDbContext(DbContextOptions<StoreDbContext> options)
			: base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			BuildProducts(modelBuilder);
			BuildOrders(modelBuilder);
			BuildOrderItems(modelBuilder);
		}
		private void BuildOrderItems(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItemDto>(action =>
			{
				action.Property(dto => dto.Price)
					  .HasColumnType("money");
				action.HasOne(dto => dto.Order)
					  .WithMany(dto => dto.Items)
					  .IsRequired();
			});
		}
		private static void BuildOrders(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderDto>(action =>
			{
				action.Property(dto => dto.CellPhone)
					  .HasMaxLength(20)
					  .IsRequired(false);
				action.Property(dto => dto.DeliveryUniqueCode)
					  .HasMaxLength(40)
					  .IsRequired(false);
				action.Property(dto => dto.DeliveryPrice)
					  .HasColumnType("money");
				action.Property(dto => dto.PaymentServiceName)
					  .HasMaxLength(40)
					  .IsRequired(false);
				action.Property(dto => dto.DeliveryCommentary)
					  .IsRequired(false);
				action.Property(dto => dto.DeliveryParameters)
					  .HasConversion(
						  value => JsonConvert.SerializeObject(value),
						  value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
					  .Metadata.SetValueComparer(DictionaryComparer);
				action.Property(dto => dto.PaymentParameters)
					  .HasConversion(
						  value => JsonConvert.SerializeObject(value),
						  value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
					  .Metadata.SetValueComparer(DictionaryComparer);
			});
		}
		private static readonly ValueComparer DictionaryComparer =
			new ValueComparer<Dictionary<string, string>>(
				(dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
				dictionary => dictionary.Aggregate(
					0,
					(a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
				)
			);
		private static void BuildProducts(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDto>(action =>
			{
				action.Property(dto => dto.Title)
					  .IsRequired();
				action.Property(dto => dto.Price)
					  .HasColumnType("money");
				action.HasData(
					new ProductDto
					{
						Id = 1,
						Title = "Кешью",
						Type = "Орехи",
						Description = "Вкусные орехи ура ура",
						Price = 7.19m,
					},
					new ProductDto
					{
						Id = 2,
						Title = "Фундук",
						Type = "Орехи",
						Description = "Вкусные орехи ура ура",
						Price = 7.19m,
					},
					new ProductDto
					{
						Id = 3,
						Title = "Фисташки",
						Type = "Орехи",
						Description = "Вкусные орехи ура ура",
						Price = 7.19m,
					}
				);
			});
		}
	}
}