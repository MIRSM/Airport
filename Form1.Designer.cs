namespace Airport
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mTbDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.rbEconomClass = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbBuisnesClass = new System.Windows.Forms.RadioButton();
            this.rbFirstClass = new System.Windows.Forms.RadioButton();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.cbArrival = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btMostPopularRoute = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gray;
            this.tabPage1.Controls.Add(this.btMostPopularRoute);
            this.tabPage1.Controls.Add(this.mTbDate);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btSearch);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.rbEconomClass);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.rbBuisnesClass);
            this.tabPage1.Controls.Add(this.rbFirstClass);
            this.tabPage1.Controls.Add(this.cbDestination);
            this.tabPage1.Controls.Add(this.cbArrival);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Простой";
            // 
            // mTbDate
            // 
            this.mTbDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mTbDate.BackColor = System.Drawing.Color.Gray;
            this.mTbDate.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mTbDate.ForeColor = System.Drawing.Color.White;
            this.mTbDate.Location = new System.Drawing.Point(8, 144);
            this.mTbDate.Mask = "00/00/0000";
            this.mTbDate.Name = "mTbDate";
            this.mTbDate.Size = new System.Drawing.Size(276, 25);
            this.mTbDate.TabIndex = 3;
            this.mTbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTbDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(89, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Дата:";
            // 
            // btSearch
            // 
            this.btSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSearch.BackColor = System.Drawing.Color.Gray;
            this.btSearch.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSearch.ForeColor = System.Drawing.Color.White;
            this.btSearch.Location = new System.Drawing.Point(56, 333);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(170, 27);
            this.btSearch.TabIndex = 8;
            this.btSearch.Text = "Найти билеты";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown1.BackColor = System.Drawing.Color.Gray;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(86, 301);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(121, 25);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(82, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пассажиров:";
            // 
            // rbEconomClass
            // 
            this.rbEconomClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbEconomClass.AutoSize = true;
            this.rbEconomClass.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbEconomClass.ForeColor = System.Drawing.Color.White;
            this.rbEconomClass.Location = new System.Drawing.Point(86, 252);
            this.rbEconomClass.Name = "rbEconomClass";
            this.rbEconomClass.Size = new System.Drawing.Size(77, 23);
            this.rbEconomClass.TabIndex = 6;
            this.rbEconomClass.Text = "Эконом";
            this.rbEconomClass.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(89, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Класс:";
            // 
            // rbBuisnesClass
            // 
            this.rbBuisnesClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbBuisnesClass.AutoSize = true;
            this.rbBuisnesClass.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbBuisnesClass.ForeColor = System.Drawing.Color.White;
            this.rbBuisnesClass.Location = new System.Drawing.Point(86, 223);
            this.rbBuisnesClass.Name = "rbBuisnesClass";
            this.rbBuisnesClass.Size = new System.Drawing.Size(71, 23);
            this.rbBuisnesClass.TabIndex = 5;
            this.rbBuisnesClass.TabStop = true;
            this.rbBuisnesClass.Text = "Бизнес";
            this.rbBuisnesClass.UseVisualStyleBackColor = true;
            // 
            // rbFirstClass
            // 
            this.rbFirstClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbFirstClass.AutoSize = true;
            this.rbFirstClass.Checked = true;
            this.rbFirstClass.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFirstClass.ForeColor = System.Drawing.Color.White;
            this.rbFirstClass.Location = new System.Drawing.Point(86, 194);
            this.rbFirstClass.Name = "rbFirstClass";
            this.rbFirstClass.Size = new System.Drawing.Size(78, 23);
            this.rbFirstClass.TabIndex = 4;
            this.rbFirstClass.TabStop = true;
            this.rbFirstClass.Text = "Первый";
            this.rbFirstClass.UseVisualStyleBackColor = true;
            // 
            // cbDestination
            // 
            this.cbDestination.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDestination.BackColor = System.Drawing.Color.Gray;
            this.cbDestination.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDestination.ForeColor = System.Drawing.Color.White;
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Location = new System.Drawing.Point(8, 93);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(276, 27);
            this.cbDestination.TabIndex = 2;
            // 
            // cbArrival
            // 
            this.cbArrival.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbArrival.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbArrival.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbArrival.BackColor = System.Drawing.Color.Gray;
            this.cbArrival.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbArrival.ForeColor = System.Drawing.Color.White;
            this.cbArrival.FormattingEnabled = true;
            this.cbArrival.Location = new System.Drawing.Point(8, 40);
            this.cbArrival.Name = "cbArrival";
            this.cbArrival.Size = new System.Drawing.Size(276, 27);
            this.cbArrival.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Прибытие:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отправление:";
            // 
            // btMostPopularRoute
            // 
            this.btMostPopularRoute.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btMostPopularRoute.BackColor = System.Drawing.Color.Gray;
            this.btMostPopularRoute.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMostPopularRoute.ForeColor = System.Drawing.Color.White;
            this.btMostPopularRoute.Location = new System.Drawing.Point(56, 366);
            this.btMostPopularRoute.Name = "btMostPopularRoute";
            this.btMostPopularRoute.Size = new System.Drawing.Size(170, 49);
            this.btMostPopularRoute.TabIndex = 12;
            this.btMostPopularRoute.Text = "Популярный маршрут";
            this.btMostPopularRoute.UseVisualStyleBackColor = false;
            this.btMostPopularRoute.Click += new System.EventHandler(this.BtMostPopularRoute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 444);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Поиск";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.ComboBox cbArrival;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbEconomClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbBuisnesClass;
        private System.Windows.Forms.RadioButton rbFirstClass;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.MaskedTextBox mTbDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btMostPopularRoute;
    }
}

