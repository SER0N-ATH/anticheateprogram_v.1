using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace eSports_Checker
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            linkLabel1.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
        }

        private void TX_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.forum.tankix.com/forums/topic/3535-esports-in-tankix-new-born-proleague");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.proleague.xyz");
        }

        private void TO_Click(object sender, EventArgs e)
        {
            Process.Start("http://en.tankiforum.com/index.php?showtopic=351603");
        }

        private void User_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            method();
        }

        string cs = "roleagu_eSportsLogin;UID=proleagu_eApp;PASSWORD=honestplay;SslMode=none;";

        public static string nickname;
        public static string propass;


        private void method()
        {
            if (User_Box.Text == "" || PID_Box.Text == "")
            {
                MessageBox.Show("Please enter your Nickname and PID");
                return;
            }

            try
            {
                MySqlConnection con = new MySqlConnection(cs);
                MySqlCommand cmd = new MySqlCommand("Select * from Login where nickname=@nickname and pid=@pid", con);
                cmd.Parameters.AddWithValue("@nickname", User_Box.Text);
                cmd.Parameters.AddWithValue("@pid", PID_Box.Text);
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = 0;
                count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    checker();
                }
                else
                {
                    MessageBox.Show("Login Failed! Please double check your username and/or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        string vifier = "";
        private void checkvalue()
        {
            string connString = "DATABASE=proleagu_eSportsLogin;UID=proleagu_eApp;PASSWORD=honestplay;SslMode=none;";
            MySqlConnection conn = new MySqlConnection(connString);

            using (var GetName = new MySqlCommand("SELECT Banned FROM Login WHERE Nickname = @nickname", conn))
            {
                GetName.Parameters.AddWithValue("@nickname", User_Box.Text);
                conn.Open();
                using (MySqlDataReader dr = GetName.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vifier = "";
                        vifier = dr.GetString(dr.GetOrdinal("Banned"));

                    }
                }
                conn.Close();
            }

        }

       

        string settings = "";

        private void Serveset()
        {
            string connString = "roleagu_eSportsLogin;UID=proleagu_eApp;PASSWORD=honestplay;SslMode=none;";
            MySqlConnection conn = new MySqlConnection(connString);

            using (var GetName = new MySqlCommand("SELECT ServerMode FROM Login WHERE Nickname = @nickname", conn))
            {
                GetName.Parameters.AddWithValue("@nickname", User_Box.Text);
                conn.Open();
                using (MySqlDataReader dr = GetName.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        settings = "";
                        settings = dr.GetString(dr.GetOrdinal("ServerMode"));

                    }
                }
                conn.Close();
            }

        }

        private void checker()
        {

            checkvalue();
            Serveset();
            if (settings == "1")
            {
                MessageBox.Show("ProLeague eSports Checkers Servers are turned off." + Environment.NewLine + "Contact the administrators if you believe this is an error!");
            }

           else if (vifier == "0")
            {
                MessageBox.Show("Login Success! ");
                this.Hide();
                var Notice = new Notice();
                nickname = User_Box.Text;
                propass = PID_Box.Text;
                Notice.Closed += (s, args) => this.Close();
                Notice.Show();
            }

            else if (vifier == "1")
            {
                MessageBox.Show("You are banned from ProLeague!");
            }
        }

        private void Attention_Click(object sender, EventArgs e)
        {

        }

        private void Website_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.proleague.xyz");
        }

        private void Discord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.me/ProLeague");
        }

        private void Fb_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/pr0league");
        }

        private void YT_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCbjM_-wrwYw5Nq-gfFCg70A");
        }

        private void Email_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:help@proleague.xyz?subject=Help");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This program was made possible by " + Environment.NewLine + "Seron Athavan(Atlanta) for programming + algorithm "
                );
        }
    }
}
