namespace expert_system
{
    partial class FormTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.childAnswer5 = new System.Windows.Forms.RadioButton();
            this.questionChild = new System.Windows.Forms.Label();
            this.childAnswer4 = new System.Windows.Forms.RadioButton();
            this.childAnswer3 = new System.Windows.Forms.RadioButton();
            this.childAnswer2 = new System.Windows.Forms.RadioButton();
            this.childAnswer1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.questionParent = new System.Windows.Forms.Label();
            this.parentAnswer3 = new System.Windows.Forms.RadioButton();
            this.parentAnswer2 = new System.Windows.Forms.RadioButton();
            this.parentAnswer1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.childAnswer5);
            this.groupBox1.Controls.Add(this.questionChild);
            this.groupBox1.Controls.Add(this.childAnswer4);
            this.groupBox1.Controls.Add(this.childAnswer3);
            this.groupBox1.Controls.Add(this.childAnswer2);
            this.groupBox1.Controls.Add(this.childAnswer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ребёнок";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // childAnswer5
            // 
            this.childAnswer5.AutoSize = true;
            this.childAnswer5.Location = new System.Drawing.Point(30, 165);
            this.childAnswer5.Name = "childAnswer5";
            this.childAnswer5.Size = new System.Drawing.Size(14, 13);
            this.childAnswer5.TabIndex = 5;
            this.childAnswer5.TabStop = true;
            this.childAnswer5.UseVisualStyleBackColor = true;
            // 
            // questionChild
            // 
            this.questionChild.AutoSize = true;
            this.questionChild.Location = new System.Drawing.Point(27, 16);
            this.questionChild.Name = "questionChild";
            this.questionChild.Size = new System.Drawing.Size(0, 13);
            this.questionChild.TabIndex = 4;
            // 
            // childAnswer4
            // 
            this.childAnswer4.AutoSize = true;
            this.childAnswer4.Location = new System.Drawing.Point(30, 137);
            this.childAnswer4.Name = "childAnswer4";
            this.childAnswer4.Size = new System.Drawing.Size(14, 13);
            this.childAnswer4.TabIndex = 3;
            this.childAnswer4.TabStop = true;
            this.childAnswer4.UseVisualStyleBackColor = true;
            // 
            // childAnswer3
            // 
            this.childAnswer3.AutoSize = true;
            this.childAnswer3.Location = new System.Drawing.Point(30, 104);
            this.childAnswer3.Name = "childAnswer3";
            this.childAnswer3.Size = new System.Drawing.Size(14, 13);
            this.childAnswer3.TabIndex = 2;
            this.childAnswer3.TabStop = true;
            this.childAnswer3.UseVisualStyleBackColor = true;
            // 
            // childAnswer2
            // 
            this.childAnswer2.AutoSize = true;
            this.childAnswer2.Location = new System.Drawing.Point(30, 76);
            this.childAnswer2.Name = "childAnswer2";
            this.childAnswer2.Size = new System.Drawing.Size(14, 13);
            this.childAnswer2.TabIndex = 1;
            this.childAnswer2.TabStop = true;
            this.childAnswer2.UseVisualStyleBackColor = true;
            // 
            // childAnswer1
            // 
            this.childAnswer1.AutoSize = true;
            this.childAnswer1.Location = new System.Drawing.Point(30, 43);
            this.childAnswer1.Name = "childAnswer1";
            this.childAnswer1.Size = new System.Drawing.Size(14, 13);
            this.childAnswer1.TabIndex = 0;
            this.childAnswer1.TabStop = true;
            this.childAnswer1.UseVisualStyleBackColor = true;
            this.childAnswer1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.questionParent);
            this.groupBox2.Controls.Add(this.parentAnswer3);
            this.groupBox2.Controls.Add(this.parentAnswer2);
            this.groupBox2.Controls.Add(this.parentAnswer1);
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Родитель";
            this.groupBox2.Visible = false;
            // 
            // questionParent
            // 
            this.questionParent.AutoSize = true;
            this.questionParent.Location = new System.Drawing.Point(38, 16);
            this.questionParent.Name = "questionParent";
            this.questionParent.Size = new System.Drawing.Size(0, 13);
            this.questionParent.TabIndex = 3;
            // 
            // parentAnswer3
            // 
            this.parentAnswer3.AutoSize = true;
            this.parentAnswer3.Location = new System.Drawing.Point(41, 104);
            this.parentAnswer3.Name = "parentAnswer3";
            this.parentAnswer3.Size = new System.Drawing.Size(14, 13);
            this.parentAnswer3.TabIndex = 2;
            this.parentAnswer3.TabStop = true;
            this.parentAnswer3.UseVisualStyleBackColor = true;
            // 
            // parentAnswer2
            // 
            this.parentAnswer2.AutoSize = true;
            this.parentAnswer2.Location = new System.Drawing.Point(41, 76);
            this.parentAnswer2.Name = "parentAnswer2";
            this.parentAnswer2.Size = new System.Drawing.Size(14, 13);
            this.parentAnswer2.TabIndex = 1;
            this.parentAnswer2.TabStop = true;
            this.parentAnswer2.UseVisualStyleBackColor = true;
            // 
            // parentAnswer1
            // 
            this.parentAnswer1.AutoSize = true;
            this.parentAnswer1.Location = new System.Drawing.Point(41, 43);
            this.parentAnswer1.Name = "parentAnswer1";
            this.parentAnswer1.Size = new System.Drawing.Size(14, 13);
            this.parentAnswer1.TabIndex = 0;
            this.parentAnswer1.TabStop = true;
            this.parentAnswer1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(892, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 115);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ответить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 369);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTest";
            this.Text = "Не оплачено";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton childAnswer4;
        private System.Windows.Forms.RadioButton childAnswer3;
        private System.Windows.Forms.RadioButton childAnswer2;
        private System.Windows.Forms.RadioButton childAnswer1;
        private System.Windows.Forms.RadioButton parentAnswer3;
        private System.Windows.Forms.RadioButton parentAnswer2;
        private System.Windows.Forms.RadioButton parentAnswer1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label questionChild;
        private System.Windows.Forms.Label questionParent;
        private System.Windows.Forms.RadioButton childAnswer5;
    }
}