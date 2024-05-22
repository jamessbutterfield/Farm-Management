namespace Farm_Management
{
    partial class Form8
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
            this.labelPartName = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCreatePart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPartName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPartName.Location = new System.Drawing.Point(73, 115);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(66, 15);
            this.labelPartName.TabIndex = 11;
            this.labelPartName.Text = "Part Name";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(56, 22);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(240, 56);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 12;
            this.pictureBoxLogo.TabStop = false;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(73, 133);
            this.txtPartName.MaxLength = 25;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(207, 23);
            this.txtPartName.TabIndex = 13;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPartNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPartNumber.Location = new System.Drawing.Point(73, 182);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(79, 15);
            this.labelPartNumber.TabIndex = 14;
            this.labelPartNumber.Text = "Part Number";
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(73, 200);
            this.txtPartNumber.MaxLength = 25;
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(207, 23);
            this.txtPartNumber.TabIndex = 15;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPrice.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPrice.Location = new System.Drawing.Point(73, 249);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(35, 15);
            this.labelPrice.TabIndex = 16;
            this.labelPrice.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(73, 267);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(79, 23);
            this.txtPrice.TabIndex = 17;
            // 
            // btnCreatePart
            // 
            this.btnCreatePart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreatePart.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCreatePart.Location = new System.Drawing.Point(99, 317);
            this.btnCreatePart.Name = "btnCreatePart";
            this.btnCreatePart.Size = new System.Drawing.Size(155, 28);
            this.btnCreatePart.TabIndex = 20;
            this.btnCreatePart.Text = "CREATE";
            this.btnCreatePart.UseVisualStyleBackColor = true;
            this.btnCreatePart.Click += new System.EventHandler(this.CreatePart);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 379);
            this.Controls.Add(this.btnCreatePart);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelPartName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(366, 418);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(366, 418);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Part";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelPartName;
        private PictureBox pictureBoxLogo;
        private TextBox txtPartName;
        private Label labelPartNumber;
        private TextBox txtPartNumber;
        private Label labelPrice;
        private TextBox txtPrice;
        private Button btnCreatePart;
    }
}