using CRUDUsingMVCwithAdoNotNet.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoNotNet.Repository
{
    public class ComplaintRepo
    {
        SqlConnection con;
        //To Handle connection related activities  
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }
        //To Add Complaint details  
        public string AddComplaint(ComplaintModel Obj)
        {
            DynamicParameters ObjParm = new DynamicParameters();
            ObjParm.Add("@ComplaintType", Obj.ComplaintType);
            ObjParm.Add("@ComplaintDesc", Obj.ComplaintDesc);
            ObjParm.Add("@ComplaintId", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            connection();
            con.Open();
            con.Execute("AddComplaint", ObjParm, commandType: CommandType.StoredProcedure);
            //Getting the out parameter value of stored procedure  
            var ComplaintId = ObjParm.Get<string>("@ComplaintId");
            con.Close();
            return ComplaintId;
        }
    }
}