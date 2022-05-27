using Microsoft.VisualStudio.TestTools.UnitTesting;
using Korobki_project;
using Korobki_project.Functions;
using System.Linq;
using System;

namespace TestProject1
{
	[TestClass]
	public class TestEmployee
	{
		string name = "Артур";
		string login = "tu4a";
		string password = "121212";
		int positionId = 1;
		string phoneNumber = "982103913";
		string adress = "ykt";
		int shiftId = 3;

		[TestMethod]
		public void TestEmployeeAdd()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
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

				employee.Delete(search.Id);
			}
		}

		[TestMethod]
		public void TestEmployeeEdit()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
			name = "Артур";
			login = "tu4a";
			password = "121212";
			positionId = 1;
			phoneNumber = "982103913";
			adress = "ykt";
			shiftId = 3;
			employee.Add(name, login, password, positionId, phoneNumber, adress, shiftId);

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

				name = "Никита";
				login = "nikk";
				password = "12424";
				positionId = 2;
				phoneNumber = "89131";
				adress = "Марха";
				shiftId = 2;

				employee.Edit(search.Id, name, login, password, positionId, phoneNumber, adress, shiftId);

				search = c.Employees
					 .Where(N => N.Name.Contains(name))
					 .Where(L => L.Login.Contains(login))
					 .Where(P => P.Password.Contains(password))
					 .Where(k => k.PositionId.Equals(positionId))
					 .Where(Ph => Ph.PhoneNumber.Contains(phoneNumber))
					 .Where(A => A.Adress.Contains(adress))
					 .Where(S => S.ShiftId.Equals(shiftId))
					 .FirstOrDefault();
				Assert.IsNotNull(search);
				employee.Delete(search.Id);
			}
		}

		[TestMethod]
		public void TestEmployeeDelete()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
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

				employee.Delete(search.Id);

				search = c.Employees
					 .Where(N => N.Name.Contains(name))
					 .Where(L => L.Login.Contains(login))
					 .Where(P => P.Password.Contains(password))
					 .Where(k => k.PositionId.Equals(positionId))
					 .Where(Ph => Ph.PhoneNumber.Contains(phoneNumber))
					 .Where(A => A.Adress.Contains(adress))
					 .Where(S => S.ShiftId.Equals(shiftId))
					 .FirstOrDefault();

				Assert.IsNull(search);
			}
		}


		[TestMethod]
		public void TestEmployeeSearch()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
			employee.Add(name, login, password, positionId, phoneNumber, adress, shiftId);
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
				Assert.AreEqual(1, EmployeeFunctions.Search(name).Count);
				employee.Delete(search.Id);
				Assert.AreEqual(0, EmployeeFunctions.Search(name).Count);
				//Assert.AreEqual(1, EmployeeFunctions.Search(name).Count); // Error
			}
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestEmployeeAddError()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
			employee.Add("asd", "qwea", "asd213", 99999, "7898", "asd", 99999);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestEmployeeDeleteError()
		{
			EmployeeFunctions employee = new EmployeeFunctions();
			employee.Delete(22222222);
		}
	}
}
