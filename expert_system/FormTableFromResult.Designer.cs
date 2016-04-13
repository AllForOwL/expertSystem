namespace expert_system
{
    partial class FormTableFromResult
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.creative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.humanitarian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linguistic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mathematical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sports = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.technical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.creative,
            this.humanitarian,
            this.linguistic,
            this.mathematical,
            this.sports,
            this.technical});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(649, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // creative
            // 
            this.creative.HeaderText = "Творческий";
            this.creative.Name = "creative";
            // 
            // humanitarian
            // 
            this.humanitarian.HeaderText = "Гуманитарный";
            this.humanitarian.Name = "humanitarian";
            // 
            // linguistic
            // 
            this.linguistic.HeaderText = "Лингвистический";
            this.linguistic.Name = "linguistic";
            // 
            // mathematical
            // 
            this.mathematical.HeaderText = "Математический";
            this.mathematical.Name = "mathematical";
            // 
            // sports
            // 
            this.sports.HeaderText = "Спортивный";
            this.sports.Name = "sports";
            // 
            // technical
            // 
            this.technical.HeaderText = "Технический";
            this.technical.Name = "technical";
            // 
            // FormTableFromResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 181);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormTableFromResult";
            this.Text = "FormTableFromResult";
            this.Load += new System.EventHandler(this.FormTableFromResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn creative;
        private System.Windows.Forms.DataGridViewTextBoxColumn humanitarian;
        private System.Windows.Forms.DataGridViewTextBoxColumn linguistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn mathematical;
        private System.Windows.Forms.DataGridViewTextBoxColumn sports;
        private System.Windows.Forms.DataGridViewTextBoxColumn technical;
    }
}