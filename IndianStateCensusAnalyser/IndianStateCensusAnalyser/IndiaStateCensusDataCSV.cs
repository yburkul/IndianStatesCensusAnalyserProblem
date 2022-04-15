using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class IndiaStateCensusDataCSV
    {
        string state;
        int population;
        int area;
        int density;
        int serialNumber;
        string stateName;
        int tin;
        string stateCode;
        public IndiaStateCensusDataCSV(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);  
            this.density = Convert.ToInt32(density);
        }
        public IndiaStateCensusDataCSV(IndianStateCodeDataCSV indianStateCodeDataCSV)
        {
            this.stateName = indianStateCodeDataCSV.stateName;
            this.serialNumber = indianStateCodeDataCSV.serialNumber;
            this.tin = indianStateCodeDataCSV.tin;
            this.stateCode = indianStateCodeDataCSV.stateCode;
        }
    }
}