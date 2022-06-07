namespace WinFormComponents.Controls
{
    partial class Form_Search<T>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgwList = new System.Windows.Forms.DataGridView();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.btnAction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).BeginInit();
            this.tlpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(8, 16, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgwList
            // 
            this.dgwList.AllowUserToResizeRows = false;
            this.dgwList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwList.Location = new System.Drawing.Point(2, 46);
            this.dgwList.Margin = new System.Windows.Forms.Padding(2);
            this.dgwList.MultiSelect = false;
            this.dgwList.Name = "dgwList";
            this.dgwList.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwList.RowTemplate.Height = 30;
            this.dgwList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwList.Size = new System.Drawing.Size(655, 352);
            this.dgwList.TabIndex = 1;
            this.dgwList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwList_CellDoubleClick);
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.Controls.Add(this.dgwList, 0, 1);
            this.tlpContainer.Controls.Add(this.txtSearch, 0, 0);
            this.tlpContainer.Controls.Add(this.btnAction, 0, 2);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Margin = new System.Windows.Forms.Padding(2);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 3;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpContainer.Size = new System.Drawing.Size(659, 446);
            this.tlpContainer.TabIndex = 2;
            // 
            // btnIzlaz
            // 
            this.btnAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAction.Location = new System.Drawing.Point(565, 408);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.btnAction.Name = "btnIzlaz";
            this.btnAction.Size = new System.Drawing.Size(90, 30);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Izlaz";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // Form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 446);
            this.Controls.Add(this.tlpContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Search";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).EndInit();
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgwList;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        public System.Windows.Forms.Button btnAction;
    }
}