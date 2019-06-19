using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WSUSDisabler
{
    public partial class Form1 : Form
    {
        private readonly RegistryEditor _registryEditor = new RegistryEditor();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (_registryEditor.IsWsusUp())
                {
                    LoadWsusStatus();
                }
                else
                {
                    labelWsusStatus.Text = "Your system doesn't use WSUS or policies are misconfigured";
                    BtChangeWsus.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
        }


        //privates
        private bool _wsusOn = true;
        
        private void LoadWsusStatus()
        {
            _wsusOn = _registryEditor.GetKeyValue() == 1;
            labelWsusStatus.Text = _wsusOn ? "Your system use WSUS" : "WSUS disabled as source of updates";
            
        }

        private void BtChangeWsus_Click(object sender, EventArgs e)
        {
            if (_wsusOn)
            {
                _registryEditor.DisableWsus();
                
                _wsusOn = false;
            }
            else
            {
                _registryEditor.EnableWsus();

                _wsusOn = true;
            }

            labelWsusStatus.Text = _wsusOn ? "Your system use WSUS" : "WSUS disabled as source of updates";
            BtChangeWsus.Text = _wsusOn ? "Disable WSUS" : "Enable WSUS";
        }
    }
}