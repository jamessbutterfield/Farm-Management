namespace Farm_Management
{
    partial class Form6
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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelJobTitle = new System.Windows.Forms.Label();
            this.labelJobDescription = new System.Windows.Forms.Label();
            this.labelParts = new System.Windows.Forms.Label();
            this.labelHoursOrMiles = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.txtJobDescription = new System.Windows.Forms.TextBox();
            this.listBoxParts = new System.Windows.Forms.ListBox();
            this.txtVehicleHoursOrMiles = new System.Windows.Forms.TextBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnRemovePart = new System.Windows.Forms.Button();
            this.btnCreateOrEdit = new System.Windows.Forms.Button();
            this.labelJobComplete = new System.Windows.Forms.Label();
            this.checkBoxJobComplete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(120, 29);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(240, 56);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelJobTitle
            // 
            this.labelJobTitle.AutoSize = true;
            this.labelJobTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelJobTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelJobTitle.Location = new System.Drawing.Point(22, 131);
            this.labelJobTitle.Name = "labelJobTitle";
            this.labelJobTitle.Size = new System.Drawing.Size(54, 15);
            this.labelJobTitle.TabIndex = 10;
            this.labelJobTitle.Text = "Job Title";
            // 
            // labelJobDescription
            // 
            this.labelJobDescription.AutoSize = true;
            this.labelJobDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelJobDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelJobDescription.Location = new System.Drawing.Point(22, 199);
            this.labelJobDescription.Name = "labelJobDescription";
            this.labelJobDescription.Size = new System.Drawing.Size(93, 15);
            this.labelJobDescription.TabIndex = 11;
            this.labelJobDescription.Text = "Job Description";
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelParts.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelParts.Location = new System.Drawing.Point(22, 397);
            this.labelParts.Name = "labelParts";
            this.labelParts.Size = new System.Drawing.Size(35, 15);
            this.labelParts.TabIndex = 12;
            this.labelParts.Text = "Parts";
            // 
            // labelHoursOrMiles
            // 
            this.labelHoursOrMiles.AutoSize = true;
            this.labelHoursOrMiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHoursOrMiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHoursOrMiles.Location = new System.Drawing.Point(22, 570);
            this.labelHoursOrMiles.Name = "labelHoursOrMiles";
            this.labelHoursOrMiles.Size = new System.Drawing.Size(214, 15);
            this.labelHoursOrMiles.TabIndex = 13;
            this.labelHoursOrMiles.Text = "Vehicle Hours / Miles (At Completion)";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(22, 149);
            this.txtJobTitle.MaxLength = 30;
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(270, 23);
            this.txtJobTitle.TabIndex = 14;
            // 
            // txtJobDescription
            // 
            this.txtJobDescription.Location = new System.Drawing.Point(22, 217);
            this.txtJobDescription.Multiline = true;
            this.txtJobDescription.Name = "txtJobDescription";
            this.txtJobDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJobDescription.Size = new System.Drawing.Size(438, 152);
            this.txtJobDescription.TabIndex = 15;
            // 
            // listBoxParts
            // 
            this.listBoxParts.FormattingEnabled = true;
            this.listBoxParts.ItemHeight = 15;
            this.listBoxParts.Location = new System.Drawing.Point(22, 415);
            this.listBoxParts.Name = "listBoxParts";
            this.listBoxParts.Size = new System.Drawing.Size(370, 124);
            this.listBoxParts.TabIndex = 16;
            // 
            // txtVehicleHoursOrMiles
            // 
            this.txtVehicleHoursOrMiles.Location = new System.Drawing.Point(22, 588);
            this.txtVehicleHoursOrMiles.Name = "txtVehicleHoursOrMiles";
            this.txtVehicleHoursOrMiles.Size = new System.Drawing.Size(122, 23);
            this.txtVehicleHoursOrMiles.TabIndex = 17;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddPart.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddPart.Location = new System.Drawing.Point(404, 443);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(65, 25);
            this.btnAddPart.TabIndex = 18;
            this.btnAddPart.Text = "ADD";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.AddPart);
            // 
            // btnRemovePart
            // 
            this.btnRemovePart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemovePart.ForeColor = System.Drawing.Color.Crimson;
            this.btnRemovePart.Location = new System.Drawing.Point(404, 485);
            this.btnRemovePart.Name = "btnRemovePart";
            this.btnRemovePart.Size = new System.Drawing.Size(65, 25);
            this.btnRemovePart.TabIndex = 19;
            this.btnRemovePart.Text = "REMOVE";
            this.btnRemovePart.UseVisualStyleBackColor = true;
            this.btnRemovePart.Click += new System.EventHandler(this.RemovePart);
            // 
            // btnCreateOrEdit
            // 
            this.btnCreateOrEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateOrEdit.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCreateOrEdit.Location = new System.Drawing.Point(317, 600);
            this.btnCreateOrEdit.Name = "btnCreateOrEdit";
            this.btnCreateOrEdit.Size = new System.Drawing.Size(130, 40);
            this.btnCreateOrEdit.TabIndex = 20;
            this.btnCreateOrEdit.Text = "CREATE JOB";
            this.btnCreateOrEdit.UseVisualStyleBackColor = true;
            // 
            // labelJobComplete
            // 
            this.labelJobComplete.AutoSize = true;
            this.labelJobComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelJobComplete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelJobComplete.Location = new System.Drawing.Point(335, 152);
            this.labelJobComplete.Name = "labelJobComplete";
            this.labelJobComplete.Size = new System.Drawing.Size(83, 15);
            this.labelJobComplete.TabIndex = 21;
            this.labelJobComplete.Text = "Job Complete";
            // 
            // checkBoxJobComplete
            // 
            this.checkBoxJobComplete.AutoSize = true;
            this.checkBoxJobComplete.Location = new System.Drawing.Point(420, 153);
            this.checkBoxJobComplete.Name = "checkBoxJobComplete";
            this.checkBoxJobComplete.Size = new System.Drawing.Size(15, 14);
            this.checkBoxJobComplete.TabIndex = 22;
            this.checkBoxJobComplete.UseVisualStyleBackColor = true;
            this.checkBoxJobComplete.CheckedChanged += new System.EventHandler(this.CompleteJob);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.checkBoxJobComplete);
            this.Controls.Add(this.labelJobComplete);
            this.Controls.Add(this.btnCreateOrEdit);
            this.Controls.Add(this.btnRemovePart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.txtVehicleHoursOrMiles);
            this.Controls.Add(this.listBoxParts);
            this.Controls.Add(this.txtJobDescription);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.labelHoursOrMiles);
            this.Controls.Add(this.labelParts);
            this.Controls.Add(this.labelJobDescription);
            this.Controls.Add(this.labelJobTitle);
            this.Controls.Add(this.pictureBoxLogo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Job";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RefreshJobInformationPanel);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxLogo;
        private Label labelJobTitle;
        private Label labelJobDescription;
        private Label labelParts;
        private Label labelHoursOrMiles;
        private TextBox txtJobTitle;
        private TextBox txtJobDescription;
        private ListBox listBoxParts;
        private TextBox txtVehicleHoursOrMiles;
        private Button btnAddPart;
        private Button btnRemovePart;
        private Button btnCreateOrEdit;
        private Label labelJobComplete;
        private CheckBox checkBoxJobComplete;
    }
}