namespace Analysis
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
            this.CryptogrammBox = new System.Windows.Forms.TextBox();
            this.BrootedTextBox = new System.Windows.Forms.TextBox();
            this.BeginButton = new System.Windows.Forms.Button();
            this.KeysBox = new System.Windows.Forms.ComboBox();
            this.SampleBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CryptogrammBox
            // 
            this.CryptogrammBox.Location = new System.Drawing.Point(13, 13);
            this.CryptogrammBox.Multiline = true;
            this.CryptogrammBox.Name = "CryptogrammBox";
            this.CryptogrammBox.Size = new System.Drawing.Size(361, 321);
            this.CryptogrammBox.TabIndex = 0;
            // 
            // BrootedTextBox
            // 
            this.BrootedTextBox.Location = new System.Drawing.Point(399, 13);
            this.BrootedTextBox.Multiline = true;
            this.BrootedTextBox.Name = "BrootedTextBox";
            this.BrootedTextBox.ReadOnly = true;
            this.BrootedTextBox.Size = new System.Drawing.Size(361, 321);
            this.BrootedTextBox.TabIndex = 0;
            // 
            // BeginButton
            // 
            this.BeginButton.Location = new System.Drawing.Point(13, 341);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(103, 49);
            this.BeginButton.TabIndex = 1;
            this.BeginButton.Text = "Начать анализ ключей";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // KeysBox
            // 
            this.KeysBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeysBox.FormattingEnabled = true;
            this.KeysBox.Location = new System.Drawing.Point(399, 341);
            this.KeysBox.Name = "KeysBox";
            this.KeysBox.Size = new System.Drawing.Size(121, 21);
            this.KeysBox.TabIndex = 2;
            this.KeysBox.SelectedIndexChanged += new System.EventHandler(this.KeysBox_SelectedIndexChanged);
            // 
            // SampleBox
            // 
            this.SampleBox.Location = new System.Drawing.Point(399, 369);
            this.SampleBox.Multiline = true;
            this.SampleBox.Name = "SampleBox";
            this.SampleBox.ReadOnly = true;
            this.SampleBox.Size = new System.Drawing.Size(361, 63);
            this.SampleBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Применить ключ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SampleBox);
            this.Controls.Add(this.KeysBox);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.BrootedTextBox);
            this.Controls.Add(this.CryptogrammBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "CryptoAnalysator v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CryptogrammBox;
        private System.Windows.Forms.TextBox BrootedTextBox;
        private System.Windows.Forms.Button BeginButton;
        private System.Windows.Forms.ComboBox KeysBox;
        private System.Windows.Forms.TextBox SampleBox;
        private System.Windows.Forms.Button button1;
    }
}

