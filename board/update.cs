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
    public partial class update : Form
    {
        string v = "";
        public update(detail parentForm, string v)
        {
            this.v = v;
            InitializeComponent();
        }

    
        SqlConnection conn;
        //
     
        private void update_Load(object sender, EventArgs e)
        {
            try
            {


                conn = new SqlConnection(strConn);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    DisplayData();
                }
          


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




        public void DisplayData()
        {
         
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(" select * from  PLASPO.T_SITE_INFO2 WHERE site_seq=" + v, conn);
            da.Fill(ds);

           


            // 바인딩 : 각각의 컨트롤
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                site_kind.Text = dr["site_kind"].ToString();
                site_code.Text = dr["site_code"].ToString();
                site_name.Text = dr["site_name"].ToString();
                use_yn.Text = dr["use_yn"].ToString();



            }

            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }


        public void updateData(Object sender,
                    EventArgs e)
        {
        
            try
            {
                
                conn = new SqlConnection(strConn);
              
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(null, conn);
                    cmd.CommandText =
                        "UPDATE PLASPO.T_SITE_INFO2 " +
                        "SET [site_kind]=@site_kind,[site_code]=@site_code,[site_name]=@site_name,[use_yn]=@use_yn " +
                        "WHERE site_seq=" + v;
                    //SqlParameter 객체 생성

                    SqlParameter site_kind_para = new SqlParameter("@site_kind", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_code_para = new SqlParameter("@site_code", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_name_para = new SqlParameter("@site_name", System.Data.SqlDbType.Text, 100);   
                    SqlParameter use_yn_para = new SqlParameter("@use_yn", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_seq_para = new SqlParameter("@site_seq", System.Data.SqlDbType.Int, 100);





                    //생성된 파라메터에 데이터 입력하기

                    site_kind_para.Value = site_kind.Text;
                    site_code_para.Value = site_code.Text;
                    site_name_para.Value = site_name.Text;
           
                    use_yn_para.Value = this.use_yn.Text;



                    //파라메터 값 대입          

                    cmd.Parameters.Add(site_kind_para);
                    cmd.Parameters.Add(site_code_para);
                    cmd.Parameters.Add(site_name_para);
                    cmd.Parameters.Add(use_yn_para);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();


                }





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
                    this.Close();

                }
            }
        }

       
    }
}
