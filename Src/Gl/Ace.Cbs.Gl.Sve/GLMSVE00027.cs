using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Gl.Ctr.Sve;
using System.Data;
using System.ComponentModel;


//using Ace.Cbs.Cx.Com.Utt;
//using Ace.Windows.CXClient;
namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00027 : BaseService, IGLMSVE00027
    {
        #region Properties

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }
        private IGLMDAO00023 monthlyccoaDAO;
        public IGLMDAO00023 MonthlyccoaDAO
        {
            get { return this.monthlyccoaDAO; }
            set { this.monthlyccoaDAO = value; }
        }
        IList<GLMDTO00023> PrintDataList1 { get; set; }
        IList<GLMDTO00023> PrintDataList2 { get; set; }

        #endregion

        #region Main Method

        public DataSet SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport(DateTime requiredDate, string sourceBranchCode, string isIncome,string workStation)
        {
            DataSet ds = new DataSet();
            string namepost = "Monthly_Posting";
            if (sourceBranchCode != "All")
            {
                PFMDTO00056 sys001Data = sys001DAO.SelectAllByName(namepost, sourceBranchCode);
                if (Convert.ToDateTime(sys001Data.SysDate.ToString()).Month == requiredDate.Month && Convert.ToDateTime(sys001Data.SysDate.ToString()).Year == requiredDate.Year)
                {
                    if (isIncome == "1")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        DataTable dt = new DataTable();
                        // Convert to DataTable.
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        //dt = (DataTable)PrintDataList1;
                        ds.Tables.Add(dt);
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        ds.Tables.Add(dt);
                    }
                    else if (isIncome == "0")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        DataTable dt = new DataTable();
                        // Convert to DataTable.
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        //dt = (DataTable)PrintDataList1;
                        ds.Tables.Add(dt);
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = false;
                }
            }
            else
            {
                if (isIncome == "1")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        DataTable dt = new DataTable();
                        // Convert to DataTable.
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        //dt = (DataTable)PrintDataList1;
                        ds.Tables.Add(dt);
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        ds.Tables.Add(dt);
                    }
                    else if (isIncome == "0")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        DataTable dt = new DataTable();
                        // Convert to DataTable.
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        //dt = (DataTable)PrintDataList1;
                        ds.Tables.Add(dt);
                        dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        ds.Tables.Add(dt);
                    }
            }
                return ds;
        }

        public IList<GLMDTO00023> SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport1(DateTime requiredDate, string sourceBranchCode, string isIncome, string workStation)
        {
            DataSet ds = new DataSet();
            string namepost = "Monthly_Posting";
            if (sourceBranchCode != "All")
            {
                PFMDTO00056 sys001Data = sys001DAO.SelectAllByName(namepost, sourceBranchCode);
                if (Convert.ToDateTime(sys001Data.SysDate.ToString()).Month == requiredDate.Month && Convert.ToDateTime(sys001Data.SysDate.ToString()).Year == requiredDate.Year)
                {
                    if (isIncome == "1")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //DataTable dt = new DataTable();
                        //// Convert to DataTable.
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        ////dt = (DataTable)PrintDataList1;
                        //ds.Tables.Add(dt);
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        //ds.Tables.Add(dt);
                    }
                    else if (isIncome == "0")
                    {
                        PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //DataTable dt = new DataTable();
                        //// Convert to DataTable.
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        ////dt = (DataTable)PrintDataList1;
                        //ds.Tables.Add(dt);
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        //ds.Tables.Add(dt);
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = false;
                }
            }
            else
            {
                if (isIncome == "1")
                {
                    PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //DataTable dt = new DataTable();
                    //// Convert to DataTable.
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                    ////dt = (DataTable)PrintDataList1;
                    //ds.Tables.Add(dt);
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                    //ds.Tables.Add(dt);
                }
                else if (isIncome == "0")
                {
                    PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //DataTable dt = new DataTable();
                    //// Convert to DataTable.
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                    ////dt = (DataTable)PrintDataList1;
                    //ds.Tables.Add(dt);
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                    //ds.Tables.Add(dt);
                }
            }
            return PrintDataList1;
        }
        public IList<GLMDTO00023> SelectMonthlyCOAForIncomeExpenditureAndGeneralReturnsReport2(DateTime requiredDate, string sourceBranchCode, string isIncome, string workStation)
        {
            DataSet ds = new DataSet();
            string namepost = "Monthly_Posting";
            if (sourceBranchCode != "All")
            {
                PFMDTO00056 sys001Data = sys001DAO.SelectAllByName(namepost, sourceBranchCode);
                if (Convert.ToDateTime(sys001Data.SysDate.ToString()).Month == requiredDate.Month && Convert.ToDateTime(sys001Data.SysDate.ToString()).Year == requiredDate.Year)
                {
                    if (isIncome == "1")
                    {
                        //PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //DataTable dt = new DataTable();
                        //// Convert to DataTable.
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        ////dt = (DataTable)PrintDataList1;
                        //ds.Tables.Add(dt);
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        //ds.Tables.Add(dt);
                    }
                    else if (isIncome == "0")
                    {
                        //PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                        //DataTable dt = new DataTable();
                        //// Convert to DataTable.
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                        ////dt = (DataTable)PrintDataList1;
                        //ds.Tables.Add(dt);
                        //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                        //ds.Tables.Add(dt);
                    }
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = false;
                }
            }
            else
            {
                if (isIncome == "1")
                {
                    //PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForIncomeReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForExpenditureReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //DataTable dt = new DataTable();
                    //// Convert to DataTable.
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                    ////dt = (DataTable)PrintDataList1;
                    //ds.Tables.Add(dt);
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                    //ds.Tables.Add(dt);
                }
                else if (isIncome == "0")
                {
                    //PrintDataList1 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralAssetsReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    PrintDataList2 = MonthlyccoaDAO.SelectMonthlyCOAForGeneralLiabilityReport(requiredDate, sourceBranchCode, isIncome, workStation);
                    //DataTable dt = new DataTable();
                    //// Convert to DataTable.
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList1);
                    ////dt = (DataTable)PrintDataList1;
                    //ds.Tables.Add(dt);
                    //dt = ToGetDataTable<GLMDTO00023>(PrintDataList2);
                    //ds.Tables.Add(dt);
                }
            }
            return PrintDataList2;
        }
        // Coverting IList To Data Table //
        public DataTable ToGetDataTable<T>(IList<GLMDTO00023> lstRecords)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                try
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name);
                }
                catch { }
            }
            object[] values = new object[table.Columns.Count];
            foreach (GLMDTO00023 item in lstRecords)
            {
                try
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                        //values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                catch { }
            }
            return table;
        }
        #endregion

    }
}
