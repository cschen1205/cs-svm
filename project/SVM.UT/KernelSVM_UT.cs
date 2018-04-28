using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lang;
using System.Xml;
using SimuKit.Math.Distribution;
using Util;

namespace SVM.UT
{
    public class KernelSVM_UT
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

                    //index must start at 1
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

        public static void Run_Classify()
        {
            List<CDataRecord> records = LoadSample();

            DataTransformer<CDataRecord> dt = new DataTransformer<CDataRecord>();
            dt.DoFeaturesScaling(records);

            KernelSVM<CDataRecord> algorithm = new KernelSVM<CDataRecord>();
            algorithm.C = 20; 
            ((GaussianKernel)algorithm.Kernel).Sigma = 0.01; 

            algorithm.Train(records);

            Console.WriteLine("SVM(Gaussian Kernel) Model Built!");

            for (int i = 0; i < records.Count; i++)
            {
                CDataRecord rec = records[i] as CDataRecord;
                Console.WriteLine("rec: ");
                for (int j = 0; j < rec.Dimension; ++j)
                {
                    Console.WriteLine("X[" +j+"] = "+ "[" + rec[j] + "] ");
                }
                Console.WriteLine("Label: " + "[" + rec.Label + "] ");
                Console.WriteLine("Predicted Label: " + algorithm.Predict(records[i]));
            }
        }

        

        public static void Run_Rank()
        {
            List<CDataRecord> records = LoadSample();

            DataTransformer<CDataRecord> dt = new DataTransformer<CDataRecord>();
            dt.DoFeaturesScaling(records);

            KernelSVM<CDataRecord> algorithm = new KernelSVM<CDataRecord>();
            algorithm.C = 20; //large value, high bias
            ((GaussianKernel)algorithm.Kernel).Sigma = 0.01; //low value, high bias

            algorithm.Train(records);

            Console.WriteLine("SVM (Gaussian Kernel) Model Built!");

            for (int i = 0; i < records.Count; i++)
            {
                CDataRecord rec = records[i] as CDataRecord;
                Console.WriteLine("rec: ");
                for (int j = 0; j < rec.Dimension; ++j)
                {
                    Console.WriteLine("X["+j + " = " + rec[j] + "]");
                }
                Console.WriteLine("Label: " + rec.Label);

                List<KeyValuePair<string, double>> ranks = algorithm.Rank(records, rec);
                for (int k = 0; k < ranks.Count; ++k)
                {
                    Console.WriteLine("{0}: score = {1}", ranks[k].Key, ranks[k].Value);
                }
            }
        }
    }
}
