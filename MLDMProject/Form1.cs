using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;


namespace MLDMProject
{
    public partial class Form1 : Form
    {
        int up = 0;
        int upRight = 45;
        int right = 90;
        int downRight = 135;
        int down = 180;
        int downLeft = -135;
        int left = -90;
        int upLeft = -45;
        int freemanInput = 8;
        int outputLabels = 10;

        public bool draw = false;
        Color color = Color.Black;
        int s = 10;
        
        Point point_orig = new Point();
        Point point_dest = new Point();
        
        Image mainimage;
        string dbPath;
        string temPath;
        string originPath;
        string dirPath = AppDomain.CurrentDomain.BaseDirectory;
        private DB db = new DB();
        private Initializer initializer = new Initializer();

        public Form1()
        {
            try
            {
                if (!dirPath.Contains("Debug"))
                    dirPath = Path.Combine(dirPath, @"bin\Debug\");

                mainimage = Image.FromFile(dirPath + "whiteboard.png");
                dbPath = Path.Combine(dirPath, "observation");
                temPath = Path.Combine(dirPath, "template");
                originPath = Path.Combine(dirPath, "originals");
                InitializeComponent();
                labelsList.Items.Add("--");
                for (int i = 0; i < 10; i++)
                    labelsList.Items.Add(i);
                labelsList.SelectedItem = labelsList.Items[0];
                classifierBox.Items.Add("-------------");
                classifierBox.Items.Add("ANN Classifer");
                classifierBox.Items.Add("DT Classifer");
                classifierBox.Items.Add("HMM Classifer");
                classifierBox.Items.Add("LR Classifer");
                classifierBox.Items.Add("RF Classifer");
                classifierBox.Items.Add("SVM Classifer");
                classifierBox.SelectedItem = classifierBox.Items[0];
                testClassifierBox.Items.Add("ANN Classifer");
                testClassifierBox.Items.Add("DT Classifer");
                testClassifierBox.Items.Add("HMM Classifer");
                testClassifierBox.Items.Add("KNN Classifer");
                testClassifierBox.Items.Add("LR Classifer");
                testClassifierBox.Items.Add("RF Classifer");
                testClassifierBox.Items.Add("SVM Classifer");
                testClassifierBox.SelectedItem = testClassifierBox.Items[0];
                try { db.deserialize(); }
                catch { db.serialize(); }
                try { initializer.deserialize(); }
                catch { initializer.serialize(); }
                Series series = this.histchart1.Series.First();
                for (int i = 0; i < 8; i++)
                    series.Points.AddXY(i, 0);
                series.Name = "Frequency";
                kNNbox.Text = "1";
                foldCVRadio.Checked = true;

                //StringBuilder buil = new StringBuilder();
                //for (int i = 0; i < db.allobservation.Count; i++)
                //{
                //    for (int j = 0; j < db.allobservation[i].efd.Length; j++)
                //        buil.Append(db.allobservation[i].efd[j] + ", ");
                //    buil.Append("\"" + db.allobservation[i].label + "\"\n");
                //}
                //File.WriteAllText("all.arff", buil.ToString());
            }
            catch { MessageBox.Show("An error occurred during initialization", "Error"); }
        }

        //Drawing functions
        private void drawbox_MouseDown(object sender, MouseEventArgs e)
        {
            Control c  = panel.Controls[0];
            draw = true;
            Graphics g = Graphics.FromImage(mainimage);
            point_orig.X = e.X;
            point_orig.Y = e.Y;
            g.Save();
            drawbox.Image = mainimage;
        }

        private void drawbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = Graphics.FromImage(mainimage);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.High;
                Brush brush = new SolidBrush(color);
                point_dest.X = e.X;
                point_dest.Y = e.Y;
                GraphicsPath path = new GraphicsPath();
                Pen pen1 = new Pen(brush, s);
                pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round; 
                g.DrawLine(pen1, point_orig, point_dest);
                g.Save();
                path.Dispose();
                drawbox.Image = mainimage;
                point_orig = point_dest;
            }
        }

        private void drawbox_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }


        //FreemanCode functions
        public bool[][] GetBitMapMatrix(string bitmapFilePath)
        {
            Bitmap b1 = new Bitmap(bitmapFilePath);

            int hight = b1.Height;
            int width = b1.Width;

            bool[][] colorMatrix = new bool[width][];
            for (int i = 0; i < width; i++)
            {
                colorMatrix[i] = new bool[hight];
                for (int j = 0; j < hight; j++)
                {
                    int argb = b1.GetPixel(i, j).R;
                    colorMatrix[i][j] = argb != 255 ? false : true;
                }
            }
            return colorMatrix;
        }

        public bool[][] GetContourImage(bool[][] originalImage)
        {
            bool[][] newImage = new bool[originalImage.GetLength(0)][];
            for (int i = 0; i < originalImage.GetLength(0); i++)
                newImage[i] = new bool[originalImage.GetLength(0)];

            for (int i = 0; i < originalImage.GetLength(0); i++)
                for (int j = 0; j < originalImage.GetLength(0); j++)
                {
                    if (originalImage[i][j])
                        newImage[i][j] = true;
                    else
                        newImage[i][j] = checkCell(originalImage, i, j);
                }
            return newImage;
        }

        public bool checkCell(bool[][] originalImage, int i, int j)
        {
            List<bool> list = new List<bool>();
            try
            {
                if (originalImage[i - 1][j - 1])
                    list.Add(originalImage[i - 1][j - 1]);
            }
            catch { }
            try
            {
                if (originalImage[i][j - 1])
                    list.Add(originalImage[i][j - 1]);
            }
            catch { }
            try
            {
                if (originalImage[i + 1][j - 1])
                    list.Add(originalImage[i + 1][j - 1]);
            }
            catch { }
            try
            {
                if (originalImage[i - 1][j])
                    list.Add(originalImage[i - 1][j]);
            }
            catch { }
            try
            {
                if (originalImage[i + 1][j])
                   list.Add(originalImage[i + 1][j]);
            }
            catch { }
            try
            {
                if (originalImage[i - 1][j + 1])
                    list.Add(originalImage[i - 1][j + 1]);
            }
            catch { }
            try
            {
                if (originalImage[i][j + 1])
                    list.Add(originalImage[i][j + 1]);
            }
            catch { }
            try
            {
                if (originalImage[i + 1][j + 1])
                    list.Add(originalImage[i + 1][j + 1]);
            }
            catch { }
            bool result = false;
            foreach (bool b in list)
                result = result || b;
            if (!result)
                return true;
            else
                return originalImage[i][j];
        }

        public string freemanChainCode(bool[][] image)
        {
            int startingPointI = 0;
            int startingPointJ = 0;
            bool flag = false;
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(0); j++)
                    if (image[j][i])
                        continue;
                    else
                    {
                        flag = true;
                        startingPointJ = j;
                        startingPointI = i;
                        break;
                    }
                if (flag)
                    break;
            }
            string freemancode = getFreemanCode(image, startingPointI, startingPointJ);
            return freemancode;
        }

        public string  getFreemanCode(bool[][] image, int j, int i)
        {
            FreemanPoint tempPoint = new FreemanPoint(FreemanPoint.freeman.nill, -1, -1, 90);
            string result = "";
            image[i][j] = true;
            if (tempPoint.point == FreemanPoint.freeman.nill)
            {
                List<FreemanPoint> points = new List<FreemanPoint>();
                try { if (!image[i - 1][j - 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.upLeft, i-1, j-1, upLeft)); }catch { }
                try { if (!image[i][j - 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.up, i, j-1, up)); } catch { }
                try { if (!image[i + 1][j - 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.upRight, i+1, j-1, upRight)); }catch { }
                try { if (!image[i - 1][j]) points.Add(new FreemanPoint(FreemanPoint.freeman.left, i-1, j, left)); } catch { }
                try { if (!image[i + 1][j]) points.Add(new FreemanPoint(FreemanPoint.freeman.right, i+1, j, right)); } catch { }
                try { if (!image[i - 1][j + 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.downLeft, i-1, j+1, downLeft)); } catch { }
                try { if (!image[i][j + 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.down, i, j+1, down)); } catch { }
                try { if (!image[i + 1][j + 1]) points.Add(new FreemanPoint(FreemanPoint.freeman.downRight, i+1, j+1, downRight)); } catch { }
                int maxAngle = 200;
                int myangle = tempPoint.angle;
                foreach (FreemanPoint f in points)
                {
                    int temp = Math.Abs(myangle - f.angle);
                    if (temp < maxAngle)
                    {
                        tempPoint.point = f.point;
                        tempPoint.pointI = f.pointI;
                        tempPoint.pointJ = f.pointJ;
                        tempPoint.angle = f.angle;
                        maxAngle = temp;
                    }
                }
                result += (int)tempPoint.point;
            }
            while (tempPoint.pointI != i || tempPoint.pointJ != j)
            {
                List<FreemanPoint> points = new List<FreemanPoint>();
                try { if (!image[tempPoint.pointI - 1][tempPoint.pointJ - 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.upLeft, tempPoint.pointI-1, tempPoint.pointJ-1, upLeft)); }catch { }
                try { if (!image[tempPoint.pointI][tempPoint.pointJ - 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.up, tempPoint.pointI, tempPoint.pointJ-1, up)); } catch { }
                try { if (!image[tempPoint.pointI + 1][tempPoint.pointJ - 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.upRight, tempPoint.pointI+1, tempPoint.pointJ-1, upRight)); }catch { }
                try { if (!image[tempPoint.pointI - 1][tempPoint.pointJ]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.left, tempPoint.pointI-1, tempPoint.pointJ, left)); } catch { }
                try { if (!image[tempPoint.pointI + 1][tempPoint.pointJ]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.right, tempPoint.pointI+1, tempPoint.pointJ, right)); } catch { }
                try { if (!image[tempPoint.pointI - 1][tempPoint.pointJ + 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.downLeft, tempPoint.pointI-1, tempPoint.pointJ+1, downLeft)); } catch { }
                try { if (!image[tempPoint.pointI][tempPoint.pointJ + 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.down, tempPoint.pointI, tempPoint.pointJ+1, down)); } catch { }
                try { if (!image[tempPoint.pointI + 1][tempPoint.pointJ + 1]) 
                    points.Add(new FreemanPoint(FreemanPoint.freeman.downRight, tempPoint.pointI+1, tempPoint.pointJ+1, downRight)); } catch { }
                int maxAngle = 200;
                int myangle = tempPoint.angle;
                if (points.Count == 0)
                    break;
                image[tempPoint.pointI][tempPoint.pointJ] = true;
                foreach (FreemanPoint f in points)
                {
                    int temp = Math.Abs(myangle - f.angle);
                    if (temp > 180)
                        temp = Math.Abs(temp - 360);
                    if (temp < maxAngle)
                    {
                        tempPoint.point = f.point;
                        tempPoint.pointI = f.pointI;
                        tempPoint.pointJ = f.pointJ;
                        tempPoint.angle = f.angle;
                        maxAngle = temp;
                    }
                }
                result += (int)tempPoint.point;
            }
            return result;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        //GUI functions
        private void saveButton_Click(object sender, EventArgs e)
        {
            Observation newObsrv = new Observation();
            Image imageToSave = ResizeImage(drawbox.Image, 100, 100);
            string label = labelsList.SelectedItem.ToString();
            if (label == "--")
            {
                MessageBox.Show("Please choose a correct label", "Error");
                return;
            }
            newObsrv.label = label;
            int count = ++(initializer.labels[label]);
            string newName = originPath + @"\" + label + "_" + count + ".png";
            newObsrv.imagePath = newName;
            imageToSave.Save(newName);

            //Contour and Elliptic Fourier Desciptor
            bool[][] image1 = GetBitMapMatrix(newName);
            bool[][] image2 = GetContourImage(image1);
            int contourCount = 0;
            for (int i = 0; i < image2.Length; i++)
                contourCount += image2[i].Count(s => !s);
            double[] xContour = new double[contourCount];
            double[] yContour = new double[contourCount];
            contourCount = 0;
            Bitmap bitmap = new Bitmap(100, 100);
            for (int i = 0; i < image2.Length; i++)
                for (int j = 0; j < image2.Length; j++)
                    if (image2[i][j])
                        bitmap.SetPixel(i, j, Color.White);
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                        xContour[contourCount] = i;
                        yContour[contourCount++] = j;
                    }
            newObsrv.xContour = xContour;
            newObsrv.yContour = yContour;
            Utility.GenerateEFD(newObsrv, initializer.numbEFD);   //4 should be a parameter

            //Images Data
            newName = dbPath + @"\" + label + "_" + count + ".png";
            bitmap.Save(newName);
            string freemanCode = freemanChainCode(image2);
            textBox.Text = freemanCode;
            newObsrv.contourPath = newName;
            newObsrv.freemanCode = freemanCode;

            //Update Bag of words
            newObsrv.calculHistogram();
            newObsrv.calculWTAHist();
            initializer.maxFrequency = freemanCode.Length > initializer.maxFrequency ? freemanCode.Length : initializer.maxFrequency;
            db.allobservation.Add(newObsrv);
            Utility.UpdateNormHistogram(db.allobservation, initializer.maxFrequency);

            //Serialization
            db.serialize();
            initializer.serialize();

            //GUI
            drawbox2.Image = bitmap;
            this.histchart1.Series.Clear();
            this.histchart1.Series.Add(new Series());
            Series series = this.histchart1.Series.First();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, newObsrv.freemanHist[i]);
            this.histchart1.Series[0] = series;
            MessageBox.Show("Saved succesfully", "Message");
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            mainimage = Image.FromFile(dirPath + "whiteboard.png");
            drawbox.Image = mainimage;
            drawbox2.Image = mainimage;
            textBox.Text = "";
            this.histchart1.Series.First().Points.Clear();
            for (int i = 0; i < 8; i++)
                this.histchart1.Series.First().Points.AddXY(i, 0);
            this.histchart1.Series.First().Name = "Frequency";
        }


        //Classifier functions (GUI)
        private void kNNButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            KNNClassifier classifier = new KNNClassifier(byte.Parse(kNNbox.Text));
            string res = classifier.k_NN(test.freemanCode, db.allobservation);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void hMMButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.hmmClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void DTButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.dtClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void SVMButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.svmClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void ANNButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.annClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            string chosedClassifer = classifierBox.SelectedItem.ToString();
            int efdNumb = initializer.numbEFD * 4 - 2;
            resBox.Text = "";
            if (chosedClassifer.Equals("-------------"))
            {
                MessageBox.Show("Please choose a classifier", "Warning Message");
                return;
            }
            if (chosedClassifer.Equals("HMM Classifer"))
            {
                double trate = double.Parse(trateBox.Text);
                HMMClassifier hmmClassifier = new HMMClassifier(freemanInput, outputLabels, trate);
                hmmClassifier.Train(db.allobservation);
                db.hmmClassifier = hmmClassifier;
                resBox.Text = "Error: " + db.hmmClassifier.error.ToString();
            }
            if (chosedClassifer.Equals("DT Classifer"))
            {
                DTClassifier dtClassifier = new DTClassifier(efdNumb, outputLabels);
                dtClassifier.Train(db.allobservation);
                db.dtClassifier = dtClassifier;
                resBox.Text = "Error: " + db.dtClassifier.error.ToString();
            }
            if (chosedClassifer.Equals("LR Classifer"))
            {
                LogisticRegressionClassifier lrClassifier = new LogisticRegressionClassifier(efdNumb, outputLabels);
                lrClassifier.Train(db.allobservation);
                db.lrClassifier = lrClassifier;
                resBox.Text = "Error: " + db.lrClassifier.error.ToString();
            }
            if (chosedClassifer.Equals("SVM Classifer"))
            {
                SVMClassifier svmClassifier = new SVMClassifier(efdNumb, outputLabels);
                svmClassifier.Train(db.allobservation);
                db.svmClassifier = svmClassifier;
                resBox.Text = "Error: " + db.svmClassifier.error.ToString();
            }
            if (chosedClassifer.Equals("ANN Classifer"))
            {
                double lrate = double.Parse(minLrBox.Text);
                double maxlrate = double.Parse(maxLrBox.Text);
                int minHDLayer = int.Parse(minHdLayerBox.Text);
                int maxHDLayer = int.Parse(maxHdLayerBox.Text);
                double stepSize = double.Parse(stepSizeBox.Text);
                int epochs = int.Parse(epochBox.Text);
                double error = double.MaxValue;
                ANNClassifier annClassifier = null;
                for (double i = lrate; i <= maxlrate; i = i + stepSize)
                {
                    for (int j = minHDLayer; j <= maxHDLayer; j++)
                    {
                        annClassifier = new ANNClassifier(efdNumb, j, outputLabels, i, epochs);
                        annClassifier.Train(db.allobservation);
                        if (annClassifier.network.MeanSquaredError < error)
                        {
                            db.annClassifier = annClassifier;
                            error = annClassifier.network.MeanSquaredError;
                        }
                    }
                }
                resBox.Text = "Number of Hidden Layers: " + db.annClassifier.hidden + Environment.NewLine;
                resBox.Text += "Learning Rate: " + db.annClassifier.learningRate + Environment.NewLine;
                resBox.Text += "Error: " + db.annClassifier.network.MeanSquaredError;
            }
            if (chosedClassifer.Equals("RF Classifer"))
            {
                int minNumbOfTrees = int.Parse(rfTreesBox.Text);
                int maxNumbOfTrees = int.Parse(maxRfTreeBox.Text);
                RFClassifier rfClassifier = null;
                double error = double.MaxValue;
                for (int i = minNumbOfTrees; i <= maxNumbOfTrees; i++)
                {
                    rfClassifier = new RFClassifier(efdNumb, outputLabels, i);
                    double rfPer = double.Parse(rfPerBox.Text);
                    rfClassifier.Train(db.allobservation, rfPer);
                    if (rfClassifier.error < error)
                    {
                        db.rfClassifier = rfClassifier;
                        error = rfClassifier.error;
                    }
                }
                resBox.Text = "Number of Trees: " + db.rfClassifier.numbOfTrees + Environment.NewLine;
                resBox.Text += "Error: " + db.rfClassifier.error;
            }
            db.serialize();
            GC.Collect();
            MessageBox.Show("Trained succesfully", "Message");
        }

        private void serializer_Click(object sender, EventArgs e)
        {
            db.serialize();
            MessageBox.Show("Saved succesfully", "Message");
        }

        private Observation ProcessNewImage()
        {
            Observation newObsrv = new Observation();
            Image imageToSave = ResizeImage(drawbox.Image, 100, 100);
            string newName = Path.Combine(Environment.CurrentDirectory, "test.png");
            newObsrv.imagePath = newName;
            imageToSave.Save(newName);

            //Contour and Elliptic Fourier Desciptor
            bool[][] image1 = GetBitMapMatrix(newName);
            bool[][] image2 = GetContourImage(image1);
            int contourCount = 0;
            for (int i = 0; i < image2.Length; i++)
                contourCount += image2[i].Count(s => !s);
            double[] xContour = new double[contourCount];
            double[] yContour = new double[contourCount];
            contourCount = 0;
            Bitmap bitmap = new Bitmap(100, 100);
            for (int i = 0; i < image2.Length; i++)
                for (int j = 0; j < image2.Length; j++)
                    if (image2[i][j])
                        bitmap.SetPixel(i, j, Color.White);
                    else
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                        xContour[contourCount] = i;
                        yContour[contourCount++] = j;
                    }
            newObsrv.xContour = xContour;
            newObsrv.yContour = yContour;
            Utility.GenerateEFD(newObsrv, initializer.numbEFD);   //4 should be a parameter

            //Images Data
            newName = Path.Combine(Environment.CurrentDirectory, "testContour.png");
            bitmap.Save(newName);
            string freemanCode = freemanChainCode(image2);
            textBox.Text = freemanCode;
            newObsrv.contourPath = newName;
            newObsrv.freemanCode = freemanCode;

            //Update Bag of words
            newObsrv.calculHistogram();
            newObsrv.calculWTAHist();
            return newObsrv;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (fontBox.Text.Length == 0 || fontBox.Text == "")
            {
                fontBox.Text = "10";
                this.s = 10;
                return;
            }
            this.s = int.Parse(fontBox.Text);
            this.s = this.s > 20 ? 20 : this.s;
            this.s = this.s < 5 ? 5 : this.s;
            GC.Collect();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            int nOFEfd = db.allobservation.First().efd.Length;
            testResultsBox.Text = "";
            cmBox.Text = "";
            cmBox.Refresh();
            testResultsBox.Refresh();
            int fold_repetitions = int.Parse(frBox.Text);
            double percentage = double.Parse(percBox.Text);
            if (testClassifierBox.Text.Equals("KNN Classifer"))
            {
                byte k = byte.Parse(kTestBox.Text);
                KNNClassifier classifier = new KNNClassifier(k);
                if (randomCVRadio.Checked)
                {
                    string text = classifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = classifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = classifier.ToString();
            }
            if (testClassifierBox.Text.Equals("ANN Classifer"))
            {
                int testNEpochs = int.Parse(testNEBox.Text);
                double lrate = double.Parse(testLRBox.Text);
                int nHL = int.Parse(testHLBox.Text);
                ANNClassifier annClassifier = new ANNClassifier(nOFEfd, nHL, outputLabels, lrate, testNEpochs);
                if (randomCVRadio.Checked)
                {
                    string text = annClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = annClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = annClassifier.ToString();
            }
            if (testClassifierBox.Text.Equals("HMM Classifer"))
            {
                HMMClassifier hmmClassifier = new HMMClassifier(freemanInput, outputLabels);
                if (randomCVRadio.Checked)
                {
                    string text = hmmClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = hmmClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = hmmClassifier.ToString();
            }
            if (testClassifierBox.Text.Equals("DT Classifer"))
            {
                DTClassifier dtClassifier = new DTClassifier(nOFEfd, outputLabels);
                if (randomCVRadio.Checked)
                {
                    string text = dtClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = dtClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = dtClassifier.ToString();
            }
            if (testClassifierBox.Text.Equals("LR Classifer"))
            {
                LogisticRegressionClassifier lrClassifier = new LogisticRegressionClassifier(nOFEfd, outputLabels);
                if (randomCVRadio.Checked)
                {
                    string text = lrClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = lrClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = lrClassifier.ToString();
            }
            if (testClassifierBox.Text.Equals("SVM Classifer"))
            {
                SVMClassifier svmClassifier = new SVMClassifier(nOFEfd, outputLabels);
                if (randomCVRadio.Checked)
                {
                    string text = svmClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = svmClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions);
                    testResultsBox.Text = text;
                }
                cmBox.Text = svmClassifier.ToString();
            }
            if (testClassifierBox.Text.Equals("RF Classifer"))
            {
                int nTrees = int.Parse(testRFBox.Text);
                double ssPer = double.Parse(testSSBox.Text);
                RFClassifier rfClassifier = new RFClassifier(nOFEfd, outputLabels, nTrees);
                if (randomCVRadio.Checked)
                {
                    string text = rfClassifier.RandomCrossValidation(fold_repetitions, db.allobservation, percentage, ssPer);
                    testResultsBox.Text = text;
                }
                else
                {
                    string text = rfClassifier.KFoldCrossValidation(db.allobservation, fold_repetitions, ssPer);
                    testResultsBox.Text = text;
                }
                cmBox.Text = rfClassifier.ToString();
            }
        }

        private void efdGenButton_Click(object sender, EventArgs e)
        {
            initializer.numbEFD = int.Parse(efdTBox.Text);
            Utility.EFDGenerator(db.allobservation, initializer.numbEFD);
            initializer.serialize();
            db.serialize();
            MessageBox.Show("EFD generated successfully", "Message");
        }

        private void mvButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            Dictionary<string, int> result = new Dictionary<string, int>();
            textBox.Text = test.freemanCode;
            string res = db.dtClassifier.Classify(test);
            result.Add(res, 1);
            res = db.hmmClassifier.Classify(test);
            if (result.ContainsKey(res))
                result[res]++;
            else
                result.Add(res, 1);
            res = db.svmClassifier.Classify(test);
            if (result.ContainsKey(res))
                result[res]++;
            else
                result.Add(res, 1);
            res = db.annClassifier.Classify(test);
            if (result.ContainsKey(res))
                result[res]++;
            else
                result.Add(res, 1);
            res = db.lrClassifier.Classify(test);
            if (result.ContainsKey(res))
                result[res]++;
            else
                result.Add(res, 1);
            KNNClassifier classifier = new KNNClassifier(byte.Parse(kNNbox.Text));
            res = classifier.k_NN(test.freemanCode, db.allobservation);
            if (result.ContainsKey(res))
                result[res]++;
            else
                result.Add(res, 1);
            result = result.OrderByDescending(s => s.Value).ToDictionary(s => s.Key, s=> s.Value);
            res = result.First().Key;
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void RFButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.rfClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }

        private void lrButton_Click(object sender, EventArgs e)
        {
            Observation test = ProcessNewImage();
            textBox.Text = test.freemanCode;
            string res = db.lrClassifier.Classify(test);
            string templatePath = temPath + @"\" + res + ".jpg";
            Image mainimage = Image.FromFile(templatePath);
            drawbox2.Image = mainimage;
            Series series = this.histchart1.Series.First();
            series.Points.Clear();
            for (int i = 0; i < 8; i++)
                series.Points.AddXY(i, test.freemanHist[i]);
            GC.Collect();
        }
    }
}
