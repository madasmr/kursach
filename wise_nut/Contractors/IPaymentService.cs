﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wise_nut.Contractors
{
	public interface IPaymentService
	{
		string Name { get; }
		string Title { get; }
		Form FirstForm(Order order);
		Form NextForm(int step, IReadOnlyDictionary<string, string> values);
		OrderPayment GetPayment(Form form);
	}
}
