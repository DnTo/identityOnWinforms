using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdentityEnWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        public bool VerifyUserNamePassword(string userName, string password)
        {
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
            return  usermanager.Find(userName, password) != null;
        }

        public IdentityResult CreateUser(string userName, string password)
        {
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
            var user = new IdentityUser { UserName = userName, Email = userName };
            return usermanager.Create(user, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = textBox1.Text; var p = textBox2.Text;
            try
            {
                var t = CreateUser(u, p);
                var errores = "";
                t.Errors.ToList().ForEach(x => errores += x+ Environment.NewLine);
                MessageBox.Show(t.ToString() + errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var u = textBox1.Text; var p = textBox2.Text;
            try
            {
                var t = VerifyUserNamePassword(u, p);
                MessageBox.Show(t.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
