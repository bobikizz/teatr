namespace teatr
{
    partial class AddFormA
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbperfotmance_id = new System.Windows.Forms.TextBox();
            this.tbcharacter_role = new System.Windows.Forms.TextBox();
            this.tbactor_name = new System.Windows.Forms.TextBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbperfotmance_id);
            this.groupBox1.Controls.Add(this.tbcharacter_role);
            this.groupBox1.Controls.Add(this.tbactor_name);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление записи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Роль актера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Имя актера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Номер выступления";
            // 
            // tbperfotmance_id
            // 
            this.tbperfotmance_id.Location = new System.Drawing.Point(140, 73);
            this.tbperfotmance_id.Name = "tbperfotmance_id";
            this.tbperfotmance_id.Size = new System.Drawing.Size(177, 20);
            this.tbperfotmance_id.TabIndex = 3;
            // 
            // tbcharacter_role
            // 
            this.tbcharacter_role.Location = new System.Drawing.Point(140, 145);
            this.tbcharacter_role.Name = "tbcharacter_role";
            this.tbcharacter_role.Size = new System.Drawing.Size(177, 20);
            this.tbcharacter_role.TabIndex = 1;
            // 
            // tbactor_name
            // 
            this.tbactor_name.Location = new System.Drawing.Point(140, 109);
            this.tbactor_name.Name = "tbactor_name";
            this.tbactor_name.Size = new System.Drawing.Size(177, 20);
            this.tbactor_name.TabIndex = 2;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(12, 288);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(88, 23);
            this.addbutton.TabIndex = 1;
            this.addbutton.Text = "Добавить";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddFormA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 339);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddFormA";
            this.Text = "Форма добавления записи";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbcharacter_role;
        private System.Windows.Forms.TextBox tbactor_name;
        private System.Windows.Forms.TextBox tbperfotmance_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button button2;
    }
}