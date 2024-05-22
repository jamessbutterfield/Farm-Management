namespace Farm_Management
{
    partial class Form10
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
            this.btnPartsCost = new System.Windows.Forms.Button();
            this.btnHoursOrMiles = new System.Windows.Forms.Button();
            this.btnNumberOfJobs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSelectVehicle = new System.Windows.Forms.Label();
            this.checkedListBoxVehicles = new System.Windows.Forms.CheckedListBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPartsCost
            // 
            this.btnPartsCost.BackColor = System.Drawing.SystemColors.Control;
            this.btnPartsCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPartsCost.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPartsCost.Location = new System.Drawing.Point(39, 82);
            this.btnPartsCost.Name = "btnPartsCost";
            this.btnPartsCost.Size = new System.Drawing.Size(97, 38);
            this.btnPartsCost.TabIndex = 0;
            this.btnPartsCost.Text = "PARTS COST";
            this.btnPartsCost.UseVisualStyleBackColor = false;
            this.btnPartsCost.Click += new System.EventHandler(this.PartsCost);
            // 
            // btnHoursOrMiles
            // 
            this.btnHoursOrMiles.BackColor = System.Drawing.SystemColors.Control;
            this.btnHoursOrMiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHoursOrMiles.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnHoursOrMiles.Location = new System.Drawing.Point(39, 144);
            this.btnHoursOrMiles.Name = "btnHoursOrMiles";
            this.btnHoursOrMiles.Size = new System.Drawing.Size(118, 38);
            this.btnHoursOrMiles.TabIndex = 1;
            this.btnHoursOrMiles.Text = "HOURS OR MILES";
            this.btnHoursOrMiles.UseVisualStyleBackColor = false;
            this.btnHoursOrMiles.Click += new System.EventHandler(this.HoursOrMiles);
            // 
            // btnNumberOfJobs
            // 
            this.btnNumberOfJobs.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumberOfJobs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNumberOfJobs.ForeColor = System.Drawing.Color.MediumOrchid;
            this.btnNumberOfJobs.Location = new System.Drawing.Point(39, 206);
            this.btnNumberOfJobs.Name = "btnNumberOfJobs";
            this.btnNumberOfJobs.Size = new System.Drawing.Size(126, 38);
            this.btnNumberOfJobs.TabIndex = 2;
            this.btnNumberOfJobs.Text = "NUMBER OF JOBS";
            this.btnNumberOfJobs.UseVisualStyleBackColor = false;
            this.btnNumberOfJobs.Click += new System.EventHandler(this.NumberOfJobs);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select an Option:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "Find out how much a\r\nvehicle (or vehicles) have cost over\r\na specified time perio" +
    "d.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Find out the number of hours or \r\nmiles a vehicle has done between \r\na specified " +
    "time period.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 45);
            this.label4.TabIndex = 6;
            this.label4.Text = "Displays a graph comparing all\r\nvehicles against the number of jobs\r\nthey have ha" +
    "d completed.";
            // 
            // labelSelectVehicle
            // 
            this.labelSelectVehicle.AutoSize = true;
            this.labelSelectVehicle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectVehicle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSelectVehicle.Location = new System.Drawing.Point(518, 33);
            this.labelSelectVehicle.Name = "labelSelectVehicle";
            this.labelSelectVehicle.Size = new System.Drawing.Size(170, 22);
            this.labelSelectVehicle.TabIndex = 7;
            this.labelSelectVehicle.Text = "Select Vehicle(s):";
            // 
            // checkedListBoxVehicles
            // 
            this.checkedListBoxVehicles.FormattingEnabled = true;
            this.checkedListBoxVehicles.Location = new System.Drawing.Point(519, 88);
            this.checkedListBoxVehicles.Name = "checkedListBoxVehicles";
            this.checkedListBoxVehicles.Size = new System.Drawing.Size(175, 130);
            this.checkedListBoxVehicles.TabIndex = 8;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerateReport.Location = new System.Drawing.Point(687, 247);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(135, 33);
            this.btnGenerateReport.TabIndex = 9;
            this.btnGenerateReport.Text = "GENERATE REPORT";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.GenerateReport);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(519, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Select all:";
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(577, 68);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSelectAll.TabIndex = 11;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.SelectAllVehicles);
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.CustomFormat = "ddMMyyyy";
            this.dateTimeFrom.Location = new System.Drawing.Point(718, 115);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(200, 23);
            this.dateTimeFrom.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(715, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "From:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(715, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "To:";
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.CustomFormat = "ddMMyyyy";
            this.dateTimeTo.Location = new System.Drawing.Point(718, 187);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(200, 23);
            this.dateTimeTo.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(518, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 30);
            this.label5.TabIndex = 16;
            this.label5.Text = "Only vehicles with completed\r\njobs are displayed here.\r\n";
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 306);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeFrom);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.checkedListBoxVehicles);
            this.Controls.Add(this.labelSelectVehicle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNumberOfJobs);
            this.Controls.Add(this.btnHoursOrMiles);
            this.Controls.Add(this.btnPartsCost);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 345);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 345);
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPartsCost;
        private Button btnHoursOrMiles;
        private Button btnNumberOfJobs;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelSelectVehicle;
        private CheckedListBox checkedListBoxVehicles;
        private Button btnGenerateReport;
        private Label label6;
        private CheckBox checkBoxSelectAll;
        private DateTimePicker dateTimeFrom;
        private Label label7;
        private Label label8;
        private DateTimePicker dateTimeTo;
        private Label label5;
    }
}