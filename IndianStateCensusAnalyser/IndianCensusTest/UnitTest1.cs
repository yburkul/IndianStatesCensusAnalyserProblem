using IndianStateCensusAnalyser;
using NUnit.Framework;
using System;

namespace IndianCensusTest
{
    public class Tests
    {
        string folderPath = @"D:\Bridglabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFile\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        /// <summary>
        /// TC 1.1 - Check to ensure the Number of Record matches or not
        /// </summary>
        [Test]
        public void Given_CSVFile_TestRecordAreSame()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC1.2- Check Given File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "Txt", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.FILE_NOT_EXIST, exception.type);
        }
        /// <summary>
        /// TC1.3- Check given File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectFileType_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.IMPROPER_EXTENSION, exception.type);
        }
        /// <summary>
        /// TC1.4- Check the Proper delimeter is used or not
        /// </summary> 
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.DELIMITER_NOT_FOUND, exception.type);
        }
        /// <summary>
        /// TC1.5- Check in CSV file the Header is correct or not
        /// </summary>
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusException.ExceptionType.INCORRECT_HEADER, exception.type);
        }
    }
}