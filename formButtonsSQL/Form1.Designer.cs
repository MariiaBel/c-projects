namespace FormButtons
{
    partial class Form1
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.insertBt = new System.Windows.Forms.Button();
            this.selectBt = new System.Windows.Forms.Button();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.textAge = new System.Windows.Forms.TextBox();
            this.textWage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteBt = new System.Windows.Forms.Button();
            this.updateBt = new System.Windows.Forms.Button();
            this.sortBt = new System.Windows.Forms.Button();
            this.textID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox.Location = new System.Drawing.Point(153, 56);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(644, 397);
            this.textBox.TabIndex = 0;
            // 
            // insertBt
            // 
            this.insertBt.Location = new System.Drawing.Point(12, 25);
            this.insertBt.Name = "insertBt";
            this.insertBt.Size = new System.Drawing.Size(75, 23);
            this.insertBt.TabIndex = 1;
            this.insertBt.Text = "INSERT";
            this.insertBt.UseVisualStyleBackColor = true;
            this.insertBt.Click += new System.EventHandler(this.insertBt_Click);
            // 
            // selectBt
            // 
            this.selectBt.Location = new System.Drawing.Point(153, 25);
            this.selectBt.Name = "selectBt";
            this.selectBt.Size = new System.Drawing.Size(75, 23);
            this.selectBt.TabIndex = 2;
            this.selectBt.Text = "SELECT";
            this.selectBt.UseVisualStyleBackColor = true;
            this.selectBt.Click += new System.EventHandler(this.selectBt_Click);
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(12, 74);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(100, 20);
            this.textFirstName.TabIndex = 3;
            // 
            // textLastName
            // 
            this.textLastName.Location = new System.Drawing.Point(12, 121);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(100, 20);
            this.textLastName.TabIndex = 4;
            // 
            // textAge
            // 
            this.textAge.Location = new System.Drawing.Point(12, 160);
            this.textAge.Name = "textAge";
            this.textAge.Size = new System.Drawing.Size(100, 20);
            this.textAge.TabIndex = 5;
            // 
            // textWage
            // 
            this.textWage.Location = new System.Drawing.Point(12, 198);
            this.textWage.Name = "textWage";
            this.textWage.Size = new System.Drawing.Size(100, 20);
            this.textWage.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "FirstName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "LastName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wage";
            // 
            // deleteBt
            // 
            this.deleteBt.Location = new System.Drawing.Point(722, 25);
            this.deleteBt.Name = "deleteBt";
            this.deleteBt.Size = new System.Drawing.Size(75, 23);
            this.deleteBt.TabIndex = 11;
            this.deleteBt.Text = "DELETE";
            this.deleteBt.UseVisualStyleBackColor = true;
            this.deleteBt.Click += new System.EventHandler(this.deleteBt_Click);
            // 
            // updateBt
            // 
            this.updateBt.Location = new System.Drawing.Point(564, 25);
            this.updateBt.Name = "updateBt";
            this.updateBt.Size = new System.Drawing.Size(75, 23);
            this.updateBt.TabIndex = 12;
            this.updateBt.Text = "UPDATE";
            this.updateBt.UseVisualStyleBackColor = true;
            this.updateBt.Click += new System.EventHandler(this.updateBt_Click);
            // 
            // sortBt
            // 
            this.sortBt.Location = new System.Drawing.Point(234, 25);
            this.sortBt.Name = "sortBt";
            this.sortBt.Size = new System.Drawing.Size(75, 23);
            this.sortBt.TabIndex = 13;
            this.sortBt.Text = "SORT";
            this.sortBt.UseVisualStyleBackColor = true;
            this.sortBt.Click += new System.EventHandler(this.sortBt_Click);
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(520, 28);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(35, 20);
            this.textID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.sortBt);
            this.Controls.Add(this.updateBt);
            this.Controls.Add(this.deleteBt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textWage);
            this.Controls.Add(this.textAge);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.selectBt);
            this.Controls.Add(this.insertBt);
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button insertBt;
        private System.Windows.Forms.Button selectBt;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.TextBox textAge;
        private System.Windows.Forms.TextBox textWage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteBt;
        private System.Windows.Forms.Button updateBt;
        private System.Windows.Forms.Button sortBt;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label5;
    }
}

