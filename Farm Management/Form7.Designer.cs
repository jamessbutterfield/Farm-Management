namespace Farm_Management
{
    partial class Form7
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
            this.checkedListBoxParts = new System.Windows.Forms.CheckedListBox();
            this.btnCreateNewPart = new System.Windows.Forms.Button();
            this.btnDeleteSelectedParts = new System.Windows.Forms.Button();
            this.btnAddSelectedParts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxParts
            // 
            this.checkedListBoxParts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBoxParts.FormattingEnabled = true;
            this.checkedListBoxParts.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxParts.Name = "checkedListBoxParts";
            this.checkedListBoxParts.Size = new System.Drawing.Size(425, 224);
            this.checkedListBoxParts.TabIndex = 0;
            // 
            // btnCreateNewPart
            // 
            this.btnCreateNewPart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateNewPart.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateNewPart.Location = new System.Drawing.Point(60, 252);
            this.btnCreateNewPart.Name = "btnCreateNewPart";
            this.btnCreateNewPart.Size = new System.Drawing.Size(155, 50);
            this.btnCreateNewPart.TabIndex = 19;
            this.btnCreateNewPart.Text = "CREATE NEW PART";
            this.btnCreateNewPart.UseVisualStyleBackColor = true;
            this.btnCreateNewPart.Click += new System.EventHandler(this.CreateNewPart);
            // 
            // btnDeleteSelectedParts
            // 
            this.btnDeleteSelectedParts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSelectedParts.ForeColor = System.Drawing.Color.Tomato;
            this.btnDeleteSelectedParts.Location = new System.Drawing.Point(232, 252);
            this.btnDeleteSelectedParts.Name = "btnDeleteSelectedParts";
            this.btnDeleteSelectedParts.Size = new System.Drawing.Size(155, 50);
            this.btnDeleteSelectedParts.TabIndex = 20;
            this.btnDeleteSelectedParts.Text = "DELETE SELECTED PART(S)";
            this.btnDeleteSelectedParts.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedParts.Click += new System.EventHandler(this.DeleteSelectedParts);
            // 
            // btnAddSelectedParts
            // 
            this.btnAddSelectedParts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddSelectedParts.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddSelectedParts.Location = new System.Drawing.Point(146, 319);
            this.btnAddSelectedParts.Name = "btnAddSelectedParts";
            this.btnAddSelectedParts.Size = new System.Drawing.Size(155, 50);
            this.btnAddSelectedParts.TabIndex = 21;
            this.btnAddSelectedParts.Text = "ADD SELECTED PART(S)";
            this.btnAddSelectedParts.UseVisualStyleBackColor = true;
            this.btnAddSelectedParts.Click += new System.EventHandler(this.AddSelectedParts);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 391);
            this.Controls.Add(this.btnAddSelectedParts);
            this.Controls.Add(this.btnDeleteSelectedParts);
            this.Controls.Add(this.btnCreateNewPart);
            this.Controls.Add(this.checkedListBoxParts);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 430);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parts";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkedListBoxParts;
        private Button btnCreateNewPart;
        private Button btnDeleteSelectedParts;
        private Button btnAddSelectedParts;
    }
}