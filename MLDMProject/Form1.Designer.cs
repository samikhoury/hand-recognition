namespace MLDMProject
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveButton = new System.Windows.Forms.Button();
            this.eraseButton = new System.Windows.Forms.Button();
            this.labelsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.histchart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.kNNbox = new System.Windows.Forms.TextBox();
            this.kNNButton = new System.Windows.Forms.Button();
            this.hMMButton = new System.Windows.Forms.Button();
            this.DTButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lrButton = new System.Windows.Forms.Button();
            this.RFButton = new System.Windows.Forms.Button();
            this.mvButton = new System.Windows.Forms.Button();
            this.fontBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ANNButton = new System.Windows.Forms.Button();
            this.SVMButton = new System.Windows.Forms.Button();
            this.drawbox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.drawbox2 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.resBox = new System.Windows.Forms.TextBox();
            this.trateBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.maxRfTreeBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.maxHdLayerBox = new System.Windows.Forms.TextBox();
            this.minHdLayerBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.stepSizeBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.maxLrBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.rfPerBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rfTreesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.efdGenButton = new System.Windows.Forms.Button();
            this.efdTBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.serializer = new System.Windows.Forms.Button();
            this.classifierBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epochBox = new System.Windows.Forms.TextBox();
            this.epoch = new System.Windows.Forms.Label();
            this.minLrBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TrainButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.testSSBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.testRFBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.testHLBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.percBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.testResultsBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.frBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.foldCVRadio = new System.Windows.Forms.RadioButton();
            this.randomCVRadio = new System.Windows.Forms.RadioButton();
            this.testNEBox = new System.Windows.Forms.TextBox();
            this.testNOEBox = new System.Windows.Forms.Label();
            this.testLRBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.kTestBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.testClassifierBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.histchart1)).BeginInit();
            this.panel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawbox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(116, 340);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(104, 25);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // eraseButton
            // 
            this.eraseButton.Location = new System.Drawing.Point(226, 339);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(104, 26);
            this.eraseButton.TabIndex = 4;
            this.eraseButton.Text = "Erase";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // labelsList
            // 
            this.labelsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.labelsList.FormattingEnabled = true;
            this.labelsList.Location = new System.Drawing.Point(116, 309);
            this.labelsList.MaxDropDownItems = 10;
            this.labelsList.Name = "labelsList";
            this.labelsList.Size = new System.Drawing.Size(104, 21);
            this.labelsList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hsitogram of freeman code";
            // 
            // histchart1
            // 
            chartArea1.Name = "ChartArea1";
            this.histchart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.histchart1.Legends.Add(legend1);
            this.histchart1.Location = new System.Drawing.Point(422, 153);
            this.histchart1.Name = "histchart1";
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.histchart1.Series.Add(series1);
            this.histchart1.Size = new System.Drawing.Size(442, 270);
            this.histchart1.TabIndex = 8;
            // 
            // kNNbox
            // 
            this.kNNbox.Location = new System.Drawing.Point(48, 30);
            this.kNNbox.Name = "kNNbox";
            this.kNNbox.Size = new System.Drawing.Size(58, 20);
            this.kNNbox.TabIndex = 9;
            // 
            // kNNButton
            // 
            this.kNNButton.Location = new System.Drawing.Point(6, 56);
            this.kNNButton.Name = "kNNButton";
            this.kNNButton.Size = new System.Drawing.Size(101, 22);
            this.kNNButton.TabIndex = 10;
            this.kNNButton.Text = "k-NN";
            this.kNNButton.UseVisualStyleBackColor = true;
            this.kNNButton.Click += new System.EventHandler(this.kNNButton_Click);
            // 
            // hMMButton
            // 
            this.hMMButton.Location = new System.Drawing.Point(6, 84);
            this.hMMButton.Name = "hMMButton";
            this.hMMButton.Size = new System.Drawing.Size(101, 23);
            this.hMMButton.TabIndex = 11;
            this.hMMButton.Text = "HMM";
            this.hMMButton.UseVisualStyleBackColor = true;
            this.hMMButton.Click += new System.EventHandler(this.hMMButton_Click);
            // 
            // DTButton
            // 
            this.DTButton.Location = new System.Drawing.Point(6, 113);
            this.DTButton.Name = "DTButton";
            this.DTButton.Size = new System.Drawing.Size(101, 23);
            this.DTButton.TabIndex = 12;
            this.DTButton.Text = "Decision Tree";
            this.DTButton.UseVisualStyleBackColor = true;
            this.DTButton.Click += new System.EventHandler(this.DTButton_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tabPage1);
            this.panel.Controls.Add(this.tabPage2);
            this.panel.Controls.Add(this.tabPage3);
            this.panel.Location = new System.Drawing.Point(13, 12);
            this.panel.Name = "panel";
            this.panel.SelectedIndex = 0;
            this.panel.Size = new System.Drawing.Size(891, 455);
            this.panel.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.lrButton);
            this.tabPage1.Controls.Add(this.RFButton);
            this.tabPage1.Controls.Add(this.mvButton);
            this.tabPage1.Controls.Add(this.fontBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.ANNButton);
            this.tabPage1.Controls.Add(this.SVMButton);
            this.tabPage1.Controls.Add(this.drawbox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox);
            this.tabPage1.Controls.Add(this.drawbox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.histchart1);
            this.tabPage1.Controls.Add(this.labelsList);
            this.tabPage1.Controls.Add(this.DTButton);
            this.tabPage1.Controls.Add(this.saveButton);
            this.tabPage1.Controls.Add(this.hMMButton);
            this.tabPage1.Controls.Add(this.eraseButton);
            this.tabPage1.Controls.Add(this.kNNButton);
            this.tabPage1.Controls.Add(this.kNNbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Classify";
            // 
            // lrButton
            // 
            this.lrButton.Location = new System.Drawing.Point(9, 201);
            this.lrButton.Name = "lrButton";
            this.lrButton.Size = new System.Drawing.Size(96, 23);
            this.lrButton.TabIndex = 26;
            this.lrButton.Text = "ML Regression";
            this.lrButton.UseVisualStyleBackColor = true;
            this.lrButton.Click += new System.EventHandler(this.lrButton_Click);
            // 
            // RFButton
            // 
            this.RFButton.Location = new System.Drawing.Point(9, 260);
            this.RFButton.Name = "RFButton";
            this.RFButton.Size = new System.Drawing.Size(96, 23);
            this.RFButton.TabIndex = 25;
            this.RFButton.Text = "Random Forest";
            this.RFButton.UseVisualStyleBackColor = true;
            this.RFButton.Click += new System.EventHandler(this.RFButton_Click);
            // 
            // mvButton
            // 
            this.mvButton.Location = new System.Drawing.Point(9, 229);
            this.mvButton.Name = "mvButton";
            this.mvButton.Size = new System.Drawing.Size(96, 23);
            this.mvButton.TabIndex = 24;
            this.mvButton.Text = "Majority Vote";
            this.mvButton.UseVisualStyleBackColor = true;
            this.mvButton.Click += new System.EventHandler(this.mvButton_Click);
            // 
            // fontBox
            // 
            this.fontBox.Location = new System.Drawing.Point(77, 5);
            this.fontBox.Name = "fontBox";
            this.fontBox.Size = new System.Drawing.Size(28, 20);
            this.fontBox.TabIndex = 23;
            this.fontBox.Text = "10";
            this.fontBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Font [5- 20]";
            // 
            // ANNButton
            // 
            this.ANNButton.Location = new System.Drawing.Point(7, 173);
            this.ANNButton.Name = "ANNButton";
            this.ANNButton.Size = new System.Drawing.Size(99, 23);
            this.ANNButton.TabIndex = 21;
            this.ANNButton.Text = "ANN";
            this.ANNButton.UseVisualStyleBackColor = true;
            this.ANNButton.Click += new System.EventHandler(this.ANNButton_Click);
            // 
            // SVMButton
            // 
            this.SVMButton.Location = new System.Drawing.Point(7, 143);
            this.SVMButton.Name = "SVMButton";
            this.SVMButton.Size = new System.Drawing.Size(99, 23);
            this.SVMButton.TabIndex = 20;
            this.SVMButton.Text = "SVM";
            this.SVMButton.UseVisualStyleBackColor = true;
            this.SVMButton.Click += new System.EventHandler(this.SVMButton_Click);
            // 
            // drawbox
            // 
            this.drawbox.BackColor = System.Drawing.SystemColors.Window;
            this.drawbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawbox.InitialImage = ((System.Drawing.Image)(resources.GetObject("drawbox.InitialImage")));
            this.drawbox.Location = new System.Drawing.Point(116, 4);
            this.drawbox.Name = "drawbox";
            this.drawbox.Size = new System.Drawing.Size(300, 300);
            this.drawbox.TabIndex = 13;
            this.drawbox.TabStop = false;
            this.drawbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawbox_MouseDown);
            this.drawbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawbox_MouseMove);
            this.drawbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawbox_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "K=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Freeman Chain Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(528, 25);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(336, 81);
            this.textBox.TabIndex = 15;
            // 
            // drawbox2
            // 
            this.drawbox2.BackColor = System.Drawing.SystemColors.Window;
            this.drawbox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawbox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("drawbox2.InitialImage")));
            this.drawbox2.Location = new System.Drawing.Point(422, 6);
            this.drawbox2.Name = "drawbox2";
            this.drawbox2.Size = new System.Drawing.Size(100, 100);
            this.drawbox2.TabIndex = 14;
            this.drawbox2.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.resBox);
            this.tabPage2.Controls.Add(this.trateBox);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.maxRfTreeBox);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.maxHdLayerBox);
            this.tabPage2.Controls.Add(this.minHdLayerBox);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.stepSizeBox);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.maxLrBox);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.rfPerBox);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.rfTreesBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.efdGenButton);
            this.tabPage2.Controls.Add(this.efdTBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.serializer);
            this.tabPage2.Controls.Add(this.classifierBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.epochBox);
            this.tabPage2.Controls.Add(this.epoch);
            this.tabPage2.Controls.Add(this.minLrBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TrainButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Train";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(375, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 39;
            this.label27.Text = "Results";
            // 
            // resBox
            // 
            this.resBox.Location = new System.Drawing.Point(378, 42);
            this.resBox.Multiline = true;
            this.resBox.Name = "resBox";
            this.resBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resBox.Size = new System.Drawing.Size(290, 240);
            this.resBox.TabIndex = 38;
            // 
            // trateBox
            // 
            this.trateBox.Location = new System.Drawing.Point(149, 242);
            this.trateBox.Name = "trateBox";
            this.trateBox.Size = new System.Drawing.Size(63, 20);
            this.trateBox.TabIndex = 37;
            this.trateBox.Text = "0.001";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 245);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(129, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "For HMM: Tolerance Rate";
            // 
            // maxRfTreeBox
            // 
            this.maxRfTreeBox.Location = new System.Drawing.Point(280, 177);
            this.maxRfTreeBox.Name = "maxRfTreeBox";
            this.maxRfTreeBox.Size = new System.Drawing.Size(39, 20);
            this.maxRfTreeBox.TabIndex = 35;
            this.maxRfTreeBox.Text = "20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(209, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 13);
            this.label21.TabIndex = 34;
            this.label21.Text = "Max #Trees";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(181, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Max Hidden Layer";
            // 
            // maxHdLayerBox
            // 
            this.maxHdLayerBox.Location = new System.Drawing.Point(280, 132);
            this.maxHdLayerBox.Name = "maxHdLayerBox";
            this.maxHdLayerBox.Size = new System.Drawing.Size(39, 20);
            this.maxHdLayerBox.TabIndex = 32;
            this.maxHdLayerBox.Text = "10";
            // 
            // minHdLayerBox
            // 
            this.minHdLayerBox.Location = new System.Drawing.Point(118, 133);
            this.minHdLayerBox.Name = "minHdLayerBox";
            this.minHdLayerBox.Size = new System.Drawing.Size(42, 20);
            this.minHdLayerBox.TabIndex = 31;
            this.minHdLayerBox.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Min Hidden Layer";
            // 
            // stepSizeBox
            // 
            this.stepSizeBox.Location = new System.Drawing.Point(118, 106);
            this.stepSizeBox.Name = "stepSizeBox";
            this.stepSizeBox.Size = new System.Drawing.Size(42, 20);
            this.stepSizeBox.TabIndex = 29;
            this.stepSizeBox.Text = "0.005";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(61, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "Step Size";
            // 
            // maxLrBox
            // 
            this.maxLrBox.Location = new System.Drawing.Point(281, 79);
            this.maxLrBox.Name = "maxLrBox";
            this.maxLrBox.Size = new System.Drawing.Size(38, 20);
            this.maxLrBox.TabIndex = 27;
            this.maxLrBox.Text = "0.1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(177, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Max Learning Rate";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Min Learning Rate";
            // 
            // rfPerBox
            // 
            this.rfPerBox.Location = new System.Drawing.Point(118, 202);
            this.rfPerBox.Name = "rfPerBox";
            this.rfPerBox.Size = new System.Drawing.Size(43, 20);
            this.rfPerBox.TabIndex = 24;
            this.rfPerBox.Text = "66";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 205);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Percentage";
            // 
            // rfTreesBox
            // 
            this.rfTreesBox.Location = new System.Drawing.Point(118, 177);
            this.rfTreesBox.Name = "rfTreesBox";
            this.rfTreesBox.Size = new System.Drawing.Size(44, 20);
            this.rfTreesBox.TabIndex = 22;
            this.rfTreesBox.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "For RF: Min #Trees";
            // 
            // efdGenButton
            // 
            this.efdGenButton.Location = new System.Drawing.Point(133, 361);
            this.efdGenButton.Name = "efdGenButton";
            this.efdGenButton.Size = new System.Drawing.Size(151, 23);
            this.efdGenButton.TabIndex = 20;
            this.efdGenButton.Text = "Generate EFD";
            this.efdGenButton.UseVisualStyleBackColor = true;
            this.efdGenButton.Click += new System.EventHandler(this.efdGenButton_Click);
            // 
            // efdTBox
            // 
            this.efdTBox.Location = new System.Drawing.Point(85, 363);
            this.efdTBox.Name = "efdTBox";
            this.efdTBox.Size = new System.Drawing.Size(43, 20);
            this.efdTBox.TabIndex = 19;
            this.efdTBox.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Number of EFD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Save the new classifiers";
            // 
            // serializer
            // 
            this.serializer.Location = new System.Drawing.Point(133, 332);
            this.serializer.Name = "serializer";
            this.serializer.Size = new System.Drawing.Size(151, 23);
            this.serializer.TabIndex = 16;
            this.serializer.Text = "Save";
            this.serializer.UseVisualStyleBackColor = true;
            this.serializer.Click += new System.EventHandler(this.serializer_Click);
            // 
            // classifierBox
            // 
            this.classifierBox.FormattingEnabled = true;
            this.classifierBox.Location = new System.Drawing.Point(118, 24);
            this.classifierBox.Name = "classifierBox";
            this.classifierBox.Size = new System.Drawing.Size(201, 21);
            this.classifierBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Train the data with";
            // 
            // epochBox
            // 
            this.epochBox.Location = new System.Drawing.Point(280, 105);
            this.epochBox.Name = "epochBox";
            this.epochBox.Size = new System.Drawing.Size(39, 20);
            this.epochBox.TabIndex = 11;
            this.epochBox.Text = "1000";
            // 
            // epoch
            // 
            this.epoch.AutoSize = true;
            this.epoch.Location = new System.Drawing.Point(180, 109);
            this.epoch.Name = "epoch";
            this.epoch.Size = new System.Drawing.Size(94, 13);
            this.epoch.TabIndex = 10;
            this.epoch.Text = "Number of Epochs";
            // 
            // minLrBox
            // 
            this.minLrBox.Location = new System.Drawing.Point(118, 79);
            this.minLrBox.Name = "minLrBox";
            this.minLrBox.Size = new System.Drawing.Size(43, 20);
            this.minLrBox.TabIndex = 9;
            this.minLrBox.Text = "0.01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "For ANN:";
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(9, 278);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(203, 23);
            this.TrainButton.TabIndex = 7;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.cmBox);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.testSSBox);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.testRFBox);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.testHLBox);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.percBox);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.testResultsBox);
            this.tabPage3.Controls.Add(this.testButton);
            this.tabPage3.Controls.Add(this.frBox);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.foldCVRadio);
            this.tabPage3.Controls.Add(this.randomCVRadio);
            this.tabPage3.Controls.Add(this.testNEBox);
            this.tabPage3.Controls.Add(this.testNOEBox);
            this.tabPage3.Controls.Add(this.testLRBox);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.kTestBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.testClassifierBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(883, 429);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test";
            // 
            // cmBox
            // 
            this.cmBox.Location = new System.Drawing.Point(408, 211);
            this.cmBox.Multiline = true;
            this.cmBox.Name = "cmBox";
            this.cmBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cmBox.Size = new System.Drawing.Size(450, 201);
            this.cmBox.TabIndex = 23;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(405, 195);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 13);
            this.label26.TabIndex = 22;
            this.label26.Text = "Confusion Matrix";
            // 
            // testSSBox
            // 
            this.testSSBox.Location = new System.Drawing.Point(318, 166);
            this.testSSBox.Name = "testSSBox";
            this.testSSBox.Size = new System.Drawing.Size(48, 20);
            this.testSSBox.TabIndex = 21;
            this.testSSBox.Text = "66";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(199, 169);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(122, 13);
            this.label25.TabIndex = 20;
            this.label25.Text = "Subset Percentage (RF)";
            // 
            // testRFBox
            // 
            this.testRFBox.Location = new System.Drawing.Point(140, 165);
            this.testRFBox.Name = "testRFBox";
            this.testRFBox.Size = new System.Drawing.Size(54, 20);
            this.testRFBox.TabIndex = 19;
            this.testRFBox.Text = "10";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(65, 169);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 13);
            this.label24.TabIndex = 18;
            this.label24.Text = "# Trees (RF)";
            // 
            // testHLBox
            // 
            this.testHLBox.Location = new System.Drawing.Point(140, 139);
            this.testHLBox.Name = "testHLBox";
            this.testHLBox.Size = new System.Drawing.Size(54, 20);
            this.testHLBox.TabIndex = 17;
            this.testHLBox.Text = "1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 143);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "# Hidden Layers (ANN)";
            // 
            // percBox
            // 
            this.percBox.Location = new System.Drawing.Point(318, 139);
            this.percBox.Name = "percBox";
            this.percBox.Size = new System.Drawing.Size(48, 20);
            this.percBox.TabIndex = 15;
            this.percBox.Text = "80";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(199, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Percentage (Bootstrap)";
            // 
            // testResultsBox
            // 
            this.testResultsBox.Location = new System.Drawing.Point(125, 213);
            this.testResultsBox.Multiline = true;
            this.testResultsBox.Name = "testResultsBox";
            this.testResultsBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.testResultsBox.Size = new System.Drawing.Size(241, 199);
            this.testResultsBox.TabIndex = 13;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(37, 211);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 12;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // frBox
            // 
            this.frBox.Location = new System.Drawing.Point(318, 113);
            this.frBox.Name = "frBox";
            this.frBox.Size = new System.Drawing.Size(48, 20);
            this.frBox.TabIndex = 11;
            this.frBox.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(219, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "#Fold/Repetitions";
            // 
            // foldCVRadio
            // 
            this.foldCVRadio.AutoSize = true;
            this.foldCVRadio.Location = new System.Drawing.Point(211, 55);
            this.foldCVRadio.Name = "foldCVRadio";
            this.foldCVRadio.Size = new System.Drawing.Size(61, 17);
            this.foldCVRadio.TabIndex = 9;
            this.foldCVRadio.TabStop = true;
            this.foldCVRadio.Text = "Fold CV";
            this.foldCVRadio.UseVisualStyleBackColor = true;
            // 
            // randomCVRadio
            // 
            this.randomCVRadio.AutoSize = true;
            this.randomCVRadio.Location = new System.Drawing.Point(211, 84);
            this.randomCVRadio.Name = "randomCVRadio";
            this.randomCVRadio.Size = new System.Drawing.Size(72, 17);
            this.randomCVRadio.TabIndex = 8;
            this.randomCVRadio.TabStop = true;
            this.randomCVRadio.Text = "Bootstrap";
            this.randomCVRadio.UseVisualStyleBackColor = true;
            // 
            // testNEBox
            // 
            this.testNEBox.Location = new System.Drawing.Point(140, 113);
            this.testNEBox.Name = "testNEBox";
            this.testNEBox.Size = new System.Drawing.Size(54, 20);
            this.testNEBox.TabIndex = 7;
            this.testNEBox.Text = "1000";
            // 
            // testNOEBox
            // 
            this.testNOEBox.AutoSize = true;
            this.testNOEBox.Location = new System.Drawing.Point(3, 116);
            this.testNOEBox.Name = "testNOEBox";
            this.testNOEBox.Size = new System.Drawing.Size(126, 13);
            this.testNOEBox.TabIndex = 6;
            this.testNOEBox.Text = "Number of Epochs (ANN)";
            // 
            // testLRBox
            // 
            this.testLRBox.Location = new System.Drawing.Point(140, 83);
            this.testLRBox.Name = "testLRBox";
            this.testLRBox.Size = new System.Drawing.Size(54, 20);
            this.testLRBox.TabIndex = 5;
            this.testLRBox.Text = "0.001";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Learning Rate (ANN)";
            // 
            // kTestBox
            // 
            this.kTestBox.Location = new System.Drawing.Point(140, 52);
            this.kTestBox.Name = "kTestBox";
            this.kTestBox.Size = new System.Drawing.Size(54, 20);
            this.kTestBox.TabIndex = 3;
            this.kTestBox.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "K (KNN) =";
            // 
            // testClassifierBox
            // 
            this.testClassifierBox.FormattingEnabled = true;
            this.testClassifierBox.Location = new System.Drawing.Point(140, 21);
            this.testClassifierBox.Name = "testClassifierBox";
            this.testClassifierBox.Size = new System.Drawing.Size(132, 21);
            this.testClassifierBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Test with the classifier";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 479);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "MLDM";
            ((System.ComponentModel.ISupportInitialize)(this.histchart1)).EndInit();
            this.panel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawbox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.ComboBox labelsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart histchart1;
        private System.Windows.Forms.TextBox kNNbox;
        private System.Windows.Forms.Button kNNButton;
        private System.Windows.Forms.Button hMMButton;
        private System.Windows.Forms.Button DTButton;
        private System.Windows.Forms.TabControl panel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.PictureBox drawbox2;
        private System.Windows.Forms.PictureBox drawbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.TextBox epochBox;
        private System.Windows.Forms.Label epoch;
        private System.Windows.Forms.ComboBox classifierBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minLrBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button serializer;
        private System.Windows.Forms.Button ANNButton;
        private System.Windows.Forms.Button SVMButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fontBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox testNEBox;
        private System.Windows.Forms.Label testNOEBox;
        private System.Windows.Forms.TextBox testLRBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox kTestBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox testClassifierBox;
        private System.Windows.Forms.RadioButton foldCVRadio;
        private System.Windows.Forms.RadioButton randomCVRadio;
        private System.Windows.Forms.TextBox testResultsBox;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox frBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox percBox;
        private System.Windows.Forms.TextBox efdTBox;
        private System.Windows.Forms.Button efdGenButton;
        private System.Windows.Forms.Button mvButton;
        private System.Windows.Forms.TextBox rfTreesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox rfPerBox;
        private System.Windows.Forms.Button RFButton;
        private System.Windows.Forms.TextBox stepSizeBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox maxLrBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox minHdLayerBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox maxHdLayerBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox maxRfTreeBox;
        private System.Windows.Forms.TextBox trateBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox testHLBox;
        private System.Windows.Forms.TextBox testRFBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox testSSBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button lrButton;
        private System.Windows.Forms.TextBox cmBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox resBox;

    }
}

