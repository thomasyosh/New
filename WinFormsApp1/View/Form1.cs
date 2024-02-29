using WinFormsApp1.Controller;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(textBox1.Text,textBox2.Text);
            UserController userController = new UserController(user);
            /*MessageBox.Show(userController.AddUser());*/
            int result = userController.isValidUser(user);
            switch (result)
            {
                case 9:
                    MessageBox.Show("login success");
                    MessageController messageController;
                    messageController = new MessageController();
                    break;
                case 1:
                    MessageBox.Show("no such account");
                    break;
                case 2:
                    MessageBox.Show("account locked");
                    break;
                case 3:
                    MessageBox.Show("password incorrect");
                    break;


            }



        }
    }
}
