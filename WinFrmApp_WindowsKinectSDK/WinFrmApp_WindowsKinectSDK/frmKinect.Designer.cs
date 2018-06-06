namespace WinFrmApp_WindowsKinectSDK
{
    partial class frmKinect
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
            this.btnStream = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblConnectionID = new System.Windows.Forms.Label();
            this.pbStream = new System.Windows.Forms.PictureBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblposx = new System.Windows.Forms.Label();
            this.btnStopStream = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStream
            // 
            this.btnStream.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStream.Location = new System.Drawing.Point(679, 42);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(75, 23);
            this.btnStream.TabIndex = 0;
            this.btnStream.Text = "Stream";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ConnectionID:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(91, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(10, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "-";
            // 
            // lblConnectionID
            // 
            this.lblConnectionID.AutoSize = true;
            this.lblConnectionID.Location = new System.Drawing.Point(91, 42);
            this.lblConnectionID.Name = "lblConnectionID";
            this.lblConnectionID.Size = new System.Drawing.Size(10, 13);
            this.lblConnectionID.TabIndex = 4;
            this.lblConnectionID.Text = "-";
            // 
            // pbStream
            // 
            this.pbStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStream.Location = new System.Drawing.Point(12, 69);
            this.pbStream.Name = "pbStream";
            this.pbStream.Size = new System.Drawing.Size(814, 311);
            this.pbStream.TabIndex = 5;
            this.pbStream.TabStop = false;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(390, 42);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(16, 13);
            this.lblPosition.TabIndex = 6;
            this.lblPosition.Text = "- -";
            // 
            // lblposx
            // 
            this.lblposx.AutoSize = true;
            this.lblposx.Location = new System.Drawing.Point(573, 42);
            this.lblposx.Name = "lblposx";
            this.lblposx.Size = new System.Drawing.Size(0, 13);
            this.lblposx.TabIndex = 7;
            // 
            // btnStopStream
            // 
            this.btnStopStream.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStopStream.Location = new System.Drawing.Point(598, 42);
            this.btnStopStream.Name = "btnStopStream";
            this.btnStopStream.Size = new System.Drawing.Size(75, 23);
            this.btnStopStream.TabIndex = 8;
            this.btnStopStream.Text = "Stop";
            this.btnStopStream.UseVisualStyleBackColor = true;
            this.btnStopStream.Click += new System.EventHandler(this.btnStopStream_Click);
            // 
            // frmKinect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 421);
            this.Controls.Add(this.btnStopStream);
            this.Controls.Add(this.lblposx);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.pbStream);
            this.Controls.Add(this.lblConnectionID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStream);
            this.Name = "frmKinect";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbStream;
        private System.Windows.Forms.Label lblposx;
        public System.Windows.Forms.Label lblConnectionID;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblPosition;
        public System.Windows.Forms.Button btnStream;
        private System.Windows.Forms.Button btnStopStream;
    }
}

