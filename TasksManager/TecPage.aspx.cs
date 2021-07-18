using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TasksManager.App_Start;

namespace TecPage
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     //   [WebMethod]
     //   public static string getTecTasks()
     //   { 
     //       StringBuilder out_ = new StringBuilder();
     //       DBConnect dbCon = new DBConnect();

     //       if (dbCon.OpenConnection())
     //       {
     //           //suppose col0 and col1 are defined as VARCHAR in the DB
     //           StringBuilder query = new StringBuilder(@"  SELECT t.taskid, t.details, t.date, t.id_user, u.name 
     //                                                       FROM tasksdb.task t
     //                                                       INNER JOIN tasksdb.user u on u.userid = t.id_user ");
     //           var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
     //           var reader = cmd.ExecuteReader();


     //           out_.AppendFormat(@"
					//<table id='mytable' class='table table-bordred table-striped'>
					//	<thead>
					//		<th><input type='checkbox' id='checkall' /></th>
					//		<th>#</th>
					//		<th>Details</th>
					//		<th>Date</th>
					//		<th>Edit</th>
					//	</thead>
					//	<tbody>");

     //           while (reader.Read())
     //           {
     //               string taskid = reader.GetString("taskid");
     //               string details = reader.GetString("details");
     //               string date = reader.GetString("date");
     //               string name = reader.GetString("name");

     //               out_.AppendFormat(@" 
					//			<tr>
					//				<td><input type='checkbox' class='checkthis' /></td>
					//				<td>{0}</td>
					//				<td>{1}</td>
					//				<td>{2}</td>
     //                               <td><p data-placement='top' data-toggle='tooltip' title='Edit'><div onclick='update_task({0});' class='btn btn-primary btn-xs btn_edit' data-title='Edit' data-toggle='modal' data-target='#edit' ><span class='glyphicon glyphicon-pencil'></span></div></p></td>
					//			</tr> ", taskid, details, date);
     //           }

     //           out_.AppendFormat(@" 
					//		</tbody>
					//	</table>" );
     //       }

     //       dbCon.CloseConnection();
     //       return out_.ToString();
     //   }


        //[WebMethod]
        //public static string addTask(string details)
        //{
        //    int numRowsAffected = 0;
        //    DBConnect dbCon = new DBConnect();

        //    if (dbCon.OpenConnection())
        //    {
        //        StringBuilder query = new StringBuilder(@" 
        //                INSERT INTO tasksdb.task (details, date, id_user)
        //                VALUES (@details, now(), 3); "); 
        //        var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
        //        cmd.Parameters.AddWithValue("@details", details);
        //        numRowsAffected = cmd.ExecuteNonQuery();
        //    }

        //    dbCon.CloseConnection();
        //    return numRowsAffected.ToString();
        //}
    }
}