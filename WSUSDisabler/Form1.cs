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
        private readonly ServiceManager _serviceManager = new ServiceManager("wuauserv");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            if (_registryEditor.IsWsusUp())
            {
                _registryEditor.MakeBackup();
                LoadWsusStatus();
            }
            else
            {
                labelWsusStatus.Text = "Your system doesn't use WSUS or policies are misconfigured";
                BtChangeWsus.Enabled = false;
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _registryEditor.RestoreWorkKey();
            _registryEditor.BackupCleanUp();
        }


        //privates
        private bool _wsusOn = true;
        
        private void LoadWsusStatus()
        {
            _wsusOn = _registryEditor.WsusCheckState();
            labelWsusStatus.Text = _wsusOn ? "Your system use WSUS" : "WSUS disabled as source of updates";
            BtChangeWsus.Text = _wsusOn ? "Disable WSUS" : "Enable WSUS";
            
        }

        private void BtChangeWsus_Click(object sender, EventArgs e)
        {
            if (_wsusOn)
            {
                //disabling wsus...
                
                _serviceManager.StopService();
                _registryEditor.RemoveWorkKey();
                _serviceManager.StartService();
                
                _wsusOn = false;
            }
            else
            {
                //enabling wsus
                
                _serviceManager.StopService();
                _registryEditor.RestoreWorkKey();
                _serviceManager.StartService();
                
                _wsusOn = true;
            }

            labelWsusStatus.Text = _wsusOn ? "Your system use WSUS" : "WSUS disabled as source of updates";
            BtChangeWsus.Text = _wsusOn ? "Disable WSUS" : "Enable WSUS";
        }

        private void tmCheckService_Tick(object sender, EventArgs e)
        {
            labelServiceStatus.Text = _serviceManager.CheckStatus();
        }
    }
}