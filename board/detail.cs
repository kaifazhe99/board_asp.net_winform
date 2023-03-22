using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace board
{
    public partial class detail : Form
    {

        string v = "";
        public detail(Form1 parentForm,string v)
        {
            InitializeComponent();
            this.v = v;

  
        }

        SqlConnection conn;
        private void detail_Load(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();
                //
                string sql = "select site_seq,site_kind,site_code,site_name,site_cdatetime,use_yn from PLASPO.T_SITE_INFO2 " +
                    " WHERE site_seq = " + v;
                    ;


                conn = new SqlConnection(strConn);
                conn.Open();



                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].HeaderText = "순번";
                dataGridView1.Columns[1].HeaderText = "타입";
                dataGridView1.Columns[2].HeaderText = "제품코드";
                dataGridView1.Columns[3].HeaderText = "사이트명";
                dataGridView1.Columns[4].HeaderText = "등록일";
                dataGridView1.Columns[5].HeaderText = "사용여부";





            }
            catch (SqlException se)
            {
                // DB 관련 예외시 처리
                string strException = se.ErrorCode.ToString();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }



            }
        }

        private void update(object sender, EventArgs e)
        {

            string v = dataGridView1.Rows[0].Cells[0].Value.ToString();


            update updateForm = new update(this, v);
            updateForm.Owner = this;
            updateForm.Show();
        }

        private void delete(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
              //
                string sql = "DELETE FROM PLASPO.T_SITE_INFO2 WHERE site_seq=" + v;
               
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);


            }
            catch (SqlException se)
            {
                // DB 관련 예외시 처리
                string strException = se.ErrorCode.ToString();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                  
                }
                this.Close();



            }
        }

      
    }
}
