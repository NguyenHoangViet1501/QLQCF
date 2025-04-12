using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    internal class DoanhThuDAO
    {

            DBModelDataContext dbContext = new DBModelDataContext();


            public FunctionResult<List<Bill>> GetBill(DateTime fromDate, DateTime toDate)
            {

                var query = from bill in dbContext.Bills
                            join table in dbContext.TableFoods on bill.TableFoodID equals table.TableFoodId
                            where (bill.DateCheckOut >= fromDate.Date && bill.DateCheckOut <= toDate.Date
                            && bill.Status == 1)
                            select new
                            {
                                BillID = bill.BillID,
                                TableFoodName = table.Name,
                                DateCheckOut = bill.DateCheckOut,
                                TotalPrice = bill.TotalPrice,
                                Discount = bill.Discount
                            };

                var result = query.ToList();

                var bills = result.Select(x => new Bill
                {
                    BillID = x.BillID,
                    TableFoodID = x.TableFoodName,
                    DateCheckOut = x.DateCheckOut,
                    TotalPrice = x.TotalPrice,
                    Discount = x.Discount
                }).ToList();

                return new FunctionResult<List<Bill>>
                {
                    Data = bills
                };
            }
            public float GetTongTien(DateTime fromDate, DateTime toDate)
            {
                float TongTien = 0;
                var bills = GetBill(fromDate, toDate).Data;

                foreach (var bill in bills)
                {
                    if (bill.TotalPrice.HasValue)
                    {
                        TongTien += (float)bill.TotalPrice.Value;
                    }
                }

                return TongTien;
            }
        }


    }

