
namespace Autoreport.UI
{
    partial class Login : BaseForm
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
            this.auth_label = new System.Windows.Forms.Label();
            this.login_text = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.password_text = new System.Windows.Forms.TextBox();
            this.login_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.login_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // auth_label
            // 
            this.auth_label.AutoSize = true;
            this.auth_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.auth_label.Location = new System.Drawing.Point(48, 10);
            this.auth_label.Name = "auth_label";
            this.auth_label.Size = new System.Drawing.Size(135, 25);
            this.auth_label.TabIndex = 0;
            this.auth_label.Text = "Авторизация";
            // 
            // login_text
            // 
            this.login_text.Location = new System.Drawing.Point(0, 18);
            this.login_text.Name = "login_text";
            this.login_text.Size = new System.Drawing.Size(200, 23);
            this.login_text.TabIndex = 3;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(0, 45);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(49, 15);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // password_text
            // 
            this.password_text.Location = new System.Drawing.Point(0, 63);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(200, 23);
            this.password_text.TabIndex = 5;
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.login_label.Location = new System.Drawing.Point(3, 0);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(41, 15);
            this.login_label.TabIndex = 6;
            this.login_label.Text = "Логин";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.login_label);
            this.panel1.Controls.Add(this.login_text);
            this.panel1.Controls.Add(this.password_text);
            this.panel1.Controls.Add(this.password_label);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 155);
            this.panel1.TabIndex = 7;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(62, 130);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 25);
            this.login_btn.TabIndex = 7;
            this.login_btn.Text = "Войти";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 235);
            this.Controls.Add(this.auth_label);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "Login";
            this.Text = "Вход";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label auth_label;
        private System.Windows.Forms.TextBox login_text;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button login_btn;
    }
}