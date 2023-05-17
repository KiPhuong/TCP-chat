namespace telnet_server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvMess = new System.Windows.Forms.ListView();
            this.btnNghe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMess
            // 
            this.lvMess.Location = new System.Drawing.Point(12, 48);
            this.lvMess.Name = "lvMess";
            this.lvMess.Size = new System.Drawing.Size(638, 255);
            this.lvMess.TabIndex = 0;
            this.lvMess.UseCompatibleStateImageBehavior = false;
            this.lvMess.View = System.Windows.Forms.View.List;
            // 
            // btnNghe
            // 
            this.btnNghe.Location = new System.Drawing.Point(535, 12);
            this.btnNghe.Name = "btnNghe";
            this.btnNghe.Size = new System.Drawing.Size(115, 30);
            this.btnNghe.TabIndex = 1;
            this.btnNghe.Text = "Listen";
            this.btnNghe.UseVisualStyleBackColor = true;
            this.btnNghe.Click += new System.EventHandler(this.btnNghe_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 23);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnNghe);
            this.Controls.Add(this.lvMess);
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bai05_Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvMess;
        private Button btnNghe;
        private TextBox textBox1;
        private Button button1;
    }
}