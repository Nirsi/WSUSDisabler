namespace WSUSDisabler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelWsusStatus = new System.Windows.Forms.Label();
            this.BtChangeWsus = new System.Windows.Forms.Button();
            this.labelServiceStatus = new System.Windows.Forms.Label();
            this.tmCheckService = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelWsusStatus
            // 
            this.labelWsusStatus.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelWsusStatus.Location = new System.Drawing.Point(13, 9);
            this.labelWsusStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWsusStatus.Name = "labelWsusStatus";
            this.labelWsusStatus.Size = new System.Drawing.Size(326, 58);
            this.labelWsusStatus.TabIndex = 0;
            this.labelWsusStatus.Text = "WSUS ";
            this.labelWsusStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtChangeWsus
            // 
            this.BtChangeWsus.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.BtChangeWsus.Location = new System.Drawing.Point(82, 129);
            this.BtChangeWsus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtChangeWsus.Name = "BtChangeWsus";
            this.BtChangeWsus.Size = new System.Drawing.Size(182, 39);
            this.BtChangeWsus.TabIndex = 1;
            this.BtChangeWsus.Text = "Unable to change";
            this.BtChangeWsus.UseVisualStyleBackColor = true;
            this.BtChangeWsus.Click += new System.EventHandler(this.BtChangeWsus_Click);
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.labelServiceStatus.Location = new System.Drawing.Point(13, 82);
            this.labelServiceStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(326, 22);
            this.labelServiceStatus.TabIndex = 2;
            this.labelServiceStatus.Text = "Service";
            this.labelServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmCheckService
            // 
            this.tmCheckService.Enabled = true;
            this.tmCheckService.Interval = 250;
            this.tmCheckService.Tick += new System.EventHandler(this.tmCheckService_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 180);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.BtChangeWsus);
            this.Controls.Add(this.labelWsusStatus);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "WSUS Disabler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelWsusStatus;
        private System.Windows.Forms.Label labelServiceStatus;
        private System.Windows.Forms.Timer tmCheckService;
        private System.Windows.Forms.Button BtChangeWsus;
    }
}