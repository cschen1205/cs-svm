using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;
using System.Xml;
using SimuKit.Math.Distribution;
using SimuKit.ML.Util;

namespace SimuKit.ML.SVM.UT
{
    public class LinearSVM_UT
    {
        public static List<CDataRecord> LoadSample()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("database.xml");

            List<CDataRecord> records = new List<CDataRecord>();

            XmlElement xml_root = doc.DocumentElement;
            foreach (XmlElement xml_level1 in xml_root.ChildNodes)
            {
                if (xml_level1.Name == "record")
                {
                    string outlook_text = xml_level1.Attributes["outlook"].Value;

                    double outlook = DistributionModel.GetUniform() * 0.333;
                    if (outlook_text == "Overcast")
                    {
                        outlook = 0.333 + DistributionModel.GetUniform() * 0.333;
                    }
                    else if (outlook_text == "Rain")
                    {
                        outlook = 0.666 + DistributionModel.GetUniform() * 0.333;
                    }

                    double temperature = double.Parse(xml_level1.Attributes["temperature"].Value);
                    double humidity = double.Parse(xml_level1.Attributes["humidity"].Value);
                    string windy_text = xml_level1.Attributes["windy"].Value;
                    double windy = windy_text == "true" ? 1 : 0;

                    String class_label = xml_level1.Attributes["class"].Value;
                    CDataRecord rec = new CDataRecord(4);

                    rec[1] = outlook;
                    rec[2] = windy;
                    
                    rec[3] = temperature;
                    rec[4] = humidity;

                    rec.Label = class_label;

                    records.Add(rec);
                }
            }
            return records;
        }

        public static void Run_Classify2()
        {
            List<MLDataPoint> X_points = MLDataPointUtil.LoadDataSet("X1.txt");
            List<List<int>> y_points = IntDataTableUtil.LoadDataSet("y1.txt");

            List<CDataRecord> X = new List<CDataRecord>();
            for (int i = 0; i < X_points.Count; ++i)
            {
                CDataRecord X_i = new CDataRecord(X_points[i].Dimension);
                for (int j = 0; j < X_points[i].Dimension; ++j)
                {
                    X_i[i + 1] = X_points[i][j]; //X_i index must start at 1
                }
                X_i.Label = y_points[i][0].ToString();
                X.Add(X_i);
            }

            LinearSVM<CDataRecord> algorithm = new LinearSVM<CDataRecord>();
            algorithm.C = 100;

            algorithm.Train(X);
        }

        public static void Run_Classify()
        {
            List<CDataRecord> records = LoadSample();

            DataTransformer<CDataRecord> dt = new DataTransformer<CDataRecord>();
            dt.DoFeaturesScaling(records);

            LinearSVM<CDataRecord> algorithm = new LinearSVM<CDataRecord>();
            algorithm.C = 20;

            algorithm.Train(records);

            Console.WriteLine("SVM (Linear Kernel) Model Built!");

            for (int i = 0; i < records.Count; i++)
            {
                CDataRecord rec = records[i] as CDataRecord;
                Console.WriteLine("rec: ");
                for (int j = 0; j < rec.Dimension; ++j)
                {
                    Console.WriteLine("X["+j+"] = " + rec[j] + "");
                }
                Console.WriteLine("Label: " + rec.Label + "");
                Console.WriteLine("Predicted Label: " + algorithm.Predict(records[i]));
            }
        }

        public static void Run_Rank()
        {
            List<CDataRecord> records = LoadSample();

            DataTransformer<CDataRecord> dt = new DataTransformer<CDataRecord>();
            dt.DoFeaturesScaling(records);

            LinearSVM<CDataRecord> algorithm = new LinearSVM<CDataRecord>();
            algorithm.C = 20;

            algorithm.Train(records);

            Console.WriteLine("SVM (Linear Kernel) Model Built!");

            for (int i = 0; i < records.Count; i++)
            {
                CDataRecord rec = records[i] as CDataRecord;
                Console.WriteLine("rec: ");
                for (int j = 0; j < rec.Dimension; ++j)
                {
                    Console.WriteLine("X[" + j + "] = " + rec[j]);
                }
                Console.WriteLine("Label: " + rec.Label);

                List<KeyValuePair<string, double>> ranks = algorithm.Rank(rec);
                for (int k = 0; k < ranks.Count; ++k)
                {
                    Console.WriteLine("{0}: score = {1}", ranks[k].Key, ranks[k].Value);
                }
            }
        }
    }
}
