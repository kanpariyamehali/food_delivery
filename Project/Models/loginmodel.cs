using System.Data;
using System.Data.SqlClient;

namespace Project.Models
{
    public class loginmodel
    {
		public string email { get; set; }
		public string password { get; set; }
		public string name { get; set; }
		public string conatct { get; set; }
		public string gender { get; set; }


		SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=food_management;User Id=sa;pwd=project");

		public DataSet login(string email, string password)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[user] where email='" + email + "' and password='" + password + "'",con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

			da.Fill(ds);

			return ds;
		}

		public int register(string name,string email,string password,string conatct,string gender)
		{ 

			SqlCommand cmd = new SqlCommand("insert into [dbo].[user](name,email,password,conatct,gender)values('" + name + "','"+email+"','"+password+"','"+conatct+"','"+gender+"')",con);
			con.Open();

			return cmd.ExecuteNonQuery();

		}
	}
}
