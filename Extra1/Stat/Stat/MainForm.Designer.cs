namespace Stat
{
    partial class MainForm
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
            this.SampleTextField = new System.Windows.Forms.TextBox();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.ShowStatButton = new System.Windows.Forms.Button();
            this.ShowGraphButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SampleTextField
            // 
            this.SampleTextField.Location = new System.Drawing.Point(0, 0);
            this.SampleTextField.Multiline = true;
            this.SampleTextField.Name = "SampleTextField";
            this.SampleTextField.Size = new System.Drawing.Size(421, 352);
            this.SampleTextField.TabIndex = 0;
            // 
            // StyleBox
            // 
            this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StyleBox.FormattingEnabled = true;
            this.StyleBox.Location = new System.Drawing.Point(231, 358);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(176, 21);
            this.StyleBox.TabIndex = 1;
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(260, 385);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(123, 23);
            this.AnalyzeButton.TabIndex = 2;
            this.AnalyzeButton.Text = "Добавить в анализ";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // ShowStatButton
            // 
            this.ShowStatButton.Location = new System.Drawing.Point(13, 355);
            this.ShowStatButton.Name = "ShowStatButton";
            this.ShowStatButton.Size = new System.Drawing.Size(151, 23);
            this.ShowStatButton.TabIndex = 3;
            this.ShowStatButton.Text = "Посмотреть статистику";
            this.ShowStatButton.UseVisualStyleBackColor = true;
            this.ShowStatButton.Click += new System.EventHandler(this.ShowStatButton_Click);
            // 
            // ShowGraphButton
            // 
            this.ShowGraphButton.Location = new System.Drawing.Point(13, 384);
            this.ShowGraphButton.Name = "ShowGraphButton";
            this.ShowGraphButton.Size = new System.Drawing.Size(151, 23);
            this.ShowGraphButton.TabIndex = 4;
            this.ShowGraphButton.Text = "Посмотреть графики";
            this.ShowGraphButton.UseVisualStyleBackColor = true;
            this.ShowGraphButton.Click += new System.EventHandler(this.ShowGraphButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 409);
            this.Controls.Add(this.ShowGraphButton);
            this.Controls.Add(this.ShowStatButton);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.SampleTextField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Statistics analizer v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SampleTextField;
        private System.Windows.Forms.ComboBox StyleBox;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.Button ShowStatButton;
        private System.Windows.Forms.Button ShowGraphButton;
    }
}

