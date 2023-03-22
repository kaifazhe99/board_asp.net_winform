using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace board
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();

    
        }


        SqlConnection conn;
        string type = "전체";
        string searchType = "통합검섹";


        private void Form1_Load(object sender, EventArgs e)
        {
           



            try
            {

             
//
               
            
    
                conn = new SqlConnection(strConn);
                conn.Open();

                getData(type,searchType);
                

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
     

        private void getData(string type,string searchType)
        {



            string sql;
            if (type == "전체")
            {
                sql = "select site_seq,site_kind,site_code,site_name,site_cdatetime,use_yn from PLASPO.T_SITE_INFO2";

                if (searchType == "사이트명")
                {
                    sql += " WHERE site_name LIKE '%" + textBox1.Text + "%'";
                }
                else if (searchType == "제품코드")
                {
                    sql += " WHERE site_code LIKE '%" + textBox1.Text + "%'";
                }
                else if (searchType == "고객사")
                {
                    sql += " WHERE site_manager LIKE '%" + textBox1.Text + "%'";
                }
           
                else if(searchType=="통합검색")
                {
                    sql += " WHERE site_name LIKE '%" + textBox1.Text + "%' OR site_code LIKE '%" + textBox1.Text + "%' OR site_manager LIKE '%" + textBox1.Text + "%'";
                }
              
            }
            else
            {
               sql = "select site_seq,site_kind,site_code,site_name,site_cdatetime,use_yn from PLASPO.T_SITE_INFO2 "
                     + "WHERE site_kind = '" + type + "'";

                if (searchType == "사이트명")
                {
                    sql += " AND site_name LIKE '%" + textBox1.Text + "%'";
                }
                else if (searchType == "제품코드")
                {
                    sql += " AND site_code LIKE '%" + textBox1.Text + "%'";
                }
                else if (searchType == "고객사")
                {
                    sql += " AND site_manager LIKE '%" + textBox1.Text + "%'";
                }

                else if (searchType == "통합검색")
                {
                    sql += " AND site_name LIKE '%" + textBox1.Text + "%' OR site_code LIKE '%" + textBox1.Text + "%' OR site_manager LIKE '%" + textBox1.Text + "%'";
                }
            }

      
          

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            dataGridView1.DataSource = ds.Tables[0];
            DataGridViewLinkColumn dataGridViewLinkColumn = new DataGridViewLinkColumn();
            dataGridView1.Columns[0].HeaderText = "순번";


            dataGridView1.Columns[1].HeaderText = "타입";
            dataGridView1.Columns[2].HeaderText = "제품코드";
            dataGridView1.Columns[3].HeaderText = "사이트명";
            dataGridView1.Columns[4].HeaderText = "등록일";
            dataGridView1.Columns[5].HeaderText = "사용여부";

        }

      

        //작성창으로 이동
        private void create_Click(object sender, EventArgs e)
        {
            create writeForm = new create(this);
            writeForm.Owner = this;
            writeForm.Show();
        }

        //검색
        private void search(object sender, EventArgs e)
        {
            
                getData(type, searchType);
         
        }


   


        //디테일페이지
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string v = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            detail writeForm = new detail(this,v);
            writeForm.Owner = this;
            writeForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            type = comboBox1.SelectedItem.ToString();
            getData(type, searchType);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            searchType = comboBox2.SelectedItem.ToString();

     
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 엔터키를 입력받으면 실행
            {
                search(sender, e);
   }
        }
    }
}
