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

namespace board
{
    public partial class create : Form
    {
        public create(Form1 parentForm)
        {
            InitializeComponent();
         
        }


      
        SqlConnection conn;
        private void postBtnClick(object sender, EventArgs e)
        {

            try
            {
                

                //
                
                conn = new SqlConnection(strConn);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(null, conn);
                    cmd.CommandText =
                        "INSERT INTO PLASPO.T_SITE_INFO2 " +
                        "([site_kind],[site_code],[site_name],[use_yn],[site_cdatetime]) " +
                        "VALUES" +
                        "(@site_kind,@site_code,@site_name,@use_yn,@site_cdatetime)";

                    //SqlParameter 객체 생성

                    SqlParameter site_kind_para = new SqlParameter("@site_kind", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_code_para = new SqlParameter("@site_code", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_name_para = new SqlParameter("@site_name", System.Data.SqlDbType.Text, 100);
                    SqlParameter use_yn_para = new SqlParameter("@use_yn", System.Data.SqlDbType.Text, 100);
                    SqlParameter site_cdatetime_para = new SqlParameter("@site_cdatetime", System.Data.SqlDbType.DateTime, 100);



                    //생성된 파라메터에 데이터 입력하기
                    site_kind_para.Value = site_kind.Text;
                    site_code_para.Value = site_code.Text;
                    site_name_para.Value = site_name.Text;
                    use_yn_para.Value = use_yn.Text;
                    site_cdatetime_para.Value = DateTime.Now;



                    //파라메터 값 대입          
                    cmd.Parameters.Add(site_kind_para);
                    cmd.Parameters.Add(site_code_para);
                    cmd.Parameters.Add(site_name_para);
                    cmd.Parameters.Add(use_yn_para);
                    cmd.Parameters.Add(site_cdatetime_para);
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


