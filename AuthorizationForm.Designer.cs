namespace Coursework
{
    partial class AuthorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            passwordLabel = new Label();
            loginLabel = new Label();
            passwordInput = new TextBox();
            loginInput = new TextBox();
            sendAuthorizationBtn = new Button();
            authorizationPanel = new Panel();
            authorizationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            passwordLabel.Location = new Point(3, 52);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(91, 24);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Пароль:";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            loginLabel.Location = new Point(19, 7);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(75, 24);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Логин:";
            // 
            // passwordInput
            // 
            passwordInput.Font = new Font("Arial", 12F, FontStyle.Bold);
            passwordInput.Location = new Point(118, 49);
            passwordInput.MaxLength = 20;
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(160, 30);
            passwordInput.TabIndex = 4;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // loginInput
            // 
            loginInput.Font = new Font("Arial", 12F, FontStyle.Bold);
            loginInput.Location = new Point(118, 1);
            loginInput.MaxLength = 20;
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(160, 30);
            loginInput.TabIndex = 3;
            // 
            // sendAuthorizationBtn
            // 
            sendAuthorizationBtn.BackColor = SystemColors.Control;
            sendAuthorizationBtn.FlatAppearance.BorderSize = 0;
            sendAuthorizationBtn.Font = new Font("Arial", 12F, FontStyle.Bold);
            sendAuthorizationBtn.Location = new Point(118, 101);
            sendAuthorizationBtn.Name = "sendAuthorizationBtn";
            sendAuthorizationBtn.Size = new Size(160, 39);
            sendAuthorizationBtn.TabIndex = 2;
            sendAuthorizationBtn.Text = "ВВОД";
            sendAuthorizationBtn.UseVisualStyleBackColor = true;
            sendAuthorizationBtn.Click += sendAuthorizationBtn_Click;
            // 
            // authorizationPanel
            // 
            authorizationPanel.AutoSize = true;
            authorizationPanel.Controls.Add(sendAuthorizationBtn);
            authorizationPanel.Controls.Add(loginInput);
            authorizationPanel.Controls.Add(passwordInput);
            authorizationPanel.Controls.Add(loginLabel);
            authorizationPanel.Controls.Add(passwordLabel);
            authorizationPanel.Location = new Point(51, 30);
            authorizationPanel.Name = "authorizationPanel";
            authorizationPanel.Size = new Size(281, 143);
            authorizationPanel.TabIndex = 5;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 203);
            Controls.Add(authorizationPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация пользователя";
            authorizationPanel.ResumeLayout(false);
            authorizationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordLabel;
        private Label loginLabel;
        private TextBox passwordInput;
        private TextBox loginInput;
        private Button sendAuthorizationBtn;
        private Panel authorizationPanel;
    }
}