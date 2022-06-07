namespace WinFormComponents
{
    partial class Form_Catalog
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
            this.btnSearchForm = new System.Windows.Forms.Button();
            this.btnEditForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchForm
            // 
            this.btnSearchForm.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSearchForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearchForm.Location = new System.Drawing.Point(13, 13);
            this.btnSearchForm.Name = "btnSearchForm";
            this.btnSearchForm.Size = new System.Drawing.Size(120, 30);
            this.btnSearchForm.TabIndex = 0;
            this.btnSearchForm.Text = "SEARCH";
            this.btnSearchForm.UseVisualStyleBackColor = false;
            this.btnSearchForm.Click += new System.EventHandler(this.btnSearchForm_Click);
            // 
            // btnEditForm
            // 
            this.btnEditForm.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditForm.Location = new System.Drawing.Point(13, 59);
            this.btnEditForm.Name = "btnEditForm";
            this.btnEditForm.Size = new System.Drawing.Size(120, 30);
            this.btnEditForm.TabIndex = 1;
            this.btnEditForm.Text = "EDIT";
            this.btnEditForm.UseVisualStyleBackColor = false;
            this.btnEditForm.Click += new System.EventHandler(this.btnEditForm_Click);
            // 
            // Form_Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditForm);
            this.Controls.Add(this.btnSearchForm);
            this.Name = "Form_Catalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATALOG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchForm;
        private System.Windows.Forms.Button btnEditForm;
    }
}

