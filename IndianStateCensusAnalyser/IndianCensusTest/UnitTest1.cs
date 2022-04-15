using IndianStateCensusAnalyser;
using NUnit.Framework;
using System;

namespace IndianCensusTest
{
    public class Tests
    {
        string folderPath = @"D:\Bridglabz\IndianStatesCensusAnalyserProblem\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFile\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        string validCensusFileStateCode = "IndiaStateCode.csv";
        string invalidExtensionFileStateCode = "IndiaStateCode.txt";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCode.csv";
        string invalidHeaderstateCode = "WrongIndiaStateCode.csv";
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
        /// <summary>
        /// TC2.1- Check to ensure the Number of Record matches or not
        /// </summary>
        [Test]
        public void Given_CSVCodeFile_TestRecordAreSame()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC 2.2 - Check Given CSV code File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVCodeFileName_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode + "txt", "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusException.ExceptionType.FILE_NOT_EXIST, exception.type);
        }
        /// <summary>
        /// TC 2.3 - Check Given Code File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectCodeFileType_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusException.ExceptionType.IMPROPER_EXTENSION, exception.type);
        }
        /// <summary>
        /// TC2.4- Check the Proper delimeter is used or not
        /// </summary> 
        [Test]
        public void GivenCodeFile_IncorrectDelimiter_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusException.ExceptionType.DELIMITER_NOT_FOUND, exception.type);
        }
        /// <summary>
        /// TC2.5- Check in CSV Code file the Header is correct or not
        /// </summary>
        [Test]
        public void GivenCodeFile_IncorrectHeader_ReturnCustomException()
        {
            CensusException exception = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderstateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusException.ExceptionType.INCORRECT_HEADER, exception.type);
        }
    }
}