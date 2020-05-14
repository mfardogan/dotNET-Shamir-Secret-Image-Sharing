namespace MfArdogan.SecretSharing.UI
{
    partial class EncryptionWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbSecretImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numK = new System.Windows.Forms.NumericUpDown();
            this.numN = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExpose = new System.Windows.Forms.Button();
            this.flowSharingObjects = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectImage);
            this.groupBox1.Controls.Add(this.pbSecretImage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secret Image";
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
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(6, 210);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(177, 23);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Step-1: Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numN);
            this.groupBox2.Controls.Add(this.numK);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "(K,N)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "k:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "n:";
            // 
            // numK
            // 
            this.numK.Location = new System.Drawing.Point(48, 19);
            this.numK.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numK.Name = "numK";
            this.numK.Size = new System.Drawing.Size(48, 20);
            this.numK.TabIndex = 2;
            this.numK.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numN
            // 
            this.numN.Location = new System.Drawing.Point(124, 19);
            this.numN.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numN.Name = "numN";
            this.numN.Size = new System.Drawing.Size(48, 20);
            this.numN.TabIndex = 3;
            this.numN.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowSharingObjects);
            this.groupBox3.Location = new System.Drawing.Point(206, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(677, 346);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sharing Objects";
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(12, 315);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(60, 43);
            this.btnShare.TabIndex = 3;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(74, 315);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 43);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExpose
            // 
            this.btnExpose.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExpose.Location = new System.Drawing.Point(136, 315);
            this.btnExpose.Name = "btnExpose";
            this.btnExpose.Size = new System.Drawing.Size(65, 43);
            this.btnExpose.TabIndex = 5;
            this.btnExpose.Text = "Expose";
            this.btnExpose.UseVisualStyleBackColor = true;
            this.btnExpose.Click += new System.EventHandler(this.btnExpose_Click);
            // 
            // flowSharingObjects
            // 
            this.flowSharingObjects.BackColor = System.Drawing.Color.Transparent;
            this.flowSharingObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSharingObjects.Location = new System.Drawing.Point(3, 16);
            this.flowSharingObjects.Name = "flowSharingObjects";
            this.flowSharingObjects.Size = new System.Drawing.Size(671, 327);
            this.flowSharingObjects.TabIndex = 0;
            // 
            // EncryptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 364);
            this.Controls.Add(this.btnExpose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EncryptionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "#mfardoğan | Secret Image Sharing";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox pbSecretImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numN;
        private System.Windows.Forms.NumericUpDown numK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowSharingObjects;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExpose;
    }
}

