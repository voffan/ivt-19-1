using Microsoft.VisualStudio.TestTools.UnitTesting;
using Korobki_project;
using Korobki_project.Functions;
using System.Linq;
using System;


namespace TestProject1
{
	[TestClass]
	public class TestPlan
	{
		int count_box = 30;
		string plandate = "11.05.2022";
		int productid = 2;

		[TestMethod]
		public void TestPlanAdd()
		{
			PlanFunctions plan = new PlanFunctions();
			plan.Add(count_box, plandate, productid);
			PlanFunctions.Search(plandate);
			using (Context c = new Context())
			{
				var search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();
				Assert.IsNotNull(search);

				plan.Delete(search.Id);
			}
		}
		[TestMethod]
		public void TestPlanEdit()
		{
			PlanFunctions plan = new PlanFunctions();
			count_box = 30;
			plandate = "11.05.2022";
			productid = 2;
			plan.Add(count_box, plandate, productid);

			using (Context c = new Context())
			{
				var search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();

				count_box = 10;
				plandate = "1.06.2022";
				productid = 3;

				plan.Edit(search.Id, count_box, plandate, productid);

				search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();
				Assert.IsNotNull(search);
				plan.Delete(search.Id);
			}
		}
		[TestMethod]
		public void TestPlanDelete()
		{
			PlanFunctions plan = new PlanFunctions();
			plan.Add(count_box, plandate, productid);
			PlanFunctions.Search(plandate);
			using (Context c = new Context())
			{
				var search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();

				plan.Delete(search.Id);

				search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();

				Assert.IsNull(search);
			}
		}
		[TestMethod]
		public void TestPlanSearch()
		{
			PlanFunctions plan = new PlanFunctions();
			plan.Add(count_box, plandate, productid);
			using (Context c = new Context())
			{
				var search = c.Plans
					 .Where(C => C.Count_box.Equals(count_box))
					 .Where(PL => PL.PlanDate.Contains(plandate))
					 .Where(PI => PI.ProductId.Equals(productid))
					 .FirstOrDefault();
				Assert.AreEqual(1, PlanFunctions.Search(plandate).Count);
				plan.Delete(search.Id);
				Assert.AreEqual(0, PlanFunctions.Search(plandate).Count);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestPlanAddError()
		{
			PlanFunctions plan = new PlanFunctions();
			plan.Add(999999,"20 03 20022",999999);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestPlanDeleteError()
		{
			PlanFunctions plan = new PlanFunctions();
			plan.Delete(22222222);
		}
	}
}
