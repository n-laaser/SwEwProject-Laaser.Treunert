namespace GraphPlotting
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
            ploti = new ScottPlot.WinForms.FormsPlot();
            ComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            checkBox = new CheckBox();
            LoadFunction = new Button();
            Function = new Label();
            FunctionLabel = new Label();
            Solution = new Label();
            SolutionButton = new Button();
            RestartButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            AnswerLabel = new Label();
            SuspendLayout();
            // 
            // ploti
            // 
            ploti.DisplayScale = 1F;
            ploti.Location = new Point(19, 296);
            ploti.Name = "ploti";
            ploti.Size = new Size(488, 266);
            ploti.TabIndex = 0;
            ploti.Visible = false;
            // 
            // ComboBox
            // 
            ComboBox.CausesValidation = false;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            ComboBox.Location = new Point(161, 31);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(121, 23);
            ComboBox.TabIndex = 1;
            ComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.SizeNWSE;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 31);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 2;
            label1.Text = "Grad der Funktion:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(31, 69);
            label2.Name = "label2";
            label2.Size = new Size(135, 19);
            label2.TabIndex = 3;
            label2.Text = "Rationale Nullstellen:";
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(172, 69);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(15, 14);
            checkBox.TabIndex = 4;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LoadFunction
            // 
            LoadFunction.Location = new Point(393, 69);
            LoadFunction.Name = "LoadFunction";
            LoadFunction.Size = new Size(107, 23);
            LoadFunction.TabIndex = 5;
            LoadFunction.Text = "Lade Funktion";
            LoadFunction.UseVisualStyleBackColor = true;
            LoadFunction.Click += button1_Click;
            // 
            // Function
            // 
            Function.AutoSize = true;
            Function.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Function.Location = new Point(19, 152);
            Function.Name = "Function";
            Function.Size = new Size(43, 19);
            Function.TabIndex = 6;
            Function.Text = "f(x): ...";
            Function.Visible = false;
            // 
            // FunctionLabel
            // 
            FunctionLabel.AutoSize = true;
            FunctionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FunctionLabel.Location = new Point(19, 118);
            FunctionLabel.Name = "FunctionLabel";
            FunctionLabel.Size = new Size(268, 19);
            FunctionLabel.TabIndex = 7;
            FunctionLabel.Text = "Berechnen Sie die Nullstellen der Funktion:";
            FunctionLabel.Visible = false;
            // 
            // Solution
            // 
            Solution.AutoSize = true;
            Solution.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Solution.Location = new Point(19, 274);
            Solution.Name = "Solution";
            Solution.Size = new Size(75, 19);
            Solution.TabIndex = 8;
            Solution.Text = "Nullstellen:";
            Solution.Visible = false;
            // 
            // SolutionButton
            // 
            SolutionButton.Location = new Point(391, 229);
            SolutionButton.Name = "SolutionButton";
            SolutionButton.Size = new Size(109, 23);
            SolutionButton.TabIndex = 9;
            SolutionButton.Text = "Lösung anzeigen";
            SolutionButton.UseVisualStyleBackColor = true;
            SolutionButton.Visible = false;
            SolutionButton.Click += SolutionButton_Click;
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(425, 568);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(75, 23);
            RestartButton.TabIndex = 10;
            RestartButton.Text = "Nochmal";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Visible = false;
            RestartButton.Click += RestartButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 213);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(25, 23);
            textBox1.TabIndex = 12;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(69, 213);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(25, 23);
            textBox2.TabIndex = 13;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(119, 213);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(25, 23);
            textBox3.TabIndex = 14;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(169, 213);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(25, 23);
            textBox4.TabIndex = 15;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(219, 213);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(25, 23);
            textBox5.TabIndex = 16;
            textBox5.Visible = false;
            // 
            // AnswerLabel
            // 
            AnswerLabel.AutoSize = true;
            AnswerLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            AnswerLabel.Location = new Point(19, 182);
            AnswerLabel.Name = "AnswerLabel";
            AnswerLabel.Size = new Size(199, 19);
            AnswerLabel.TabIndex = 17;
            AnswerLabel.Text = "Geben Sie hier Ihre Lösung ein:";
            AnswerLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 602);
            Controls.Add(AnswerLabel);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(RestartButton);
            Controls.Add(SolutionButton);
            Controls.Add(Solution);
            Controls.Add(FunctionLabel);
            Controls.Add(Function);
            Controls.Add(LoadFunction);
            Controls.Add(checkBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ComboBox);
            Controls.Add(ploti);
            Name = "Form1";
            Text = "Nullstellenberechnung";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot ploti;
        private ComboBox ComboBox;
        private Label label1;
        private Label label2;
        private CheckBox checkBox;
        private Button LoadFunction;
        private Label Function;
        private Label FunctionLabel;
        private Label Solution;
        private Button SolutionButton;
        private Button RestartButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label AnswerLabel;
    }
}