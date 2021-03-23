using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util;

namespace Data
{
    public class PizzaDB : IPizzaDB
    {
        private ConnectionDB _conn;

        public bool Insert(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.INSERT, pizza.Descricao, pizza.Valor);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Update(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.UPDATE, pizza.Descricao, pizza.Valor, pizza.Id);
            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = string.Format(Pizza.DELETE, id);
            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        //consultar
        public Pizza SelectById(int id)
        {
            
            using (_conn = new ConnectionDB())
            {
                string sql = string.Format(Pizza.SELECTBYID,id);
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData)[0];
            }
        }

        public List<Pizza> Select()
        {
            using (_conn = new ConnectionDB())
            {
                string sql = Pizza.SELECT;
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }

        private List<Pizza> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Pizza>();

            while (returnData.Read())
            {
                var item = new Pizza()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = decimal.Parse(returnData["valor"].ToString()),
                };

                list.Add(item);
            }
            return list;
        }
    }
}
