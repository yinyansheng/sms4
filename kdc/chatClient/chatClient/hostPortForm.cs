using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chatClient
{
    public partial class hostPortForm : Form
    {
        public hostPortForm()
        {
            InitializeComponent();
            this.cmbPort.DataSource = MyPort.getPorts(15);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TextCheck tc = new TextCheck();

            if (!tc.checkInputPort(this.txtPort.Text)) {
                MessageBox.Show(tc.WarningMessage);
                this.txtPort.Clear();
                this.txtPort.Focus();
                return;
            }



            if (!MyPort.checkPort(this.txtPort.Text))
            {
                MessageBox.Show("端口" + this.txtPort.Text + "已被占用,请重选选择，或者使用选择端口");
                this.txtPort.Clear();
                this.txtPort.Focus();
            }
            else
            {
                chatClientForm fm = (chatClientForm)this.Owner;
                GroupBox gb = (GroupBox)((TabPage)((TabControl)fm.Controls["myTabControl"]).Controls["registrationTab"]).Controls["groupBox1"];
                ((TextBox)(gb.Controls["txtHostPort"])).Text = this.txtPort.Text;
                this.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            chatClientForm fm = (chatClientForm)this.Owner;
            GroupBox gb=(GroupBox)((TabPage)((TabControl)fm.Controls["myTabControl"]).Controls["registrationTab"]).Controls["groupBox1"];
            ((TextBox)(gb.Controls["txtHostPort"])).Text = (String)this.cmbPort.SelectedItem;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cmbPort.DataSource = MyPort.getPorts(15);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hostPortForm_Load(object sender, EventArgs e)
        {
            this.txtPort.Select();
            this.txtPort.Focus();
        }


    }
}
