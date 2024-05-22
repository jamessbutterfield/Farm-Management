namespace Farm_Management
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelVehicleInformation = new System.Windows.Forms.Panel();
            this.labelPleaseSelectVehicle = new System.Windows.Forms.Label();
            this.layoutPanelVehicles = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.panelVehicleInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "YOUR VEHICLES";
            // 
            // panelVehicleInformation
            // 
            this.panelVehicleInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVehicleInformation.Controls.Add(this.labelPleaseSelectVehicle);
            this.panelVehicleInformation.Location = new System.Drawing.Point(617, 35);
            this.panelVehicleInformation.Name = "panelVehicleInformation";
            this.panelVehicleInformation.Size = new System.Drawing.Size(606, 613);
            this.panelVehicleInformation.TabIndex = 5;
            // 
            // labelPleaseSelectVehicle
            // 
            this.labelPleaseSelectVehicle.AutoSize = true;
            this.labelPleaseSelectVehicle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPleaseSelectVehicle.ForeColor = System.Drawing.Color.Silver;
            this.labelPleaseSelectVehicle.Location = new System.Drawing.Point(239, 284);
            this.labelPleaseSelectVehicle.Name = "labelPleaseSelectVehicle";
            this.labelPleaseSelectVehicle.Size = new System.Drawing.Size(128, 44);
            this.labelPleaseSelectVehicle.TabIndex = 8;
            this.labelPleaseSelectVehicle.Text = "Please Select\r\na Vehicle...";
            this.labelPleaseSelectVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutPanelVehicles
            // 
            this.layoutPanelVehicles.ColumnCount = 5;
            this.layoutPanelVehicles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.Location = new System.Drawing.Point(29, 104);
            this.layoutPanelVehicles.Name = "layoutPanelVehicles";
            this.layoutPanelVehicles.RowCount = 5;
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.layoutPanelVehicles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelVehicles.Size = new System.Drawing.Size(550, 550);
            this.layoutPanelVehicles.TabIndex = 4;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(29, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(240, 56);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 7;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.SystemColors.Control;
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStatistics.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnStatistics.Location = new System.Drawing.Point(457, 29);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(122, 39);
            this.btnStatistics.TabIndex = 8;
            this.btnStatistics.Text = "STATISTICS";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.ViewStatistics);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelVehicleInformation);
            this.Controls.Add(this.layoutPanelVehicles);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farm Management";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panelVehicleInformation.ResumeLayout(false);
            this.panelVehicleInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panelVehicleInformation;
        private TableLayoutPanel layoutPanelVehicles;
        private PictureBox pictureBoxLogo;
        private Label labelWelcome;
        private Label labelCurrentUser;
        private Label labelPleaseSelectVehicle;
        private Button btnStatistics;
    }
}