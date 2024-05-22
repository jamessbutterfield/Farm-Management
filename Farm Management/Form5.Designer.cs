namespace Farm_Management
{
    partial class Form5
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
            this.flowpanelJobList = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJobInformation = new System.Windows.Forms.Panel();
            this.labelPleaseSelectJob = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnCompleteJobs = new System.Windows.Forms.Button();
            this.btnIncompleteJobs = new System.Windows.Forms.Button();
            this.btnCreateJob = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelJobInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // flowpanelJobList
            // 
            this.flowpanelJobList.AutoScroll = true;
            this.flowpanelJobList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowpanelJobList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpanelJobList.Location = new System.Drawing.Point(17, 158);
            this.flowpanelJobList.Name = "flowpanelJobList";
            this.flowpanelJobList.Size = new System.Drawing.Size(340, 408);
            this.flowpanelJobList.TabIndex = 0;
            this.flowpanelJobList.WrapContents = false;
            // 
            // panelJobInformation
            // 
            this.panelJobInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelJobInformation.Controls.Add(this.labelPleaseSelectJob);
            this.panelJobInformation.Location = new System.Drawing.Point(377, 12);
            this.panelJobInformation.Name = "panelJobInformation";
            this.panelJobInformation.Size = new System.Drawing.Size(495, 607);
            this.panelJobInformation.TabIndex = 1;
            // 
            // labelPleaseSelectJob
            // 
            this.labelPleaseSelectJob.AutoSize = true;
            this.labelPleaseSelectJob.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPleaseSelectJob.ForeColor = System.Drawing.Color.Silver;
            this.labelPleaseSelectJob.Location = new System.Drawing.Point(194, 274);
            this.labelPleaseSelectJob.Name = "labelPleaseSelectJob";
            this.labelPleaseSelectJob.Size = new System.Drawing.Size(128, 44);
            this.labelPleaseSelectJob.TabIndex = 9;
            this.labelPleaseSelectJob.Text = "Please Select\r\na Job...";
            this.labelPleaseSelectJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(240, 56);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnCompleteJobs
            // 
            this.btnCompleteJobs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompleteJobs.ForeColor = System.Drawing.Color.DarkGray;
            this.btnCompleteJobs.Location = new System.Drawing.Point(17, 126);
            this.btnCompleteJobs.Name = "btnCompleteJobs";
            this.btnCompleteJobs.Size = new System.Drawing.Size(80, 25);
            this.btnCompleteJobs.TabIndex = 10;
            this.btnCompleteJobs.Text = "COMPLETE";
            this.btnCompleteJobs.UseVisualStyleBackColor = true;
            this.btnCompleteJobs.Click += new System.EventHandler(this.PopulateCompleteJobs);
            // 
            // btnIncompleteJobs
            // 
            this.btnIncompleteJobs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIncompleteJobs.ForeColor = System.Drawing.Color.DimGray;
            this.btnIncompleteJobs.Location = new System.Drawing.Point(119, 126);
            this.btnIncompleteJobs.Name = "btnIncompleteJobs";
            this.btnIncompleteJobs.Size = new System.Drawing.Size(95, 25);
            this.btnIncompleteJobs.TabIndex = 9;
            this.btnIncompleteJobs.Text = "INCOMPLETE";
            this.btnIncompleteJobs.UseVisualStyleBackColor = true;
            this.btnIncompleteJobs.Click += new System.EventHandler(this.PopulateIncompleteJobs);
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateJob.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCreateJob.Location = new System.Drawing.Point(139, 579);
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Size = new System.Drawing.Size(95, 25);
            this.btnCreateJob.TabIndex = 11;
            this.btnCreateJob.Text = "CREATE JOB";
            this.btnCreateJob.UseVisualStyleBackColor = true;
            this.btnCreateJob.Click += new System.EventHandler(this.CreateJob);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(235, 127);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search...";
            this.txtSearch.Size = new System.Drawing.Size(122, 23);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.UpdateJobList);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 631);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCreateJob);
            this.Controls.Add(this.btnIncompleteJobs);
            this.Controls.Add(this.btnCompleteJobs);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.panelJobInformation);
            this.Controls.Add(this.flowpanelJobList);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 670);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 670);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farm Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RefreshVehicleInformationPanel);
            this.Load += new System.EventHandler(this.OnLoad);
            this.panelJobInformation.ResumeLayout(false);
            this.panelJobInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowpanelJobList;
        private Panel panelJobInformation;
        private PictureBox pictureBoxLogo;
        private Button btnCompleteJobs;
        private Button btnIncompleteJobs;
        private Button btnCreateJob;
        private Label labelPleaseSelectJob;
        private TextBox txtSearch;
    }
}