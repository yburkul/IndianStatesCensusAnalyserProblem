using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        public Dictionary<string, IndiaStateCensusDataCSV> datamap;
        public Dictionary<string, IndiaStateCensusDataCSV> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, IndiaStateCensusDataCSV>();

            if (!File.Exists(csvFilePath))
            {
                throw new CensusException(CensusException.ExceptionType.FILE_NOT_EXIST, "File does not exist");
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusException(CensusException.ExceptionType.IMPROPER_EXTENSION, "Improper extension");
            }

            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusException(CensusException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }

            foreach (string row in censusData.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CensusException(CensusException.ExceptionType.DELIMITER_NOT_FOUND, "Delimiter is not found");
                }
                string[] column = row.Split(',');
                if (csvFilePath.Contains("IndiaStateCode"))
                    datamap.Add(column[0], new IndiaStateCensusDataCSV(new IndianStateCodeDataCSV(column[0], column[1], column[2], column[3])));
                else
                    datamap.Add(column[0], new IndiaStateCensusDataCSV(column[0], column[1], column[2], column[3]));
            }
            return datamap;
        }
    }
}