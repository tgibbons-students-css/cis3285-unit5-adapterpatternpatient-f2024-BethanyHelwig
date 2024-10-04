using System;
using System.ComponentModel;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public class OutNetworkAdapter : InsuranceInterface
    {
        OutNetworkPatient patient;
        public OutNetworkAdapter(string newName, int newPolicyNumber) 
        {
            patient = new OutNetworkPatient(newName, newPolicyNumber);
        }

        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal coveragePercent = patient.CoveragePercent(ProcedureCost);
            return ProcedureCost * coveragePercent;
        }

        public string getPatientName()
        {
            return patient.getPatientName();
        }

        public string getPolicyNumber()
        {
            return patient.PolicyNumber.ToString();
        }

        public bool IsCovered(string patientName, string policyNumber)
        {
            int policyInt = Convert.ToInt32(policyNumber);
            string covered = patient.IsCovered(patientName, policyInt);
            //bool isCovered = (covered == "yes") ? true : false;
            return (covered == "yes");
        }
    }
}
