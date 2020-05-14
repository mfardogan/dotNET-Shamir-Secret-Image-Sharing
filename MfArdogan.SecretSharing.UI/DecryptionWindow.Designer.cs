namespace MfArdogan.SecretSharing.UI
{
    partial class DecryptionWindow
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowSharingObjects = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pbSecretImage = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowSharingObjects);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 260);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sharing Objects";
            // 
            // flowSharingObjects
            // 
            this.flowSharingObjects.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowSharingObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSharingObjects.Location = new System.Drawing.Point(3, 16);
            this.flowSharingObjects.Name = "flowSharingObjects";
            this.flowSharingObjects.Size = new System.Drawing.Size(575, 241);
            this.flowSharingObjects.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbSecretImage);
            this.groupBox1.Location = new System.Drawing.Point(596, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 211);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secret Image";
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(596, 229);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(60, 43);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Select Shares";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // pbSecretImage
            // 
            this.pbSecretImage.BackColor = System.Drawing.Color.White;
            this.pbSecretImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSecretImage.Location = new System.Drawing.Point(3, 16);
            this.pbSecretImage.Name = "pbSecretImage";
            this.pbSecretImage.Size = new System.Drawing.Size(183, 188);
            this.pbSecretImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSecretImage.TabIndex = 0;
            this.pbSecretImage.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(724, 229);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 43);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(660, 229);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(60, 43);
            this.btnShare.TabIndex = 6;
            this.btnShare.Text = "Detect";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // DecryptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 285);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "DecryptionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "#mfardoğan | Detect image";
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowSharingObjects;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox pbSecretImage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnShare;
    }
}