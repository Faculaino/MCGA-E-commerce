using ASF.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class DealerDAC : DataAccessComponent
    {
        public List<Dealer> Lista()
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Dealer ";

            var result = new List<Dealer>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var dealer = LoadDealer(dr); // Mapper
                        result.Add(dealer);
                    }
                }
            }

            return result;
        }

        public void Insert(Dealer dealer)
        {
            const string sqlStatement = "INSERT INTO dbo.Dealer ([FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@FirstName, @LastName, @CategoryId, @CountryId, @Descritpion, @TotalProducts, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, dealer.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, dealer.LastName);
                db.AddInParameter(cmd, "@CategoryId", DbType.Int32, dealer.CategoryId);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, dealer.CountryId);
                db.AddInParameter(cmd, "@Descritpion", DbType.String, dealer.Description);
                db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, dealer.TotalProducts);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, dealer.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, dealer.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, dealer.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, dealer.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, dealer.ChangedBy);
                dealer.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
        }

        private static Dealer LoadDealer(IDataReader dr)
        {
            var dealer = new Dealer
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                CategoryId = GetDataValue<int>(dr, "CategoryId"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                Description = GetDataValue<string>(dr, "Description"),
                TotalProducts = GetDataValue<int>(dr, "TotalProducts"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return dealer;
        }


    }
}
