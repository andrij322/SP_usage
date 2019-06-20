using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StoredProcedure
{
    public partial class Form1 : Form
    {
        SqlConnection sql;
        SqlCommand command;

        public Form1()
        {
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            command = new SqlCommand();

            command.Connection = sql;
            
            InitializeComponent();
        }
        private void findFilmByYear(object sender,EventArgs eventArgs)
        {
            command.CommandText = "EXEC sp_selectFilmByYear @selectYear = " + textBox1.Text;

            sql.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                MessageBox.Show(reader.GetString(0));
            }
        }
    }
}
