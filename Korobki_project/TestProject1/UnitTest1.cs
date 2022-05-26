using Microsoft.VisualStudio.TestTools.UnitTesting;
using Korobki_project;
using Korobki_project.Functions;
using System.Linq;

namespace TestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethodEmployee()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
			string name = "Артур";
			string login = "tu4a";
			string password = "121212";
			int positionId = 1;
			string phoneNumber = "982103913";
			string adress = "ykt";
			int shiftId = 3;
			employee.Add(name, login, password, positionId, phoneNumber, adress, shiftId);
			EmployeeFunctions.Search(name);
			using (Context c = new Context())
			{
				var search = c.Employees
					 .Where(N => N.Name.Contains(name))
					 .Where(L => L.Login.Contains(login))
					 .Where(P => P.Password.Contains(password))
					 .Where(k => k.PositionId.Equals(positionId))
					 .Where(Ph => Ph.PhoneNumber.Contains(phoneNumber))
					 .Where(A => A.Adress.Contains(adress))
					 .Where(S => S.ShiftId.Equals(shiftId))
					 .FirstOrDefault();
				Assert.IsNotNull(search);

				name = "Никита";
				login = "nikk";
				password = "12424";
				positionId = 2;
				phoneNumber = "89131";
				adress = "Марха";
				shiftId = 2;

				employee.Edit(search.Id, name, login, password, positionId, phoneNumber, adress, shiftId);
				EmployeeFunctions.Search(name);
				employee.Delete(search.Id);
			}
		}
	}
}
