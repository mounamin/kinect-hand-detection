using System;

namespace WindowsFormsApplication1
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
            this.pbDepthStream = new System.Windows.Forms.PictureBox();
            this.pbSkeleton = new System.Windows.Forms.PictureBox();
            this.zlabel = new System.Windows.Forms.Label();
            this.xlabel = new System.Windows.Forms.Label();
            this.ylabel = new System.Windows.Forms.Label();
            this.xlabel2 = new System.Windows.Forms.Label();
            this.ylabel2 = new System.Windows.Forms.Label();
            this.zlabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepthStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkeleton)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStream
            // 
            this.btnStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStream.Location = new System.Drawing.Point(1094, 414);
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connection ID :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(102, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(10, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "-";
            // 
            // lblConnectionID
            // 
            this.lblConnectionID.AutoSize = true;
            this.lblConnectionID.Location = new System.Drawing.Point(105, 61);
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
            this.pbStream.Location = new System.Drawing.Point(13, 88);
            this.pbStream.Name = "pbStream";
            this.pbStream.Size = new System.Drawing.Size(341, 308);
            this.pbStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbStream.TabIndex = 5;
            this.pbStream.TabStop = false;
            // 
            // pbDepthStream
            // 
            this.pbDepthStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDepthStream.Location = new System.Drawing.Point(387, 88);
            this.pbDepthStream.Name = "pbDepthStream";
            this.pbDepthStream.Size = new System.Drawing.Size(338, 308);
            this.pbDepthStream.TabIndex = 6;
            this.pbDepthStream.TabStop = false;
            // 
            // pbSkeleton
            // 
            this.pbSkeleton.Location = new System.Drawing.Point(788, 88);
            this.pbSkeleton.Name = "pbSkeleton";
            this.pbSkeleton.Size = new System.Drawing.Size(349, 308);
            this.pbSkeleton.TabIndex = 7;
            this.pbSkeleton.TabStop = false;
            // 
            // zlabel
            // 
            this.zlabel.AutoSize = true;
            this.zlabel.Location = new System.Drawing.Point(767, 399);
            this.zlabel.Name = "zlabel";
            this.zlabel.Size = new System.Drawing.Size(44, 13);
            this.zlabel.TabIndex = 8;
            this.zlabel.Text = "zvalueL";
            this.zlabel.Click += new System.EventHandler(this.zlabel_Click);
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Location = new System.Drawing.Point(18, 399);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(44, 13);
            this.xlabel.TabIndex = 9;
            this.xlabel.Text = "xvalueL";
            this.xlabel.Click += new System.EventHandler(this.xlabel_Click);
            // 
            // ylabel
            // 
            this.ylabel.AutoSize = true;
            this.ylabel.Location = new System.Drawing.Point(349, 399);
            this.ylabel.Name = "ylabel";
            this.ylabel.Size = new System.Drawing.Size(44, 13);
            this.ylabel.TabIndex = 10;
            this.ylabel.Text = "yvalueL";
            this.ylabel.Click += new System.EventHandler(this.ylabel_Click);
            // 
            // xlabel2
            // 
            this.xlabel2.AutoSize = true;
            this.xlabel2.Location = new System.Drawing.Point(18, 427);
            this.xlabel2.Name = "xlabel2";
            this.xlabel2.Size = new System.Drawing.Size(46, 13);
            this.xlabel2.TabIndex = 11;
            this.xlabel2.Text = "xvalueR";
            this.xlabel2.Click += new System.EventHandler(this.xlabel2_Click);
            // 
            // ylabel2
            // 
            this.ylabel2.AutoSize = true;
            this.ylabel2.Location = new System.Drawing.Point(347, 427);
            this.ylabel2.Name = "ylabel2";
            this.ylabel2.Size = new System.Drawing.Size(46, 13);
            this.ylabel2.TabIndex = 12;
            this.ylabel2.Text = "yvalueR";
            this.ylabel2.Click += new System.EventHandler(this.ylabel2_Click);
            // 
            // zlabel2
            // 
            this.zlabel2.AutoSize = true;
            this.zlabel2.Location = new System.Drawing.Point(767, 424);
            this.zlabel2.Name = "zlabel2";
            this.zlabel2.Size = new System.Drawing.Size(40, 13);
            this.zlabel2.TabIndex = 13;
            this.zlabel2.Text = "zvalueR";
            this.zlabel2.Click += new System.EventHandler(this.zlabel2_Click);
            // 
            // frmKinect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 449);
            this.Controls.Add(this.zlabel2);
            this.Controls.Add(this.ylabel2);
            this.Controls.Add(this.xlabel2);
            this.Controls.Add(this.ylabel);
            this.Controls.Add(this.xlabel);
            this.Controls.Add(this.zlabel);
            this.Controls.Add(this.pbSkeleton);
            this.Controls.Add(this.pbDepthStream);
            this.Controls.Add(this.pbStream);
            this.Controls.Add(this.lblConnectionID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStream);
            this.Name = "frmKinect";
            this.Text = "frmKinect";
         
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepthStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkeleton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblConnectionID;
        private System.Windows.Forms.PictureBox pbStream;
        private System.Windows.Forms.PictureBox pbDepthStream;
        private System.Windows.Forms.PictureBox pbSkeleton;
        private System.Windows.Forms.Label zlabel;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Label ylabel;
        private System.Windows.Forms.Label xlabel2;
        private System.Windows.Forms.Label ylabel2;
        private System.Windows.Forms.Label zlabel2;
    }
}

