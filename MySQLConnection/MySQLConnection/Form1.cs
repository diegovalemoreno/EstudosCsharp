using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SQLiteConnection.CreateFile("MyDatabase.sqlite");

            DataTable dt = new DataTable();

            SQLiteConnection m_dbConnection = new SQLiteConnection(@"Data Source=C:\Program Files (x86)\Linx Sistemas\Linx MIDe Client\Database\ClientDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = this.txtSelect.Text;

            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection);
            da.Fill(dt);
            gvdDados.DataSource = dt.DefaultView;


            //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //command.ExecuteNonQuery();

            
            m_dbConnection.Close();
        }
    }
}
