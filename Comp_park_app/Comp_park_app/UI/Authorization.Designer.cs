
namespace Comp_park_app.UI
{
    partial class Authorization
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
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.button_entry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_regis = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(137, 93);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(100, 23);
            this.textBox_Login.TabIndex = 0;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(137, 150);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(100, 23);
            this.textBox_Password.TabIndex = 1;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(65, 96);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(41, 15);
            this.label_login.TabIndex = 2;
            this.label_login.Text = "Логин";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(65, 153);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(49, 15);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Пароль";
            // 
            // button_entry
            // 
            this.button_entry.Location = new System.Drawing.Point(65, 213);
            this.button_entry.Name = "button_entry";
            this.button_entry.Size = new System.Drawing.Size(75, 23);
            this.button_entry.TabIndex = 4;
            this.button_entry.Text = "Войти";
            this.button_entry.UseVisualStyleBackColor = true;
            this.button_entry.Click += new System.EventHandler(this.button_entry_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Авторизация";
            // 
            // button_regis
            // 
            this.button_regis.Location = new System.Drawing.Point(101, 267);
            this.button_regis.Name = "button_regis";
            this.button_regis.Size = new System.Drawing.Size(100, 23);
            this.button_regis.TabIndex = 6;
            this.button_regis.Text = "Регистрация";
            this.button_regis.UseVisualStyleBackColor = true;
            this.button_regis.Click += new System.EventHandler(this.button_regis_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(162, 213);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 7;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 335);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_regis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_entry);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Login);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_entry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_regis;
        private System.Windows.Forms.Button button_exit;
    }
}