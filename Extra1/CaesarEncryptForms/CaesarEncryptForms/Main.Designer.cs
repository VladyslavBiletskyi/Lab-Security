﻿namespace CaesarEncryptForms
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EncryptButton = new System.Windows.Forms.Button();
            this.CryptoBox = new System.Windows.Forms.TextBox();
            this.PureTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.DecryptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(28, 343);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(103, 49);
            this.EncryptButton.TabIndex = 4;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // CryptoBox
            // 
            this.CryptoBox.Location = new System.Drawing.Point(414, 15);
            this.CryptoBox.Multiline = true;
            this.CryptoBox.Name = "CryptoBox";
            this.CryptoBox.ReadOnly = true;
            this.CryptoBox.Size = new System.Drawing.Size(361, 321);
            this.CryptoBox.TabIndex = 2;
            // 
            // PureTextBox
            // 
            this.PureTextBox.Location = new System.Drawing.Point(28, 15);
            this.PureTextBox.Multiline = true;
            this.PureTextBox.Name = "PureTextBox";
            this.PureTextBox.Size = new System.Drawing.Size(361, 321);
            this.PureTextBox.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(149, 343);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown1.TabIndex = 5;
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(204, 343);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(103, 49);
            this.DecryptButton.TabIndex = 4;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 406);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.CryptoBox);
            this.Controls.Add(this.PureTextBox);
            this.Name = "Main";
            this.Text = "CaesarEncryptor v1.1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.TextBox CryptoBox;
        private System.Windows.Forms.TextBox PureTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button DecryptButton;
    }
}

