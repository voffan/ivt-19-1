using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using Autoreport.UI.Classes;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Autoreport.Services.Errors;

namespace Autoreport.Services
{
    public class DepositService
    {
        public void Add(string documentData, uint moneyValue, DepositType DepositType, Client clients)
        {
            switch (DepositType)
            {
                case DepositType.Document:
                    if (moneyValue > 0)
                    {
                        throw new MoneyGivenButDocumentChoosed("Указан тип депозита - документ, но переданы деньги");
                    }
                    break;
                case DepositType.Money:
                    if (documentData != null && documentData.Trim().Length > 0)
                    {
                        throw new DocumentGivenButMoneyChoosed("Указан тип депозита - деньги, но переданы данные документа");
                    }
                    break;
                case DepositType.MoneyAndDocument:
                    break;
                default:
                    throw new ArgumentNullException("Argument `DepositType` cannot be null");
            }
            Deposit deposit = new Deposit()
            {
                DocumentData = documentData,
                MoneyValue = moneyValue,
                DepositType = DepositType,
                Owner = clients
            };

            using (DataContext db = Connection.Connect())
            {
                db.Update(deposit);             
                db.Deposits.Add(deposit);
                db.SaveChanges();
            }
        }

        public void Get()
        {

        }
        public List<Deposit> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Deposits
                    .Include("Owner")
                    .ToList();
            }
        }

        public Deposit GetById(int dep_id)
        {
            using (DataContext db = Connection.Connect())
            {
                Deposit deposit = db.Deposits
                    .Where(dep => dep.Id == dep_id)
                    .Include("Owner")
                    .ToList()[0];

                return deposit;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Deposits.Remove(db.Deposits.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
