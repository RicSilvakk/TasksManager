using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Services;

namespace TasksManager.App_Start
{
    /// <summary>
    /// Summary description for TasksAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TasksAPI : System.Web.Services.WebService
    {

        [WebMethod]
        public string getTecTasks(string _type, string operation)
        {
            StringBuilder out_ = new StringBuilder();
            DBConnect dbCon = new DBConnect();

            if (dbCon.OpenConnection())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                StringBuilder query = new StringBuilder(@"  SELECT t.taskid, t.details, t.date, t.id_user, u.name 
                                                            FROM tasksdb.task t
                                                            INNER JOIN tasksdb.user u on u.userid = t.id_user ");
                var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
                var reader = cmd.ExecuteReader();


                out_.AppendFormat(@"
					<table id='mytable' class='table table-bordred table-striped'>
						<thead>
							<th><input type='checkbox' id='checkall' /></th>
							<th>#</th>
                            {0}
							<th>Details</th>
							<th>Date</th>
							<th>Edit</th>
						</thead>
						<tbody>", (_type == "Manager" ? "<th>Technician</th>" : ""));

                while (reader.Read())
                {
                    string taskid = reader.GetString("taskid");
                    string details = reader.GetString("details");
                    string date = reader.GetString("date");
                    string name = reader.GetString("name");
                    string _icon = (operation == "edit" ? "pencil":"minus");
                    string _opbutton = (operation == "edit" ? "update":"delete");

                    out_.AppendFormat(@" 
								<tr>
									<td><input type='checkbox' class='checkthis' /></td>
									<td>{0}</td>
                                    {3}
									<td>{1}</td>
									<td>{2}</td>
                                    <td><p data-placement='top' data-toggle='tooltip' title='"+ operation + @"'><div onclick='"+ _opbutton + @"_task({0});' class='btn btn-primary btn-xs btn_edit' data-title='" + operation + @"' data-toggle='modal' data-target='#" + operation + @"' ><span class='glyphicon glyphicon-"+_icon+@"'></span></div></p></td>
								</tr> ", taskid, details, date, (_type == "Manager" ? "<th>"+name+"</th>" : ""));
                }

                out_.AppendFormat(@" 
							</tbody>
						</table>");
            }

            dbCon.CloseConnection();
            return out_.ToString();
        }
         
        [WebMethod]
        public string addTask(string details)
        {
            int numRowsAffected = 0;
            DBConnect dbCon = new DBConnect();

            if (dbCon.OpenConnection())
            {
                StringBuilder query = new StringBuilder(@" 
                        INSERT INTO tasksdb.task (details, date, id_user)
                        VALUES (@details, now(), 3); ");
                var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
                cmd.Parameters.AddWithValue("@details", details);
                numRowsAffected = cmd.ExecuteNonQuery();
            }

            dbCon.CloseConnection();
            return numRowsAffected.ToString();
        }

        [WebMethod]
        public string getTaskDetails(string id_task)
        {
            StringBuilder out_ = new StringBuilder();
            DBConnect dbCon = new DBConnect();

            if (dbCon.OpenConnection())
            {
                StringBuilder query = new StringBuilder(@" 
                        SELECT details FROM tasksdb.task where taskid = @id_task; ");
                var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
                cmd.Parameters.AddWithValue("@id_task", id_task);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    out_.AppendFormat(reader.GetString("details"));
                }
            }

            dbCon.CloseConnection();
            return out_.ToString();
        }

        [WebMethod]
        public string editTask(string id_task, string details)
        {
            int numRowsAffected = 0;
            DBConnect dbCon = new DBConnect();

            if (dbCon.OpenConnection())
            {
                StringBuilder query = new StringBuilder(@" 
                        UPDATE tasksdb.task  
                            SET details = @details
                        WHERE taskid = @id_task; ");
                var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
                cmd.Parameters.AddWithValue("@id_task", id_task);
                cmd.Parameters.AddWithValue("@details", details);
                numRowsAffected = cmd.ExecuteNonQuery();
            }

            dbCon.CloseConnection();
            return numRowsAffected.ToString();
        }


        [WebMethod]
        public string deleteTask(string id_task)
        {
            int numRowsAffected = 0;
            DBConnect dbCon = new DBConnect();

            if (dbCon.OpenConnection())
            {
                StringBuilder query = new StringBuilder(@" 
                        DELETE FROM tasksdb.task   
                        WHERE taskID = @id_task; ");
                var cmd = new MySqlCommand(query.ToString(), dbCon.connection);
                cmd.Parameters.AddWithValue("@id_task", id_task);
                numRowsAffected = cmd.ExecuteNonQuery();
            }

            dbCon.CloseConnection();
            return numRowsAffected.ToString();
        }

    }
}
