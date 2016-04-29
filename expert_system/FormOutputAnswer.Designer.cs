namespace expert_system
{
    partial class FormOutputAnswer
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
            this.gridOutputAnswer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutputAnswer)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOutputAnswer
            // 
            this.gridOutputAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOutputAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOutputAnswer.Location = new System.Drawing.Point(0, 0);
            this.gridOutputAnswer.Name = "gridOutputAnswer";
            this.gridOutputAnswer.Size = new System.Drawing.Size(289, 390);
            this.gridOutputAnswer.TabIndex = 0;
            this.gridOutputAnswer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOutputAnswer_CellContentClick);
            // 
            // FormOutputAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 390);
            this.Controls.Add(this.gridOutputAnswer);
            this.Name = "FormOutputAnswer";
            this.Text = "FormOutputAnswer";
            ((System.ComponentModel.ISupportInitialize)(this.gridOutputAnswer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridOutputAnswer;
    }
}