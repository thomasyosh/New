using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1.View
{
    public partial class Form2 : Form
    {
        IQueryable<User> user;
        UserController controller = new UserController();
        List<string> re = new List<string>();


        public Form2()
        {
            InitializeComponent();
            this.Show();
            this.user = controller.FindUser();



            comboBox1.DataSource = user.Select(w => new User
            {
                UserId = w.UserId,
                UserName = w.UserName,
            }).ToList();

            comboBox1.ValueMember = "UserId";
            comboBox1.DisplayMember = "UserName";

            comboBox1.SelectedItem = null;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            re.Add(comboBox1.SelectedValue.ToString());
            textBox1.Text = String.Join(", ", re.ToArray());
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
