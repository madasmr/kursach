using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Contractors
{
	public class PostamateDeliveryService : IDeliveryService
	{
		private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
		{
			{ "1", "Кемерово" },
			{ "2", "Томск" },
		};
		private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postamates = new Dictionary<string, IReadOnlyDictionary<string, string>>
		{
			{
				"1",
				new Dictionary<string, string>
				{
					{ "1", "Ул. Кирова, 37, ЦУМ, 1 этаж" },
					{ "2", "Кузнецкий проспект, 33/1, ТЦ Облака, 1 этаж" },
					{ "3", "Проспект Ленина, 59А, ТРЦ Променад-3, 1 этаж" },
					{ "4", "Октябрьский проспект, 34, ТРЦ Лапландия, 2 этаж" },
					{ "5", "Проспект Шахтеров, 54, ТЦ Радуга, 1 этаж" },
					{ "6", "Молодежный проспект, 2, ТЦ Гринвич, 2 этаж" },
				}
			},
			{
				"2",
				new Dictionary<string, string>
				{
					{ "7", "Ул. Нахимова, 8, ТРК Лето" },
					{ "8", "Ул. Котовского, 19/1, СмайлCity, 1 этаж" },
					{ "9", "Проспект Ленина, 121, ЦУМ, 1 этаж" },
					{ "10", "Проспект Мира, 30, Гипер Лента" },
				}
			}
		};
		public string Name => "Postamate";
		public string Title => "Доставка через постаматы в Кемерово и Томске";

		public Form FirstForm(Order order)
		{
			return Form.CreateFirst(Name)
					   .AddParameter("orderId", order.Id.ToString())
					   .AddField(new SelectionField("Город", "city", "1", cities));
		}
		public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
		{
			if (step == 1)
			{
				if (values["city"] == "1")
				{
					return Form.CreateNext(Name, 2, values)
							   .AddField(new SelectionField("Постамат", "postamate", "1", postamates["1"]));
				}
				else if (values["city"] == "2")
				{
					return Form.CreateNext(Name, 2, values)
							   .AddField(new SelectionField("Постамат", "postamate", "4", postamates["2"]));
				}
				else
					throw new InvalidOperationException("Invalid postamate city.");
			}
			else if (step == 2)
			{
					return Form.CreateLast(Name, 3, values);
				}
			else
				throw new InvalidOperationException("Invalid postamate step.");
		}

		public OrderDelivery GetDelivery(Form form)
		{
			if (form.ServiceName != Name || !form.IsFinal)
				throw new InvalidOperationException("Invalid form.");
			var cityId = form.Parameters["city"];
			var cityName = cities[cityId];
			var postamateId = form.Parameters["postamate"];
			var postamateName = postamates[cityId][postamateId];
			var parameters = new Dictionary<string, string>
			{
				{ nameof(cityId), cityId },
				{ nameof(cityName), cityName },
				{ nameof(postamateId), postamateId },
				{ nameof(postamateName), postamateName },
			};
			var commentary = "";
			var description = $"Город: {cityName}\nПостамат: {postamateName}";
			return new OrderDelivery(Name, description, 150m, commentary, parameters);
		}
	}
}
