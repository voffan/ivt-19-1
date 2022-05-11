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
        public void Add(string documentData, uint moneyValue, DepositType DepositType, Client client)
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

            using (DataContext db = Connection.Connect())
            {
                Client c = db.Clients.First(x => x.Id == client.Id);

                Deposit deposit = new Deposit()
                {
                    DocumentData = documentData,
                    MoneyValue = moneyValue,
                    DepositType = DepositType,
                    Owner = c
                };

                db.Update(deposit);
                //db.Database. = s => System.Diagnostics.Debug.WriteLine(s);
                db.ChangeTracker.DetectChanges();
                Console.WriteLine(db.ChangeTracker.DebugView.LongView);
                           
                db.Deposits.Add(deposit);
                db.SaveChanges();
            }
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

        public Deposit Get(int depositId)
        {
            using (DataContext db = Connection.Connect())
            {
                Deposit deposit = db.Deposits
                    .Include("Owner")
                    .First(dep => dep.Id == depositId);

                return deposit;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Deposits.Remove(db.Deposits.First(empl => empl.Id == Id));
                db.SaveChanges();
            }
        }

        public void Edit(Deposit editingEntity,string data,uint sum,DepositType position,Client client_id)
        {
            using (DataContext db = Connection.Connect())
            {
                var dep = db.Deposits
                    .Where(d => d.Id == editingEntity.Id)
                    .First();
                dep.DocumentData = data;
                dep.MoneyValue = Convert.ToUInt32(sum);
                //dep.DepositType = position;
                //dep.Owner = editingEntity.Owner;
                db.SaveChanges();
            }
        }
    }
}
