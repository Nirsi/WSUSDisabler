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
            this.labelWsusStatus = new System.Windows.Forms.Label();
            this.BtChangeWsus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.labelWsusStatus.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelWsusStatus.Location = new System.Drawing.Point(13, 23);
            this.labelWsusStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWsusStatus.Name = "labelWsusStatus";
            this.labelWsusStatus.Size = new System.Drawing.Size(326, 44);
            this.labelWsusStatus.TabIndex = 0;
            this.labelWsusStatus.Text = "WSUS ";
            this.labelWsusStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtChangeWsus.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.BtChangeWsus.Location = new System.Drawing.Point(82, 129);
            this.BtChangeWsus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtChangeWsus.Name = "BtChangeWsus";
            this.BtChangeWsus.Size = new System.Drawing.Size(182, 39);
            this.BtChangeWsus.TabIndex = 1;
            this.BtChangeWsus.Text = "Unable to change";
            this.BtChangeWsus.UseVisualStyleBackColor = true;
            this.BtChangeWsus.Click += new System.EventHandler(this.BtChangeWsus_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 180);
            this.Controls.Add(this.BtChangeWsus);
            this.Controls.Add(this.labelWsusStatus);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "WSUSDisabler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelWsusStatus;
        private System.Windows.Forms.Button BtChangeWsus;
    }
}