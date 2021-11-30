using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace vaccine
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbvac"].ConnectionString;
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=CYG336;Initial Catalog=employeeVaccine;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[vaccineRecords]
           ([Name]
           ,[Aadhar_no]
           ,[vaccine_name]
           ,[dose1]
           ,[dose2])
     VALUES
           ('"+TextBox1.Text+ "','" + TextBox2.Text + "'," +
           "'" + TextBox3.Text + "'," +
           "'" + CheckBox1.Checked + "'," +
           "'" + CheckBox2.Checked + "' )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("Data Saved Successfully");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            CheckBox2.Checked = false;
            Response.Write("Data Cleared Successfully!");
        }

        protected void GVbind()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from vaccineRecords", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GVbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString();
            string aadhar = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
            string vaccine = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString();
            CheckBox dose1 = (CheckBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("CheckBox1");
            CheckBox dose2 = (CheckBox)GridView1.Rows[e.RowIndex].Cells[4].FindControl("CheckBox2");

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE vaccineRecords
   SET Name = '" + name + "',Aadhar_no = '" + aadhar + "',vaccine_name = '" + vaccine + "', dose1 = '" + dose1 + "', dose2 = '" + dose2 + "' WHERE Id='" + id + "'", con);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("Data Updated Successfully!");
                    GridView1.EditIndex = -1;
                    GVbind();
                }
            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM vaccineRecords WHERE id='" + id + "'", con);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("Data Deleted Successfully!");
                    GridView1.EditIndex = -1;
                    GVbind();
                }
            }
        }

        protected void searchButton_Click1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from vaccineRecords where Aadhar_no = '" + searchText.Text + "'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}