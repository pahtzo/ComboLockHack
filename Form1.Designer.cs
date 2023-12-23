
namespace ComboLockHack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox_stickynum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_guess_odd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_guess_even = new System.Windows.Forms.ComboBox();
            this.label_result = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_stickynum
            // 
            this.comboBox_stickynum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39"});
            this.comboBox_stickynum.Location = new System.Drawing.Point(16, 26);
            this.comboBox_stickynum.MaxDropDownItems = 20;
            this.comboBox_stickynum.Name = "comboBox_stickynum";
            this.comboBox_stickynum.Size = new System.Drawing.Size(121, 21);
            this.comboBox_stickynum.TabIndex = 0;
            this.comboBox_stickynum.Text = "0";
            this.comboBox_stickynum.SelectedIndexChanged += new System.EventHandler(this.comboBox_firstnum_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "\"Sticky\" Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Guess Number Odd";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_guess_odd
            // 
            this.comboBox_guess_odd.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7",
            "9",
            "11"});
            this.comboBox_guess_odd.Location = new System.Drawing.Point(291, 26);
            this.comboBox_guess_odd.MaxDropDownItems = 20;
            this.comboBox_guess_odd.Name = "comboBox_guess_odd";
            this.comboBox_guess_odd.Size = new System.Drawing.Size(121, 21);
            this.comboBox_guess_odd.TabIndex = 2;
            this.comboBox_guess_odd.Text = "1";
            this.comboBox_guess_odd.SelectedIndexChanged += new System.EventHandler(this.comboBox_guessnum1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Guess Number Even";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_guess_even
            // 
            this.comboBox_guess_even.Items.AddRange(new object[] {
            "0",
            "2",
            "4",
            "6",
            "8",
            "10"});
            this.comboBox_guess_even.Location = new System.Drawing.Point(153, 26);
            this.comboBox_guess_even.MaxDropDownItems = 20;
            this.comboBox_guess_even.Name = "comboBox_guess_even";
            this.comboBox_guess_even.Size = new System.Drawing.Size(121, 21);
            this.comboBox_guess_even.TabIndex = 1;
            this.comboBox_guess_even.Text = "0";
            this.comboBox_guess_even.SelectedIndexChanged += new System.EventHandler(this.comboBox_guessnum2_SelectedIndexChanged);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_result.Location = new System.Drawing.Point(16, 61);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(175, 13);
            this.label_result.TabIndex = 10;
            this.label_result.Text = "Possible Combinations";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 81);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(593, 531);
            this.textBox1.TabIndex = 11;
            this.textBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 625);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_guess_even);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_guess_odd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_stickynum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Combination Padlock Hacker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_stickynum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_guess_odd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_guess_even;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.TextBox textBox1;
    }
}

